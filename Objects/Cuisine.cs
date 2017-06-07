using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BestRestaurants.Objects
{
  public class Cuisine
  {
    private int _id;
    private string _name;

    public Cuisine(string name, int id = 0)
    {
      _id = id;
      _name = name;
    }

    public override bool Equals(System.Object otherCuisine)
    {
      if(!(otherCuisine is Cuisine))
      {
        return false;
      }
      else
      {
        Cuisine newCuisine = (Cuisine) otherCuisine;
        bool idEquality = this.GetId() == newCuisine.GetId();
        bool nameEquality = this.GetName() == newCuisine.GetName();
        return (idEquality && nameEquality);
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
    public void SetName(string newName)
    {
      _name = newName;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO cuisines (name) OUTPUT INSERTED.id VALUES(@CuisineName);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@CuisineName";
      nameParameter.Value = this.GetName();
      cmd.Parameters.Add(nameParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }
    public static Cuisine Find(int searchId)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM cuisines WHERE id = @CuisineId;", conn);
      SqlParameter categoryIdParameter = new SqlParameter();
      categoryIdParameter.ParameterName = "@CuisineId";
      categoryIdParameter.Value = searchId.ToString();
      cmd.Parameters.Add(categoryIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundId = 0;
      string foundName = null;

      while(rdr.Read())
      {
        foundId = rdr.GetInt32(0);
        foundName = rdr.GetString(1);
      }

      Cuisine foundCuisine = new Cuisine(foundName, foundId);

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

      return foundCuisine;
    }
    public static List<Cuisine> GetAll()
    {
      List<Cuisine> allCuisines = new List<Cuisine>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM cuisines;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int cuisineId = rdr.GetInt32(0);
        string cuisineName = rdr.GetString(1);
        Cuisine newCuisine = new Cuisine(cuisineName, cuisineId);
        allCuisines.Add(newCuisine);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

      return allCuisines;
    }
    public static Delete()
    {

    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM cuisines;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
