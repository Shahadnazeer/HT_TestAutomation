using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HT_Design_Pattern.StepDefinitions
{
    [Binding]
    public class calSD
    {
        private int cakePieces;
        private int ateQuantity;
        private int expectedResult;
        private int actualResult;

        [Given(@"there are (.*) in a cake")]
        public void GivenThereAreInACake(int p0)
        {
            cakePieces = p0;
        }

        [When(@"I ate (.*) pieces from the cake")]
        public void WhenIAtePiecesFromTheCake(int p1)
        {
            ateQuantity = p1;
        }

        [Then(@"the remaining peices of cake are (.*)")]
        public void ThenTheRemainingPeicesOfCakeAre(int p0)
        {
            actualResult = cakePieces - ateQuantity;
            expectedResult = p0;
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
