
namespace WebApplication8
{
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Http;

    /// <summary>
    /// The employee controller.
    /// </summary>
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        public IHttpActionResult Get()
        {
            return this.Ok(Repository.Values);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return this.Ok(Repository[id]);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Repository.Remove(id);
            return this.StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="employee">
        /// The employee.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpPost]
        public IHttpActionResult Post(Employee employee)
        {
            Repository.Add(employee.Id, employee);
            var location = this.Request.RequestUri + "/" + employee.Id;
            return this.Created(location, employee);
        }

        private static readonly Dictionary<int, Employee> Repository = new Dictionary<int, Employee>()
        {
           {
               1, 
               new Employee() { Id = 1, Age = 23, City = "Kazan", Name = "Andrey" } },
          { 
              2, 
              new Employee() { Id = 2, Age = 233, City = "Samara", Name = "Oleg" } }
       };
    }
}