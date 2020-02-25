using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsxScraper
{
    class DataPoint
    {
        public DataPoint()
        {
        }

        public DataPoint(string code, string isinCode, string descFull, float lastPrice, float openPrice, float dayHighPrice, float dayLowPrice, float changePrice, string changeInPercent, long volume, float bidPrice, float offerPrice, float previousClosePrice, string previousDayPercentageChange, float yearHighPrice, DateTime lastTradeDate, DateTime yearHighDate, float yearLowPrice, DateTime yearLowDate, float yearOpenPrice, DateTime yearOpenDate, float yearChangePrice, string yearChangeInPercentage, float pe, float eps, long averageDailyVolume, float annualDividendYield, double marketCap, long numberOfShares, bool suspended, string industry, string sector, string mailingAddress)
        {
            DataPointDate = DateTime.Now;
            Code = code;
            IsinCode = isinCode;
            DescFull = descFull;
            LastPrice = lastPrice;
            OpenPrice = openPrice;
            DayHighPrice = dayHighPrice;
            DayLowPrice = dayLowPrice;
            ChangePrice = changePrice;
            ChangeInPercent = changeInPercent;
            Volume = volume;
            BidPrice = bidPrice;
            OfferPrice = offerPrice;
            PreviousClosePrice = previousClosePrice;
            PreviousDayPercentageChange = previousDayPercentageChange;
            YearHighPrice = yearHighPrice;
            LastTradeDate = lastTradeDate;
            YearHighDate = yearHighDate;
            YearLowPrice = yearLowPrice;
            YearLowDate = yearLowDate;
            YearOpenPrice = yearOpenPrice;
            YearOpenDate = yearOpenDate;
            YearChangePrice = yearChangePrice;
            YearChangeInPercentage = yearChangeInPercentage;
            PE = pe;
            EPS = eps;
            AverageDailyVolume = averageDailyVolume;
            AnnualDividendYield = annualDividendYield;
            MarketCap = marketCap;
            NumberOfShares = numberOfShares;
            Suspended = suspended;
            Industry = industry;
            Sector = sector;
            MailingAddress = MailingAddress;
        }

        public DateTime DataPointDate
        {
            get; set;
        }
        public string Code
        {
            get; set;
        }
        public string IsinCode
        {
            get; set;
        }
        public string DescFull
        {
            get; set;
        }
        public float LastPrice
        {
            get; set;
        }
        public float OpenPrice
        {
            get; set;
        }
        public float DayHighPrice
        {
            get; set;
        }
        public float DayLowPrice
        {
            get; set;
        }
        public float ChangePrice
        {
            get; set;
        }
        public string ChangeInPercent
        {
            get; set;
        }
        public long Volume
        {
            get; set;
        }
        public float BidPrice
        {
            get; set;
        }
        public float OfferPrice
        {
            get; set;
        }
        public float PreviousClosePrice
        {
            get; set;
        }
        public string PreviousDayPercentageChange
        {
            get; set;
        }
        public float YearHighPrice
        {
            get; set;
        }
        public DateTime LastTradeDate
        {
            get; set;
        }
        public DateTime YearHighDate
        {
            get; set;
        }
        public float YearLowPrice
        {
            get; set;
        }
        public DateTime YearLowDate
        {
            get; set;
        }
        public float YearOpenPrice
        {
            get; set;
        }
        public DateTime YearOpenDate
        {
            get; set;
        }
        public float YearChangePrice
        {
            get; set;
        }
        public string YearChangeInPercentage
        {
            get; set;
        }
        public float PE
        {
            get; set;
        }
        public float EPS
        {
            get; set;
        }
        public long AverageDailyVolume
        {
            get; set;
        }
        public float AnnualDividendYield
        {
            get; set;
        }
        public double MarketCap
        {
            get; set;
        }
        public long NumberOfShares
        {
            get; set;
        }
        public bool Suspended
        {
            get; set;
        }
        public string Industry
        {
            get; set;
        }
        public string Sector
        {
            get; set;
        }
        public string MailingAddress
        {
            get; set;
        }
    }
}
