using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BestRestaurants.Objects
{
  public class Restaurant
  {
    private int    _id;
    private string _name;
    private string _priceRange;
    private int    _cuisineId;
    private bool   _happyHour;

    public Restaurant(string name, string priceRange, bool happyHour, int cuisineId = 0, int id = 0)
    {
      _id         = id;
      _name       = name;
      _priceRange = priceRange;
      _cuisineId  = cuisineId;
      _happyHour  = happyHour;
    }

    public override bool Equals(System.Object otherRestaurant)
    {
      if(!(otherRestaurant is Restaurant))
      {
        return false;
      }
      else
      {
        Restaurant newRestaurant = (Restaurant) otherRestaurant;
        bool idEquality = this.GetId() == newRestaurant.GetId();
        bool nameEquality = this.GetName() == newRestaurant.GetName();
        bool priceRangeEquality = this.GetPriceRange() == newRestaurant.GetPriceRange();
        bool cuisineIdEquality = this.GetCuisineId() == newRestaurant.GetCuisineId();
        bool happyHourEquality = this.GetHappyHour() == newRestaurant.GetHappyHour();
        return (idEquality && nameEquality && priceRangeEquality && cuisineIdEquality && happyHourEquality);
      }
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    //NOTE: Given that all "set" ops now route through the database, should we still be writing setters?
    public void SetName(string newName)
    {
      _name = newName;
    }
    public string GetPriceRange()
    {
      return _priceRange;
    }
    public int GetCuisineId()
    {
      return _cuisineId;
    }
    public bool GetHappyHour()
    {
      return _happyHour;
    }

    // public void Save()
    // {
    //   SqlConnection conn = DB.Connection();
    //   conn.Open();
    //
    //   SqlCommand cmd = new SqlCommand("INSERT INTO restaurants (name) OUTPUT INSERTED.id VALUES(@RestaurantName);", conn);
    //
    //   SqlParameter nameParameter = new SqlParameter();
    //   nameParameter.ParameterName = "@RestaurantName";
    //   nameParameter.Value = this.GetName();
    //   cmd.Parameters.Add(nameParameter);
    //   SqlDataReader rdr = cmd.ExecuteReader();
    //
    //   while(rdr.Read())
    //   {
    //     this._id = rdr.GetInt32(0);
    //   }
    //   if(rdr != null)
    //   {
    //     rdr.Close();
    //   }
    //   if(conn != null)
    //   {
    //     conn.Close();
    //   }
    // }
    // public void Update(string newName)
    // {
    //   SqlConnection conn = DB.Connection();
    //   conn.Open();
    //
    //   SqlCommand cmd = new SqlCommand("UPDATE restaurants SET name = @NewName OUTPUT INSERTED.name WHERE id = @RestaurantId;", conn);
    //
    //   SqlParameter newNameParameter = new SqlParameter();
    //   newNameParameter.ParameterName = "@NewName";
    //   newNameParameter.Value = newName;
    //   cmd.Parameters.Add(newNameParameter);
    //
    //
    //   SqlParameter restaurantIdParameter = new SqlParameter();
    //   restaurantIdParameter.ParameterName = "@RestaurantId";
    //   restaurantIdParameter.Value = this.GetId();
    //   cmd.Parameters.Add(restaurantIdParameter);
    //   SqlDataReader rdr = cmd.ExecuteReader();
    //
    //   while(rdr.Read())
    //   {
    //     this._name = rdr.GetString(0);
    //   }
    //
    //   if (rdr != null)
    //   {
    //     rdr.Close();
    //   }
    //
    //   if (conn != null)
    //   {
    //     conn.Close();
    //   }
    // }
    // public static Restaurant Find(int searchId)
    // {
    //   SqlConnection conn = DB.Connection();
    //   conn.Open();
    //
    //   SqlCommand cmd = new SqlCommand("SELECT * FROM restaurants WHERE id = @RestaurantId;", conn);
    //   SqlParameter categoryIdParameter = new SqlParameter();
    //   categoryIdParameter.ParameterName = "@RestaurantId";
    //   categoryIdParameter.Value = searchId.ToString();
    //   cmd.Parameters.Add(categoryIdParameter);
    //   SqlDataReader rdr = cmd.ExecuteReader();
    //
    //   int foundId = 0;
    //   string foundName = null;
    //
    //   while(rdr.Read())
    //   {
    //     foundId = rdr.GetInt32(0);
    //     foundName = rdr.GetString(1);
    //   }
    //
    //   Restaurant foundRestaurant = new Restaurant(foundName, foundId);
    //
    //   if(rdr != null)
    //   {
    //     rdr.Close();
    //   }
    //   if(conn != null)
    //   {
    //     conn.Close();
    //   }
    //
    //   return foundRestaurant;
    // }
    public static List<Restaurant> GetAll()
    {
      List<Restaurant> allRestaurants = new List<Restaurant>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM restaurants;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int restaurantId = rdr.GetInt32(0);
        string restaurantName = rdr.GetString(1);
        string restaurantPriceRange = rdr.GetString(2);
        int restaurantCuisineId = rdr.GetInt32(3);
        // bool restaurantHappyHour = rdr.GetSqlBoolean(4);
        bool restaurantHappyHour = true;
        Restaurant newRestaurant = new Restaurant(restaurantName, restaurantPriceRange, restaurantHappyHour, restaurantId, restaurantCuisineId);
        allRestaurants.Add(newRestaurant);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

      return allRestaurants;
    }
    // public static void Delete(int searchId)
    // {
    //   SqlConnection conn = DB.Connection();
    //   conn.Open();
    //
    //   SqlCommand cmd = new SqlCommand("DELETE FROM restaurants WHERE id = @RestaurantId;", conn);
    //   SqlParameter restaurantIdParameter = new SqlParameter();
    //   restaurantIdParameter.ParameterName = "@RestaurantId";
    //   restaurantIdParameter.Value = searchId.ToString();
    //   cmd.Parameters.Add(restaurantIdParameter);
    //
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    // }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM restaurants;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
