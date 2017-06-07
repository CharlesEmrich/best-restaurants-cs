using Xunit;
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

    [Fact]
    public void GetAll_DatabaseStartsEmpty()
    {
      //Arrange / Act
      int actual = Cuisine.GetAll().Count;
      int expected = 0;
      //Assert
      Asser.Equal(expect, actual);
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
