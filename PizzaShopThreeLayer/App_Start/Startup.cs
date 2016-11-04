using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using PizzaShop.BLL.Interfaces;
using PizzaShop.BLL.Services;

[assembly: OwinStartup(typeof(PizzaShopThreeLayer.Startup))]

namespace PizzaShopThreeLayer
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserServise>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserServise CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }
    }
}
