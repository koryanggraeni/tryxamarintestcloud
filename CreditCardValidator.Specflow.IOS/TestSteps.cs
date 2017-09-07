using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;
using TechTalk.SpecFlow;

namespace CreditCardValidator.Specflow.IOS
{
	[Binding]
	public class TestSteps
	{
		iOSApp app;	

		[Given(@"I open the application")]
		public void GivenIOpenTheApplication()
		{
			app = ConfigureApp.iOS.StartApp();
			app.WaitForElement(c => c.Class("UINavigationBar").Marked("Simple Credit Card Validator"), "Then I wait the application are opened");
		}
			                        
		[Given(@"I input the credit card number with ""(.*)""")]
		public void GivenIInputTheCreditCardNumberWith(string CCNumber)
		{
			app.EnterText(c => c.Class("UITextField"), CCNumber);
		}

		[When(@"I press ""(.*)"" button")]
		public void WhenIPressButton(string buttonName)
		{
			app.Tap(c => c.Marked(buttonName).Class("UIButton"));
		}
		
		[Then(@"the error message should be showing up ""(.*)""")]
		public void ThenTheErrorMessageShouldBeShowingUp(string msg)
		{
			app.WaitForElement(c => c.Marked(msg).Class("UILabel"));  
		}

		[Then(@"the success message should be showing up")]
		public void ThenTheSuccessMessageShouldBeShowingUp()
		{
			app.WaitForElement(c => c.Marked("The credit card number is valid!").All());
		}
	}
}
