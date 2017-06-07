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

    // TODO: refactor to account for a constructor that can call Cuisine().
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
      Restaurant testCase1 = new Restaurant("Shoney's", "$$", true);
      Restaurant testCase2 = new Restaurant("Shoney's", "$$", true);
      //Assert
      Assert.Equal(testCase1, testCase2);
    }
    [Fact]
    public void Save_SavesRestaurantToDatabase()
    {
      //Arrange
      Restaurant testCase = new Restaurant("Dar Al Salaam", "$$$", false, 0);
      //Act
      testCase.Save();
      List<Restaurant> actual = Restaurant.GetAll();
      List<Restaurant> expected = new List<Restaurant>{testCase};

      // foreach(Restaurant ele in actual)
      // {
      //   Console.WriteLine("Act- Id: {0} Name: {1} priceRange: {2} happyHour: {3} cuisineId: {4}", ele.GetId(), ele.GetName(), ele.GetPriceRange(), ele.GetHappyHour(), ele.GetCuisineId());
      // }
      // foreach(Restaurant ele in expected)
      // {
      //   Console.WriteLine("Exp- Id: {0} Name: {1} priceRange: {2} happyHour: {3} cuisineId: {4}", ele.GetId(), ele.GetName(), ele.GetPriceRange(), ele.GetHappyHour(), ele.GetCuisineId());
      // }

      //Assert
      Assert.Equal(expected, actual);
    }
    [Fact]
    public void Find_ReturnsRestaurantFromDatabase()
    {
      //Arrange
      Restaurant testCase = new Restaurant("Departures", "$$$$", true, 0);
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
      Restaurant testCase1 = new Restaurant("Quimby's", "$", true);
      testCase1.Save();
      Restaurant testCase2 = new Restaurant("Shrimpy's", "$", true);
      testCase2.Save();
      //Act
      Restaurant.Delete(testCase1.GetId());
      int actual = Restaurant.GetAll().Count;
      int expected = 1;
      //Assert
      Assert.Equal(expected, actual);
    }
    [Fact]
    public void Update_UpdatesRestaurantInDatabase()
    {
      //Arrange
      Restaurant testCase = new Restaurant("He Pie Whole", "$$", false);
      testCase.Save();
      string newName = "The Pie Hole";
      //Act
      testCase.Update("name", newName);
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
