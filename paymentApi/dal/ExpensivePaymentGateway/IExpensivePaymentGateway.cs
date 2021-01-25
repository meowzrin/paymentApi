using paymentApi.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace paymentApi.dal.ExpensivePaymentGateway
{
    public interface IExpensivePaymentGateway
    {
        Task<PaymentResponse> processPayment(PaymentData paymentInfo);
    }
}
