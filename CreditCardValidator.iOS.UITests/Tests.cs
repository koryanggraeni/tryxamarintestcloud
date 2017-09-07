using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace CreditCardValidator.iOS.UITests
{
	[TestFixture]
	public class Tests
	{
		iOSApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			app = ConfigureApp.iOS.StartApp();
		}

		[Test]
		public void CreditCardNumber_TooShort_DisplayErrorMessage()
		{
			app.WaitForElement(c => c.Class("UINavigationBar").Marked("Simple Credit Card Validator"), "Then I wait the application are opened");
			app.EnterText(c => c.Class("UITextField"), new string('9', 15));
			app.Tap(c => c.Marked("Validate Credit Card").Class("UIButton"));

			app.WaitForElement(c => c.Marked("Credit card number is too short.").Class("UILabel"));
		}

		[Test]
		public void CreditCardNumber_TooLong_DisplayErrorMessage()
		{
			app.WaitForElement(c => c.Class("UINavigationBar").Marked("Simple Credit Card Validator"));
			app.EnterText(c => c.Class("UITextField"), new string('9', 20));
			app.Tap(c => c.Marked("Validate Credit Card").Class("UIButton"));

			app.WaitForElement(c => c.Marked("Credit card number is too long.").Class("UILabel"));
		}

		[Test]
		public void CreditCardNumber_NotCreditCardNUmber_DisplayErrorMessage()
		{
			app.WaitForElement(c => c.Class("UINavigationBar").Marked("Simple Credit Card Validator"));
			app.EnterText(c => c.Class("UITextField"), new string(' ', 16));
			app.Tap(c => c.Marked("Validate Credit Card").Class("UIButton"));

			app.WaitForElement(c => c.Marked("This is not a credit card number.").Class("UILabel"));
		}

		[Test]
		public void CreditCardNumber_ValidCreditCardNumber_DisplaySuccessMessage()
		{ 
			app.WaitForElement(c => c.Class("UINavigationBar").Marked("Simple Credit Card Validator"));
			app.EnterText(c => c.Class("UITextField"), new string('9', 16));
			app.Tap(c => c.Marked("Validate Credit Card").Class("UIButton"));

			app.WaitForElement(c => c.Marked("The credit card number is valid!").All());
		}

		[Test]
		public void AppLaunches()
		{
			app.Screenshot("First Screen.");
			app.Repl();

		}
	}
}


