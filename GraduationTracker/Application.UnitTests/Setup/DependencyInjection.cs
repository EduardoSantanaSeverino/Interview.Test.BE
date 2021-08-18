using System;
using GraduationTracker.Application.Models;
using GraduationTracker.Domain.Entities;
using GraduationTracker.Domain.Rules;
using GraduationTracker.Persistence;
using GraduationTracker.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GraduationTracker.Application.UnitTests.Setup
{
    public static class DependencyInjection
    {
        public static IServiceProvider TestingProvider()
        {
            return new ServiceCollection()
                .AddScoped<IGraduationTracker, GraduationTracker>()
                .AddScoped<IStudentIndicator, StudentIndicator>()
                .AddScoped<IStadingRules, StadingRules>()
                .AddScoped<IDatabase, HardCodedDataBase>()
                .AddScoped<IRepository<IStudent>, StudentRepository>()
                .AddScoped<IRepository<IDiploma>, DiplomaRepository>()
                .BuildServiceProvider();
        }
    }
}