###Refactor Xello Backend Engineer Coding Challenge
Using Clean Structure and SOLID Principles.
The project is layout in layers. So we can easily replace one layer like we do with lego pieces.

####Domain Project

The Domain project contains Domain Entities, Domain Enums and Domain Rules.
The Domain project does not depend on any other project. 

####Repository Project 

The Repository project contains an abstraction layer between the data access and application. This project depends on Domain Project and Persistence. Easily Swappable with another Repositories targeting a different data source.

####Application Project 

The Application project contains All the application core logic. Depends on the Domain.

####Persistence Project

This Persistence project represent a database connection which is not implemented. Depends on Domain project.

####Refactoring Improvements

1. Applied the SRP whenever is possible. For example, the only reason to change the StadingRules.cs file is when the Domain Rules has changed.

2. Applied the OCP whenever is possible. For example, in the StudentIndicator.cs is using the virtual modifier looking for a future extension.  

3. Applied the LSP whenever is possible. For example, the Course entity can be easily replaced with its parent ICourse representation, and each and every class is Implementing all methods which are not throwing errors like NO IMPLEMENTED EXCEPTION.

4. Applied the ISP whenever is possible. For example, each and every class has a clear implementation and equally distributed, there is no violation of this principle.    

5. Applied the DIP whenever is possible. For example, using the default Dependency Injection framework provided by MS .Net Core. To see it in action please look at the DependencyInjection.cs file.   

6. Changed various Entities to reflect a more real-world setting. For example the Requirement Entity was changed from having an array of Ids of courses to having only one course.

7. Changed the Entities from using an Array of integer to Use List of entities.

  


