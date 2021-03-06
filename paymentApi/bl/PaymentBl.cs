﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using paymentApi.dal.ExpensivePaymentGateway;
using paymentApi.dal.CheapPaymentGateway;
using paymentApi.domain;

namespace paymentApi.bl
{
    public class PaymentBl : IPaymentBl
    {
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;

        public PaymentBl(ICheapPaymentGateway cheapPaymentGateway, IExpensivePaymentGateway expensivePaymentGateway)
        {
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
        }

        public async Task<PaymentResponse> processData(PaymentData paymentInfo)
        {

            int retryAttempts = 0;

            PaymentResponse response = new PaymentResponse();

            if (paymentInfo.amount < 20)
            {
                response =  _cheapPaymentGateway.processPayment(paymentInfo);
                
            }
            else if (paymentInfo.amount > 20 && paymentInfo.amount < 500)
            {
                response =  _cheapPaymentGateway.processPayment(paymentInfo);
                if(response.Status=="Fail")
                {
                    response =  _expensivePaymentGateway.processPayment(paymentInfo);
           
                }
                    
               
            }
            else
            {

                response =  _expensivePaymentGateway.processPayment(paymentInfo);
                while (response.Status == "Fail" && retryAttempts <= 3)
                {
                    response =  _expensivePaymentGateway.processPayment(paymentInfo);
                    retryAttempts++;
                }

            }
            return response;

        }

    }


}
