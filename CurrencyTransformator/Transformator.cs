using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyExtractor.Models;
using CurrencyTransformator.Models;

namespace CurrencyTransformator
{
    public static class Transformator
    {
        public static FinalOutput TransformToOutput(CurrencyExtractor.Models.MediatedSchema mediated)
        {
            FinalOutput output = new FinalOutput();

            output.Currency = mediated.API.@base;
            output.Date = mediated.API.date;
            output.TargetCurrencies = new RatesFinal();

            output.TargetCurrencies.CAD = Average(mediated.API.rates.CAD, mediated.APIV4.rates.CAD);
            output.TargetCurrencies.HKD = Average(mediated.API.rates.HKD, mediated.APIV4.rates.HKD);
            output.TargetCurrencies.ISK = Average(mediated.API.rates.ISK, mediated.APIV4.rates.ISK);
            output.TargetCurrencies.PHP = Average(mediated.API.rates.PHP, mediated.APIV4.rates.PHP);
            output.TargetCurrencies.DKK = Average(mediated.API.rates.DKK, mediated.APIV4.rates.DKK);
            output.TargetCurrencies.HUF = Average(mediated.API.rates.HUF, mediated.APIV4.rates.HUF);
            output.TargetCurrencies.CZK = Average(mediated.API.rates.CZK, mediated.APIV4.rates.CZK);
            output.TargetCurrencies.GBP = Average(mediated.API.rates.GBP, mediated.APIV4.rates.GBP);
            output.TargetCurrencies.RON = Average(mediated.API.rates.RON, mediated.APIV4.rates.RON);
            output.TargetCurrencies.SEK = Average(mediated.API.rates.SEK, mediated.APIV4.rates.SEK);
            output.TargetCurrencies.IDR = Average(mediated.API.rates.IDR, mediated.APIV4.rates.IDR);
            output.TargetCurrencies.INR = Average(mediated.API.rates.INR, mediated.APIV4.rates.INR);
            output.TargetCurrencies.BRL = Average(mediated.API.rates.BRL, mediated.APIV4.rates.BRL);
            output.TargetCurrencies.RUB = Average(mediated.API.rates.RUB, mediated.APIV4.rates.RUB);
            output.TargetCurrencies.HRK = Average(mediated.API.rates.HRK, mediated.APIV4.rates.HRK);
            output.TargetCurrencies.JPY = Average(mediated.API.rates.JPY, mediated.APIV4.rates.JPY);
            output.TargetCurrencies.THB = Average(mediated.API.rates.THB, mediated.APIV4.rates.THB);
            output.TargetCurrencies.CHF = Average(mediated.API.rates.CHF, mediated.APIV4.rates.CHF);
            output.TargetCurrencies.EUR = Average(mediated.API.rates.EUR, mediated.APIV4.rates.EUR);
            output.TargetCurrencies.MYR = Average(mediated.API.rates.MYR, mediated.APIV4.rates.MYR);
            output.TargetCurrencies.BGN = Average(mediated.API.rates.BGN, mediated.APIV4.rates.BGN);
            output.TargetCurrencies.TRY = Average(mediated.API.rates.TRY, mediated.APIV4.rates.TRY);
            output.TargetCurrencies.CNY = Average(mediated.API.rates.CNY, mediated.APIV4.rates.CNY);
            output.TargetCurrencies.NOK = Average(mediated.API.rates.NOK, mediated.APIV4.rates.NOK);
            output.TargetCurrencies.NZD = Average(mediated.API.rates.NZD, mediated.APIV4.rates.NZD);
            output.TargetCurrencies.ZAR = Average(mediated.API.rates.ZAR, mediated.APIV4.rates.ZAR);
            output.TargetCurrencies.USD = Average(mediated.API.rates.USD, mediated.APIV4.rates.USD);
            output.TargetCurrencies.MXN = Average(mediated.API.rates.MXN, mediated.APIV4.rates.MXN);
            output.TargetCurrencies.SGD = Average(mediated.API.rates.SGD, mediated.APIV4.rates.SGD);
            output.TargetCurrencies.AUD = Average(mediated.API.rates.AUD, mediated.APIV4.rates.AUD);
            output.TargetCurrencies.ILS = Average(mediated.API.rates.ILS, mediated.APIV4.rates.ILS);
            output.TargetCurrencies.KRW = Average(mediated.API.rates.KRW, mediated.APIV4.rates.KRW);
            output.TargetCurrencies.PLN = Average(mediated.API.rates.PLN, mediated.APIV4.rates.PLN);

            return output;
        }

        private static double Average(double a, double b)
        {
            return (a + b) / 2;
        }
    }
}
