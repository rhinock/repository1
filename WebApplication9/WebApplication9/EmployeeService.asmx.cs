
namespace WebApplication9
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Script.Serialization;
    using System.Web.Services;

    /// <summary>
    /// Summary description for ContactService
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1608:ElementDocumentationMustNotHaveDefaultSummary", Justification = "Reviewed. Suppression is OK here.")]
    [WebService(Namespace = "http://tempuri.org/")]

    //// [WebService(Namespace = "http://demo3665031.mockable.io")]

    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EmployeeService : WebService
    {
        /// <summary>
        /// The get all employees.
        /// </summary>
        [WebMethod]
        public void GetAllEmployees()
        {
            var listEmployees = new List<Employee>();
            var cs = ConfigurationManager.ConnectionStrings["Data1"].ConnectionString;
            using (var con = new SqlConnection(cs))
            {
                var cmd = new SqlCommand("SELECT * FROM Contacts", con);
                con.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var employee = new Employee
                    {
                        Id = Convert.ToInt32(rdr["id"]),
                        Gender = rdr["Gender"].ToString(),
                        FirstName = rdr["FirstName"].ToString(),
                        LastName = rdr["LastName"].ToString(),
                        EMail = rdr["EMail"].ToString()
                    };
                    listEmployees.Add(employee);
                }
            }

            var js = new JavaScriptSerializer();
            this.Context.Response.Write(js.Serialize(listEmployees));
        }
    }
}
