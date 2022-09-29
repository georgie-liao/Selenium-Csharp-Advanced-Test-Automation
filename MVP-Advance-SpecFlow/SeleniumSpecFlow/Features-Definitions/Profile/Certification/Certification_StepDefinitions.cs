using NUnit.Framework;
using SeleniumSpecFlow.Pages.ProfilePages;
using SeleniumSpecFlow.Utilities;
using System;
using TechTalk.SpecFlow;
using static SeleniumSpecFlow.Utilities.GlobalDefinitions;

namespace SeleniumSpecFlow
{
    [Binding]
    public class Certification_StepDefinitions
    {
        Certifications certificationObj = new Certifications();

        [Given(@"I go to Certifications")]
        public void GivenIGoToCertifications()
        {
            certificationObj.GoToCertifications();
        }

        [When(@"I click on Add New button")]
        public void WhenIClickOnAddNewButton()
        {
            certificationObj.ClickButtonAddNew();
        }

        [When(@"I enter new certification")]
        public void WhenIEnterNewCertification()
        {
            certificationObj.EnterCertificate();
        }

        [Then(@"The certification should be added successfully")]
        public void ThenTheCertificationShouldBeAddedSuccessfully()
        {
            //Get the test data from the excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(ExcelPath, "Profile");
            string testCertificate = GlobalDefinitions.ExcelLib.ReadData(2, "Certificate");
            string testCertifiedFrom = GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedFrom");
            string testYear = GlobalDefinitions.ExcelLib.ReadData(2, "Year");

            // Assert the newly added description on profile
            string newCertificate = certificationObj.GetCertificate();
            string newCertificationFrom = certificationObj.GetCertificationFrom();
            string newCertificationYear = certificationObj.GetCertificationYear();
            
            // Assertion 1: Compare actual data with test data, if matched, test passed, else, test failed
            Assert.That(newCertificate == testCertificate, "Actual data and test data are not matched");
            Assert.That(newCertificationFrom == testCertifiedFrom, "Actual data and test data are not matched");
            Assert.That(newCertificationYear == testYear, "Actual data and test data are not matched");

            //Get the message from the pop-up alert message
            string newMssage = certificationObj.GetMessage();

            // Assertion 2: If the actual message contains test data, test passed, else, test failed
            Assert.That(newMssage == testCertificate + " " + "has been added to your certification", "Experted alert message and actual message do not match.");
        }

        [When(@"I delete a certificaite")]
        public void WhenIDeleteACertificaite()
        {
            certificationObj.DeleteCertificate();
        }

        [Then(@"The certificate should be deleted successfully")]
        public void ThenTheCertificateShouldBeDeletedSuccessfully()
        {

            //Get the test data from the excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(ExcelPath, "Profile");
            string testCertificate = GlobalDefinitions.ExcelLib.ReadData(3, "Certificate");

            // Assert the newly added description on profile
            string actualCertificate = certificationObj.GetCertificate();

            // Assertion 1: Compare actual data with test data, if NOT matched, test passed, else, test failed
            Assert.That(actualCertificate != testCertificate, "Actual data and test data are not matched");

            //Get the message from the pop-up alert message
            string newMssage = certificationObj.GetMessage();

            // Assertion 2: If the actual message contains test data, test passed, else, test failed
            Assert.That(newMssage == testCertificate + " " + "has been deleted from your certification", "Experted alert message and actual message do not match.");
        }

        [When(@"I click button Edit '([^']*)'")]
        public void WhenIClickButtonEdit(string certificate1)
        {
            certificationObj.ClickEdit(certificate1);
        }

        [When(@"I edit a '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIEditA(string certificate2, string from, string year)
        {
            certificationObj.EditCertificate(certificate2, from, year);
        }

        [Then(@"The existing certificate is edited as '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenTheExistingCertificateIsEditedAs(string certificate2, string from, string year)
        {
            //Check message
            string assertMessage = certificate2 + " has been updated to your certification";
            string message = certificationObj.GetMessage();
            Assert.That(message == assertMessage, "Actual message and Expected message do not match.");

            //Check certifcate
            string assertCertificate = certificationObj.GetCertificate(certificate2);
            Assert.That(assertCertificate == certificate2, "Actual certificate and Expected certificate do not match.");

            //check certification form
            string editedCertificationFrom = certificationObj.GetCertificationFrom();
            Assert.That(editedCertificationFrom == from, "Actual certifier and Expected certifier do not match.");

            //check certification year
            string editedYear = certificationObj.GetCertificationYear();
            Assert.That(editedYear == year, "Actual certification year and Expected certification year do not match.");
        }


    }
}
