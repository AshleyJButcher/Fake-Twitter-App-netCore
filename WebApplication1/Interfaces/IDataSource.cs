using TwitterCloneAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterCloneAPI.Interfaces
{
    public interface IDataSource
    {
        bool Add(clientSignup signup);
        bool Add(clientNewTweet tweet);

        bool Update(clientUser user);
        bool Update(clientTweet tweet);

        bool Delete(int TweetID);
        bool Delete(clientUser UserID);

        clientUser GetUser(int UserID);
        clientUser GetUser(string username, string password);
        List<clientTweet> GetTweets(int UserID);
    }
}
