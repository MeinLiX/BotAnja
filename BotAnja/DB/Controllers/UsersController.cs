using BotAnja.DB.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BotAnja.DB.Controllers
{
    class UsersController : MainController
    {
        private readonly DB.Context DBContext;

        public UsersController(DB.Context DBContext)
        {
            this.DBContext = DBContext;
        }

        public User GetFirstUser(int id) => DBContext.Users.FirstOrDefault(user => user.Id == id);

        public async Task<bool> AddUser(User user)
        {
            if (user == null)
            {
                return false;
            }

            DBContext.Users.Add(user);
            await DBContext.SaveChangesAsync();
            await Task.CompletedTask;
            return true;
        }

        public async Task<bool> ReplaceUser(User user)
        {
            if (user == null)
            {
                return false;
            }

            DBContext.Users.Update(user);
            await DBContext.SaveChangesAsync();
            await Task.CompletedTask;
            return true;
        }
    }
}
