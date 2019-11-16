using PharmacyDrone.DataHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyDrone.Classes
{
    public enum AccountState {Pending = 1,Active , Suspended , Inactive };// acounts all have states , pending(when its just been created , only an admin can change to active) Active , Suspended(Can no longer login) Inactive (Account will no long be used ever)
    class User
    {
        private int userId;
        private string username;
        private string password;
        private int accountType;
        private int state;        

        public int UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int AccountType { get => accountType; set => accountType = value; }
        public int State { get => state; set => state = value; }
      

        public User(int userId, string username, string password,int accountType, int state)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
            this.accountType = accountType;
            this.state = state;
        }
        public User(string username, string password, int accountType, int state)
        { 
            this.username = username;
            this.password = password;
            this.accountType = accountType;
            this.state = state;
        }

        public User(int userId,string username, int accountType, int state)
        {
            this.userId = userId;
            this.username = username;
        
            this.accountType = accountType;
            this.state = state;
        }

        public User()
        {

        }


        public List<User> readUsers()
        {
            
            List<User> userList = new DatahandlerR().ReadUsers();
            return userList;
        }

        public bool insertUser(User u)
        {
            return DatahandlerR.InsertUser(u);
        }

        public void updateState(int i,int id,int accountType)
        {
            DatahandlerR.UpdateState(i, id,accountType);
        }
    }
}
