using Fish.Controllers;
using Fish.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Test;

public class FamilyControllerTest
{ 

    private DbContextOptions<FishContext>? _contextOptions;
    FishContext context;

    //Initialize the Controller and inMemory database
    public FamilyControllerTest()
    {
        _contextOptions = new DbContextOptionsBuilder<FishContext>()
           .UseInMemoryDatabase("DbTest")
           .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
           .Options;

        context = new FishContext(_contextOptions);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
    
    [Fact(DisplayName = "Index Page with some Objects")]
    public void Given_SomeObjects_When_IndexCalled_Then_ReturnObjects()
    {
        //Arrange
        context.AddRange(
            new Family { Id = 1, Name = "Angel" },
            new Family { Id = 2, Name = "Tang"});

        context.SaveChanges();

        //Act
        FamilyController controller = new FamilyController(context);
        var result = controller.Index().Result as ViewResult;
        var family = (List<Family>) result.ViewData.Model;

        //Assert
        Assert.Equal("Angel", family[0].Name);

    }

    [Fact(DisplayName = "Index Page with No Objects")]
    public void Given_NoObjects_When_IndexCalled_Then_ReturnObjects()
    {
        //Act
        FamilyController controller = new FamilyController(context);
        var result = controller.Index().Result as ViewResult;
        List<Family>? family = (List<Family>)result.ViewData.Model;

        //Assert
        Assert.Empty(family);

    }

    [Fact(DisplayName = "Details Page return Not Found")]
    public void Given_Id_When_DetailsCalled_Then_ReturnNotFound()
    {
        //Arrange
        int id = 0;
        
        //Act
        FamilyController controller = new FamilyController(context);
        var result = controller.Details(id);
        //List<Family>? family = (List<Family>)result.ViewData.Model;

        //Assert
        Assert.Empty(family);

    }
}
