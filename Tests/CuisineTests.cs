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
