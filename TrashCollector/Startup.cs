using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrashCollector.Startup))]
namespace TrashCollector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        public void CreateRolesAndUsers()
        {
            Models.ApplicationDbContext dbContext = new Models.ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));
            var userManager = new UserManager<Models.ApplicationUser>(new UserStore<Models.ApplicationUser>(dbContext));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                var user = new Models.ApplicationUser();
                user.UserName = "Ed";
                user.Email = "ekim10203@gmail.com";
                string adminPassword = "Qwerty1!";
                var checkUser = userManager.Create(user, adminPassword);
                if (checkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);
            }
        }
    }
}
