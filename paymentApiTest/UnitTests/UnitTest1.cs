using NUnit.Framework;
using paymentApi.dal.ExpensivePaymentGateway;
using paymentApi.dal.CheapPaymentGateway;
using paymentApi.domain;
using Moq;
using paymentApi.bl;
using System.IO;
using Newtonsoft.Json;

namespace paymentApiTest
{

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

        [Test]
        public void TestApi()
        {
            PaymentBl bl = new PaymentBl(_cheapPaymentGateway.Object, _expensivePaymentGateway.Object);
            PaymentResponse paymentResponse;
            PaymentData paymentInfo;
            using (StreamReader r = new StreamReader(@"C:\Users\Trinita\source\repos\paymentApi\paymentApiTest\UnitTests\paymentResponse.json"))
            {
                string json = r.ReadToEnd();
                paymentResponse = JsonConvert.DeserializeObject<PaymentResponse>(json);
            }

            using (StreamReader r = new StreamReader(@"C:\Users\Trinita\source\repos\paymentApi\paymentApiTest\UnitTests\paymentData.json"))
            {
                string json = r.ReadToEnd();
                paymentInfo = JsonConvert.DeserializeObject<PaymentData>(json);
            }


            _cheapPaymentGateway.Setup(x => x.processPayment(paymentInfo)).Returns(paymentResponse);
            var result = bl.processData(paymentInfo);

            Assert.AreEqual("Success", result.Result.Status);
        }
    }
}
