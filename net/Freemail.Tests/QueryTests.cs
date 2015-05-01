using NUnit.Framework;

namespace Freemail.Tests
{
	public class QueryTests
	{

		[TestCase("test@gmail.com", true)]
		[TestCase("test@mailinater.com", true)]
		[TestCase("test@randomdomain.com", false)]
		public void IsFreeTests(string email, bool expectedResult)
		{
			Assert.AreEqual(Freemail.Queries.IsFree(email), expectedResult);
		}

		[TestCase("test@mailinater.com", true)]
		[TestCase("test@gmail.com", false)]
		public void IsDisposableTests(string email, bool expectedResult)
		{
			Assert.AreEqual(Freemail.Queries.IsDisposable(email), expectedResult);
		}
	}
}
