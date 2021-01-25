﻿using paymentApi.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace paymentApi.dal.CheapPaymentGateway
{
    public interface ICheapPaymentGateway
    {
        Task<PaymentResponse> processPayment(PaymentData paymentInfo);
    }
}
