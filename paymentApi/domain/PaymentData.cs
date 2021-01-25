using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace paymentApi.domain
{
    [BindProperties]
    public class PaymentData
    {
        private string _creditCardNumber;
        private string _cardHolder;
        private DateTime _expirationDate;
        private float _amount;
        public string creditCardNumber
        {
            get
            {
                return this._creditCardNumber;
            }

            set
            {
                this._creditCardNumber = /*!isValid(Convert.ToInt64(value)) ? throw new Exception("Credit Card Numberis is invalid") : */value;

            }
        }
        public string cardHolder
        {
            get
            {
                return this._cardHolder;
            }

            set
            {
                this._cardHolder = value;
            }
        }
        public DateTime expirationDate
        {
            get
            {
                return this._expirationDate;
            }

            set
            {
                    this._expirationDate = value < DateTime.Now? throw new Exception("The credit card has passed the expiration data"):value;
            }
        }
        public int? securityCode { get; set; }

        public float amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                this._amount = value <= 0 ? throw new Exception("Amount should be a postive value") : value;
            }
        }
        public static bool isValid(long number)

        {

            return (getSize(number) >= 13 &&

                    getSize(number) <= 16) &&

                    (prefixMatched(number, 4) ||

                     prefixMatched(number, 5) ||

                     prefixMatched(number, 37) ||

                     prefixMatched(number, 6)) &&

                   ((sumOfDoubleEvenPlace(number) +

                     sumOfOddPlace(number)) % 10 == 0);

        }


        public static int sumOfDoubleEvenPlace(long number)

        {

            int sum = 0;

            String num = number + "";

            for (int i = getSize(number) - 2; i >= 0; i -= 2)

                sum += getDigit(int.Parse(num[i] + "") * 2);
            return sum;
        }

        public static int getDigit(int number)
        {

            if (number < 9)

                return number;

            return number / 10 + number % 10;

        }



        // Return sum of odd-place digits in number 

        public static int sumOfOddPlace(long number)
        {

            int sum = 0;

            String num = number + "";

            for (int i = getSize(number) - 1; i >= 0; i -= 2)

                sum += int.Parse(num[i] + "");

            return sum;

        }



        // Return true if the digit d is a prefix for number 

        public static bool prefixMatched(long number, int d)
        {
            return getPrefix(number, getSize(d)) == d;
        }



        // Return the number of digits in d 

        public static int getSize(long d)

        {

            String num = d + "";

            return num.Length;

        }



        // Return the first k number of digits from  

        // number. If the number of digits in number 

        // is less than k, return number. 

        public static long getPrefix(long number, int k)

        {

            if (getSize(number) > k)
            {

                String num = number + "";

                return long.Parse(num.Substring(0, k));

            }

            return number;

        }
    }
}
