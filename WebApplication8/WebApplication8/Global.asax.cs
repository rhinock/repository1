
namespace WebApplication8
{
    using System.Web.Http;

    /// <summary>
    /// The global.
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// The application_ start.
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}