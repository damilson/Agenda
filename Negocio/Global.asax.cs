using Negocio.Mappers;

namespace Negocio
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.RegisterMappings();
        }
    }
}
