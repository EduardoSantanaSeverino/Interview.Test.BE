using System;
using GraduationTracker.Application.UnitTests.Setup;
using GraduationTracker.Domain.Entities;
using GraduationTracker.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationTracker.Application.UnitTests
{
    public abstract class BaseTests
    {
        protected readonly IServiceProvider _provider;
        protected readonly IRepository<IStudent> _studentRepository;
        protected readonly IRepository<IDiploma> _diplomaRepository;
        protected readonly IGraduationTracker _graduationTracker;

        protected BaseTests()
        {
            _provider = DependencyInjection.TestingProvider();
            _studentRepository = _provider.GetRequiredService<IRepository<IStudent>>();
            _diplomaRepository = _provider.GetRequiredService<IRepository<IDiploma>>();
            _graduationTracker = _provider.GetRequiredService<IGraduationTracker>();
        }
    }
}