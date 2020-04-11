using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using DemoProject.Models;
using System.Data;
using System.Configuration;

namespace DemoProject.DataLayer
{
    public class ADOClient
    {
        public static string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        
        // adding branch object
        public static void Add(EmployeeModels model)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("usp_Employee_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeName", model.EmpoyeeName);
                cmd.Parameters.AddWithValue("@DepartmentId", model.DepartmentId);
                cmd.Parameters.AddWithValue("@Salary", model.Salary);
                cmd.Parameters.AddWithValue("@RowStatus", model.RowStatus);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex){
                string ec = ex.Message;
            }
        }
        public static void Update(EmployeeModels model)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd=new SqlCommand("usp_Employee_Update",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", model.Id);
            cmd.Parameters.AddWithValue("@EmpoyeeName", model.EmpoyeeName);
            cmd.Parameters.AddWithValue("@DepartmentId", model.DepartmentId);
            cmd.Parameters.AddWithValue("@Salary", model.Salary);
            cmd.Parameters.AddWithValue("@RowStatus", model.RowStatus);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static List<EmployeeModels> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("usp_Employee_GetAll",con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "usp_Employee_GetAll";
            //cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<EmployeeModels> empList = new List<EmployeeModels>();
            while (reader.Read())
            {
                EmployeeModels model = new EmployeeModels();
                model.EmpoyeeName = DBNull.Value != reader["EmpoyeeName"] ? (string)reader["EmpoyeeName"] : default(string);
                model.Salary = DBNull.Value != reader["Salary"] ? (double)reader["Salary"] : default(double);
                model.DepartmentId = DBNull.Value != reader["DepartmentId"] ? (int)reader["DepartmentId"] : default(int);
                model.RowStatus = DBNull.Value != reader["RowStatus"] ? (int)reader["RowStatus"] : default(int);
                model.DepartmentName=DBNull.Value!=reader["DepartmentName"]?(string)reader["DepartmentName"] :default(string);
                
                empList.Add(model);

            }
            reader.Close();
            con.Close();
            return empList;
        }


        public static List<DepartmentModels> GetAllDepartment()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("usp_Department_GetAll",con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List <DepartmentModels> dpmodels= new List<DepartmentModels>();
            while(reader.Read()){
                DepartmentModels models = new DepartmentModels();
                models.DepartName = DBNull.Value != reader["DepartmentName"] ? (string)reader["DepartmentName"] : default(string);
                models.Id = DBNull.Value != reader["Id"] ? (int)reader["Id"] : default(int);
                dpmodels.Add(models);
            }
            reader.Close();
            con.Close();
            return dpmodels;
        }
    }
}