namespace BotAnja.DB.Controllers
{
    class MainController
    {
        private readonly static DB.Context DBContext = new DB.Context();

        internal static UsersController Users = new UsersController(DBContext);
    }
}
