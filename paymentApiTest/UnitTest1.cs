using NUnit.Framework;
using paymentApi.dal.ExpensivePaymentGateway;
using paymentApi.dal.CheapPaymentGateway;
using paymentApi.domain;
using Moq;
using paymentApi.bl;
using System.Text.Json;

namespace paymentApiTest
{
    [TestFixture]
    public class Tests
    {

        private Mock<ICheapPaymentGateway> _cheapPaymentGateway;
        private Mock<IExpensivePaymentGateway> _expensivePaymentGateway;
        [SetUp]
        public void Setup()
        {
            _cheapPaymentGateway = new Mock<ICheapPaymentGateway>();

            _expensivePaymentGateway = new Mock<IExpensivePaymentGateway>();
        }

        [Test,TestCaseSource("paymentInfo")]
        public void Test1(PaymentData paymentInfo)
        {
            PaymentBl bl = new PaymentBl(_cheapPaymentGateway.Object, _expensivePaymentGateway.Object);
           var result= bl.processData(paymentInfo);

            Assert.Pass();
        }

        private static object[] paymentInfo =
        {
            JsonSerializer.Deserialize<PaymentData>(@"paymentApiTest/sample.json")
        };
    }
}
