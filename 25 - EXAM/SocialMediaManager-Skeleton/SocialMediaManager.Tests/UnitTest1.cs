using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {


        }

   
        [Test]
        public void Validate_Ctor2()
        {
            Influencer influencer = new Influencer("Joro",200);

           

            Assert.AreEqual("Joro", influencer.Username);
            Assert.AreEqual(200, influencer.Followers);
            
        }

        [Test]
        public void Validate_RegisterInfluencerNull()
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();
            Influencer influencer = new Influencer("Joro", 200);

           //influencerRepository.RegisterInfluencer(null);

            Assert.Throws<ArgumentNullException>(() => influencerRepository.RegisterInfluencer(null));

        }


        [Test]
        public void Validate_RegisterInfluencerSecondIf()
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();
            Influencer influencer = new Influencer("Joro", 200);

            influencerRepository.RegisterInfluencer(influencer);

            Assert.Throws<InvalidOperationException>(() => influencerRepository.RegisterInfluencer(influencer));

        }

        [Test]
        public void Validate_RegisterInfluencerNew()
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();
            Influencer influencer = new Influencer("Joro", 200);
            Influencer influencer1 = new Influencer("Pesh", 200);
                influencerRepository.RegisterInfluencer(influencer);
            var actual =  influencerRepository.RegisterInfluencer(influencer1);


            Assert.AreEqual($"Successfully added influencer Pesh with 200", actual);
            Assert.AreEqual(2, influencerRepository.Influencers.Count);
        }

        [Test]
        public void Validate_RemoveInfluencerNull()
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();
            Influencer influencer = new Influencer("Joro", 200);
            Influencer influencer1 = new Influencer("Pesh", 200);
            influencerRepository.RegisterInfluencer(influencer);
            influencerRepository.RegisterInfluencer(influencer1);
            

         Assert.Throws<ArgumentNullException>(() => influencerRepository.RemoveInfluencer(null));
        }


        [Test]
        public void Validate_RemoveInfluencerSpace()
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();
            Influencer influencer = new Influencer("Joro", 200);
            Influencer influencer1 = new Influencer("Pesh", 200);
            influencerRepository.RegisterInfluencer(influencer);
            influencerRepository.RegisterInfluencer(influencer1);


            Assert.Throws<ArgumentNullException>(() => influencerRepository.RemoveInfluencer(" "));
        }

        [Test]
        public void Validate_RemoveInfluencerOK()
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();
            Influencer influencer = new Influencer("Joro", 200);
            Influencer influencer1 = new Influencer("Pesh", 200);
            influencerRepository.RegisterInfluencer(influencer);
            influencerRepository.RegisterInfluencer(influencer1);
            bool actual = influencerRepository.RemoveInfluencer("Pesh");

            Assert.IsTrue(actual);
            Assert.AreEqual(1, influencerRepository.Influencers.Count);

        }
        [Test]
        public void Validate_RemoveInfluencerFalse()
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();
            Influencer influencer = new Influencer("Joro", 200);
            Influencer influencer1 = new Influencer("Pesh", 200);
            influencerRepository.RegisterInfluencer(influencer);
            //influencerRepository.RegisterInfluencer(influencer1);
            bool actual = influencerRepository.RemoveInfluencer("Pesh");

            Assert.IsFalse(actual);
            Assert.AreEqual(1, influencerRepository.Influencers.Count);

        }

        [Test]
        public void Validate_GetInfluencerWithMostFollowersFound()
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();
            Influencer influencer = new Influencer("Joro", 200);
            Influencer influencer1 = new Influencer("Pesh", 300);
            Influencer influencer2 = new Influencer("Atanas", 400);
            influencerRepository.RegisterInfluencer(influencer);
            influencerRepository.RegisterInfluencer(influencer1);
            influencerRepository.RegisterInfluencer(influencer2);

            var actual = influencerRepository.GetInfluencerWithMostFollowers();

            Assert.That(influencer2, Is.EqualTo(actual));

        }

        [Test]
        public void Validate_GetInfluencerWithMostFollowersThrow()
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();
            Influencer influencer = new Influencer("Joro", 200);
            Influencer influencer1 = new Influencer("Pesh", 300);
            Influencer influencer2 = new Influencer("Atanas", 400);
           // influencerRepository.RegisterInfluencer(influencer);
          //  influencerRepository.RegisterInfluencer(influencer1);
           // influencerRepository.RegisterInfluencer(influencer2);

            //var actual = influencerRepository.GetInfluencerWithMostFollowers();

            Assert.Throws<IndexOutOfRangeException>(() => influencerRepository.GetInfluencerWithMostFollowers());

        }



        [Test]
        public void Validate_GetInfluencer()
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();
            Influencer influencer = new Influencer("Joro", 200);
            Influencer influencer1 = new Influencer("Pesh", 300);
            Influencer influencer2 = new Influencer("Atanas", 400);
            influencerRepository.RegisterInfluencer(influencer);
            influencerRepository.RegisterInfluencer(influencer1);
            influencerRepository.RegisterInfluencer(influencer2);

            var actual = influencerRepository.GetInfluencer("Joro");

            Assert.That(influencer, Is.EqualTo(actual));

        }

        [Test]
        public void Validate_GetInfluencerNull()
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();
            Influencer influencer = new Influencer("Joro", 200);
            Influencer influencer1 = new Influencer("Pesh", 300);
            Influencer influencer2 = new Influencer("Atanas", 400);
            influencerRepository.RegisterInfluencer(influencer);
            influencerRepository.RegisterInfluencer(influencer1);
            influencerRepository.RegisterInfluencer(influencer2);
            Influencer actual = null;
             actual = influencerRepository.GetInfluencer("Joroo");

            Assert.AreEqual(null, actual);

        }
    }
}