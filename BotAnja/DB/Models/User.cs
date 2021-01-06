namespace BotAnja.DB.Models
{
    class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string InviteToken { get; set; }
        public int State { get; set; }

        public User(int Id, string Username) : this(Id, Username, "", -1)
        {

        }

        public User(int Id, string Username, int State) : this(Id, Username, "", State)
        {

        }

        public User(int Id, string Username, string InviteToken, int State)
        {
            this.Id = Id;
            this.Username = Username;
            this.InviteToken = InviteToken;
            this.State = State;
        }
    }
}
