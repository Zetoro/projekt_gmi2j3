using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biljettshoppen.Events;
using Biljettshoppen;

namespace MSTest
{
    [TestClass]
    public class OrganizerTest
    {
        [TestMethod]
        public void Test_Invalid_DateTime()
        {
            Assert.ThrowsException<InvalidDataException>(() => new Ocassion("Rock","Rasmus","Consert", "2024-05-12 22:00","brick"));
        }
        [TestMethod]
        public void Test_Create_Occation_Same_Date_Premis()
        {
            string occasionName = "RockStar";
            string performer = "Rasmus";
            string occasionType = "Consert";
            string occasionDateString = "2024/07/17 22:00";
            string premiseType = "brick";
            new Ocassion(occasionName, performer, occasionType, occasionDateString, premiseType);

            string occasionName2 = "RockStar";
            string performer2 = "Rasmus";
            string occasionType2 = "Consert";
            string occasionDateString2 = "2024/07/17 22:00";
            string premiseType2 = "brick";
            Assert.ThrowsException<InvalidDataException>(() =>
            {
                new Ocassion(occasionName2, performer2, occasionType2, occasionDateString2, premiseType2);
            });
        }
        
        [TestMethod]
        public void Test_Valid_Occasion()
        {
            PremiseFactory premiseFactory = new PremiseFactory();
            string occasionName = "RockStar";
            string performer = "Rasmus";
            string occasionType = "Consert";
            DateTime occasionDate = DateTime.Parse("2024/07/18 22:00");
            string occasionDateString = "2024/07/18 22:00";
            Premise premiseType = premiseFactory.TypeOfPremise("brick");
            string premiseTypeString = "brick";

            // Act
            var occasion = new Ocassion(occasionName, performer, occasionType, occasionDateString, premiseTypeString);

            // Assert
            Assert.AreEqual(occasionName, occasion.OcassionName);
            Assert.AreEqual(performer, occasion.OcassionPerformer);
            Assert.AreEqual(occasionType, occasion.OcassionType);
            Assert.AreEqual(occasionDate, occasion.OcassionDate);
            Assert.AreEqual(premiseType.location, occasion.premiseSet.location);
        }
        [TestMethod]
        public void Test_Invalid_Location()
        {
            string occasionName = "RockStar";
            string performer = "Rasmus";
            string occasionType = "Consert";
            string occasionDateString = "2024/07/22 22:00";
            string premiseType = "tegel";
            Assert.ThrowsException<InvalidDataException>(() =>
            {
                new Ocassion(occasionName, performer, occasionType, occasionDateString, premiseType);
            });
        }
        [TestMethod]
        public void Test_Invalid_Date_Format()
        {
            string occasionName = "RockStar";
            string performer = "Rasmus";
            string occasionType = "Consert";
            string occasionDateString = "2024/07//22 22:00";
            string premiseType = "tegel";
            Assert.ThrowsException<InvalidDataException>(() =>
            {
                new Ocassion(occasionName, performer, occasionType, occasionDateString, premiseType);
            });
        }
    }
}
