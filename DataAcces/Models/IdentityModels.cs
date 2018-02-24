using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAcces.Models
{
    // Přidáním dalších vlastností do třídy uživatelů můžete přidat data profilu uživatele. Další informace najdete na webu https://go.microsoft.com/fwlink/?LinkID=317594.
    public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            return await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }

    public class Role : IdentityRole<int, UserRole>
    {
        public Role() : base() { }
        public Role(string roleName) : this() { this.Name = roleName; }
    }

    public class UserLogin : IdentityUserLogin<int>
    {
        public int Id { get; set; }
        public UserLogin() : base() { }
    }

    public class UserClaim : IdentityUserClaim<int>
    {
        public UserClaim() : base() { }
    }

    public class UserRole : IdentityUserRole<int>
    {
        public int Id { get; set; }
        public UserRole() : base() { }
    }
}