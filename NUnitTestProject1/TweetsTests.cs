using NUnit.Framework;
using System.Collections.Generic;
using TwitterCloneAPI;
using TwitterCloneAPI.Controllers;
using TwitterCloneAPI.DataSource;
using TwitterCloneAPI.Misc;
using TwitterCloneAPI.Models;

namespace NUnitTestProject1
{
    public class TweetsTests
    {
        [SetUp]
        public void Setup()
        {
            Startup.thesource = new FixedSource();
        }

        [Test]
        public void Get()
        {
            TweetsController tweetscontroller = new TweetsController();
            List<clientTweet> Response = tweetscontroller.Get(1);
            clientTweet tweet = Response.Find(t => t.ID == 1);
            Assert.That(tweet.ID == 1);
        }

        [Test]
        public void Post()
        {
            TweetsController tweetscontroller = new TweetsController();
            clientNewTweet NewTweets = new clientNewTweet() { UserID = 1, Text = "New Tweet 2" };
            tweetscontroller.Post(NewTweets);
            List<clientTweet> Response = tweetscontroller.Get(1);
            Assert.That(Response.Count == 2);
        }

        [Test]
        public void Delete()
        {
            TweetsController tweetscontroller = new TweetsController();
            tweetscontroller.Delete(1);
            List<clientTweet> Response = tweetscontroller.Get(1);
            Assert.That(Response.Count == 0);
        }
    }
}