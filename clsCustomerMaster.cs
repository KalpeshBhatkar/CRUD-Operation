using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsCustomerMaster
/// </summary>
public class clsCustomerMaster
{
    string constring = ConfigurationManager.ConnectionStrings["CRUD"].ConnectionString;

    public int CustomerID { get; set; }
    public string Name { get; set; }
    public string MobileNo { get; set; }
    public string Gender { get; set; }
    public string EmailID { get; set; }
    public int UserID { get; set; }

    public int InsertUpdateCustomer(clsCustomerMaster obj)
    {
        SqlConnection con = new SqlConnection(constring);
        SqlCommand cmd = new SqlCommand("spInsertUpdateCustomer", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("CustomerID", obj.CustomerID);
        cmd.Parameters.AddWithValue("Name", obj.Name);
        cmd.Parameters.AddWithValue("MobileNo", obj.MobileNo);
        cmd.Parameters.AddWithValue("Gender", obj.Gender);
        cmd.Parameters.AddWithValue("EmailID", obj.EmailID);
        cmd.Parameters.AddWithValue("UserID", obj.UserID);
        con.Open();
        obj.CustomerID = Convert.ToInt32(cmd.ExecuteScalar());
        con.Close();
        return obj.CustomerID;
    }

    public int DeleteCustomer(clsCustomerMaster obj)
    {
        SqlConnection con = new SqlConnection(constring);
        SqlCommand cmd = new SqlCommand("spDeleteCustomer", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
        cmd.Parameters.AddWithValue("@UserID", obj.UserID);
        con.Open();
        int count = cmd.ExecuteNonQuery();
        con.Close();
        return count;
    }

    public DataTable SelectCustomer(int CustomerID = 0)
    {
        SqlConnection con = new SqlConnection(constring);
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("spSelectCustomer", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);
        con.Close();
        return dt;

    }
}