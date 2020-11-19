using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPI.Interfaces;
using TwitterCloneAPI.Models;

namespace TwitterCloneAPI.DataSource
{
    public class FixedSource : IDataSource
    {

        public FixedSource()
        {
            Users = new List<serverUserModel>() 
            { new serverUserModel() 
                { 
                    ID = 1,
                    Name = "Ash Butcher",
                    Username = "Admin",
                    Password = "admin"
                }
          };

            Tweets = new List<serverTweet>()
            { new serverTweet()
                {
                    ID = 1,
                    Text = "Ash's First Tweet",
                    UserID = 1

                }
          };

        }

        public List<serverUserModel> Users;
        public List<serverTweet> Tweets;

        public bool Add(clientSignup signup)
        {
            int UserCount = Users.Count;
            Users.Add(new serverUserModel() { ID = UserCount + 1, Name = signup.Name, Username = signup.Username, Password = signup.Password });    
            return true;
        }

        public bool Add(clientNewTweet tweet)
        {
            int TweetCount = Tweets.Count;
            Tweets.Add(new serverTweet() { ID = TweetCount + 1, Text = tweet.Text, UserID = tweet.UserID });
            return true;
        }

        public bool Delete(int TweetID)
        {
            serverTweet SUM = Tweets.Where(t => t.ID == TweetID).FirstOrDefault();

            if (SUM != null)
            {
                Tweets.Remove(SUM);
                return true;
            }

            return false;
        }

        public bool Delete(clientUser UserID)
        {
            serverUserModel SUM = Users.Where(t => t.ID == UserID.ID).FirstOrDefault();

            if (SUM != null)
            {
                Users.Remove(SUM);
                return true;
            }

            return false;
        }

        public bool Update(clientUser user)
        {
            serverUserModel SUM = Users.Where(t => t.ID == user.ID).FirstOrDefault();

            if (SUM != null)
            {
                SUM.Name = user.Name;
                SUM.Username = user.Username;
                return true;
            }

            return false;
        }

        public bool Update(clientTweet tweet)
        {
            serverTweet TUM = Tweets.Where(t => t.ID == tweet.ID).FirstOrDefault();

            if (TUM != null)
            {
                TUM.Text = tweet.Text;
                return true;
            }

            return false;
        }

        public clientUser GetUser(int UserID)
        {
            serverUserModel SUM = Users.Where(t => t.ID == UserID).FirstOrDefault();

            if (SUM != null)
            {
                return new clientUser() { ID = SUM.ID, Username = SUM.Username, Name = SUM.Name };
            }

            return null;
        }

        public List<clientTweet> GetTweets(int UserID)
        {
            serverUserModel SUM = Users.Where(t => t.ID == UserID).FirstOrDefault();
            if (SUM != null)
            {
                return Tweets.Where(t => t.UserID == SUM.ID).Select(x => new clientTweet() { ID = x.ID, Text = x.Text } ).ToList();
            }

            return null;
        }

        public clientUser GetUser(string username, string password)
        {
            serverUserModel SUM = Users.Where(t => t.Username.ToLower() == username.ToLower() && t.Password == password).FirstOrDefault();

            if (SUM != null)
            {
                return new clientUser() { ID = SUM.ID,Username = SUM.Username, Name = SUM.Name };
            }

            return null;
        }
    }
}
