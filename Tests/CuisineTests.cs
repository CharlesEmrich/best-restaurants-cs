using Xunit;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BestRestaurants.Objects;

namespace BestRestaurants
{
  public class CuisineTest : IDisposable
  {
    public CuisineTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=best_restaurants_test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Cuisine.DeleteAll();
    }

    [Fact]
    public void GetAll_DatabaseStartsEmpty()
    {
      //Arrange / Act
      int actual = Cuisine.GetAll().Count;
      int expected = 0;
      //Assert
      Assert.Equal(expected, actual);
    }
    [Fact]
    public void Equals_ReturnsTrueForEquivalentObjects()
    {
      //Arrange / Act
      Cuisine testCase1 = new Cuisine("Midwestern Fusion");
      Cuisine testCase2 = new Cuisine("Midwestern Fusion");
      //Assert
      Assert.Equal(testCase1, testCase2);
    }
    [Fact]
    public void Save_SavesCuisineToDatabase()
    {
      //Arrange
      Cuisine testCase = new Cuisine("Middle Eastern");
      //Act
      testCase.Save();
      List<Cuisine> actual = Cuisine.GetAll();
      List<Cuisine> expected = new List<Cuisine>{testCase};
      //Assert
      Assert.Equal(expected, actual);
    }
    [Fact]
    public void Find_ReturnsCuisineFromDatabase()
    {
      //Arrange
      Cuisine testCase = new Cuisine("Tex-Mex");
      testCase.Save();
      Cuisine expected = testCase;
      //Act
      Cuisine actual = Cuisine.Find(testCase.GetId());
      //Assert
      Assert.Equal(expected, actual);
    }
    [Fact]
    public void Delete_RemovesCuisineFromDatabase()
    {
      //Arrange
      Cuisine testCase = new Cuisine("Nouvelle French");
      testCase.Save();
      //Act
      Cuisine.Delete(testCase.GetId());
      int actual = Cuisine.GetAll().Count;
      int expected = 0;
      //Assert
      Assert.Equal(expected, actual);
    }
    [Fact]
    public void Update_UpdatesCuisineInDatabase()
    {
      //Arrange
      Cuisine testCase = new Cuisine("New Amercant");
      testCase.Save();
      string newName = "New American";
      //Act
      testCase.Update(newName);
      string actual = testCase.GetName();
      //Assert
      Assert.Equal(newName, actual);
    }

    // [Fact]
    // public void GetAll_DatabaseStartsEmpty()
    // {
    //   //Arrange
    //
    //   //Act
    //
    //   //Assert
    //
    // }
  }
}
