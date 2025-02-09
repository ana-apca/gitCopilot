using System;
using System.Collections.Generic;

namespace ReportGenerator
{
    class QuarterlyIncomeReport
    {
        static void Main(string[] args)
        {
           static void Main(string[] args)
{
    // create a new instance of the class
    QuarterlyIncomeReport report = new QuarterlyIncomeReport();



    // call the GenerateSalesData method
    SalesData[] salesData = report.GenerateSalesData();

    // call the QuarterlySalesReport method
    report.QuarterlySalesReport(salesData);
}
        }

        public void QuarterlySalesReport(SalesData[] salesData)
        {
            Dictionary<string, double> quarterlySalesDict = new Dictionary<string, double>
            {
                { "Q1", 0 },
                { "Q2", 0 },
                { "Q3", 0 },
                { "Q4", 0 }
            };

            foreach (var sale in salesData)
            {
                double saleValue = sale.quantitySold * sale.unitPrice;
                string quarterKey = GetQuarter(sale.dateSold.Month);
                quarterlySalesDict[quarterKey] += saleValue;
            }

            Console.WriteLine("Quarterly Sales Report");
            Console.WriteLine("----------------------");
            foreach (var quarter in quarterlySalesDict)
            {
                Console.WriteLine($"{quarter.Key}: {quarter.Value:C}");
            }
        }

        public string GetQuarter(int month)
        {
            if (month >= 1 && month <= 3)
            {
                return "Q1";
            }
            else if (month >= 4 && month <= 6)
            {
                return "Q2";
            }
            else if (month >= 7 && month <= 9)
            {
                return "Q3";
            }
            else
            {
                return "Q4";
            }
        }

        // public struct SalesData. Include the following fields: date sold, department name, product ID, quantity sold, unit price
        public struct SalesData
        {
            public DateOnly dateSold;
            public string departmentName;
            public int productID;
            public int quantitySold;
            public double unitPrice;
        }

        public SalesData[] GenerateSalesData()
        {
            SalesData[] salesData = new SalesData[1000];
            Random random = new Random();

            for (int i = 0; i < salesData.Length; i++)
            {
                salesData[i].dateSold = new DateOnly(2023, random.Next(1, 13), random.Next(1, 29));
                salesData[i].departmentName = "Department " + random.Next(1, 11);
                salesData[i].productID = random.Next(1, 101);
                salesData[i].quantitySold = random.Next(1, 101);
                salesData[i].unitPrice = random.NextDouble() * 100;
            }

            return salesData;
        }
    }
}