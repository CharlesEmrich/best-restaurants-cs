using Xunit;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BestRestaurants.Objects;

namespace BestRestaurants
{
  public class RestaurantTest : IDisposable
  {
    public RestaurantTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=best_restaurants_test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Restaurant.DeleteAll();
    }

    [Fact]
    public void GetAll_DatabaseStartsEmpty()
    {
      //Arrange / Act
      int actual = Restaurant.GetAll().Count;
      int expected = 0;
      //Assert
      Assert.Equal(expected, actual);
    }
    [Fact]
    public void Equals_ReturnsTrueForEquivalentObjects()
    {
      //Arrange / Act
      Restaurant testCase1 = new Restaurant("Midwestern Fusion");
      Restaurant testCase2 = new Restaurant("Midwestern Fusion");
      //Assert
      Assert.Equal(testCase1, testCase2);
    }
    [Fact]
    public void Save_SavesRestaurantToDatabase()
    {
      //Arrange
      Restaurant testCase = new Restaurant("Middle Eastern");
      //Act
      testCase.Save();
      List<Restaurant> actual = Restaurant.GetAll();
      List<Restaurant> expected = new List<Restaurant>{testCase};
      //Assert
      Assert.Equal(expected, actual);
    }
    [Fact]
    public void Find_ReturnsRestaurantFromDatabase()
    {
      //Arrange
      Restaurant testCase = new Restaurant("Tex-Mex");
      testCase.Save();
      Restaurant expected = testCase;
      //Act
      Restaurant actual = Restaurant.Find(testCase.GetId());
      //Assert
      Assert.Equal(expected, actual);
    }
    [Fact]
    public void Delete_RemovesRestaurantFromDatabase()
    {
      //Arrange
      Restaurant testCase = new Restaurant("Nouvelle French");
      testCase.Save();
      //Act
      Restaurant.Delete(testCase.GetId());
      int actual = Restaurant.GetAll().Count;
      int expected = 0;
      //Assert
      Assert.Equal(expected, actual);
    }
    [Fact]
    public void Update_UpdatesRestaurantInDatabase()
    {
      //Arrange
      Restaurant testCase = new Restaurant("New Amercant");
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
