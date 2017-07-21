using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace AngularJsDemo
{
    /// <summary>
    /// Summary description for EmployeeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class EmployeeService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetEmployees()
        {
           List<Employee> listEmployees = new List<Employee>();
            string cs = ConfigurationManager.ConnectionStrings["Angular"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd=new SqlCommand("Select * from Employees",con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee emp=new Employee();
                    emp.id = Convert.ToInt32(rdr["Id"]);
                    emp.name = rdr["Name"].ToString();
                    emp.gender = rdr["Gender"].ToString();
                    emp.salary = Convert.ToInt32(rdr["Salary"]);
                    listEmployees.Add(emp);
                }
            }
            JavaScriptSerializer js=new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listEmployees));
        }
    }
}
