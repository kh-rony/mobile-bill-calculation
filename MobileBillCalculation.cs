//
// Start time: 2019-08-31 08:59:13 am
// End time: 2019-08-31 09:00:39 am
//

using System;

namespace MobileBillCalculation
{
    internal class MobileBillCalculation
    {
        public bool isPeak(int timePoint)
        {
            int peakSecondsStart = 60 * 60 * 9;
            int peakSecondsEnd = (60 * 60 * 10) + (60 * 59) + 59;

            if ( timePoint >= peakSecondsEnd && timePoint <= peakSecondsEnd )
            {
                return true;
            }

            return false;
        }
        public int calculateToralMobileBill(string startDateTime, string endDateTime)
        {
            Console.Out.WriteLine(startDateTime);
            Console.Out.WriteLine(endDateTime);

            string[] startDateTimeSplits = startDateTime.Split(' ');
            string startDate = startDateTimeSplits[2];
            string startTime = startDateTimeSplits[3];
            bool startTimeIsPM = string.Equals("pm", startDateTimeSplits[3]);
            
            string[] splittedParts = startDate.Split('-');
            int startYear = Convert.ToInt32(splittedParts[0]);
            int startMonth = Convert.ToInt32(splittedParts[1]);
            int startDay = Convert.ToInt32(splittedParts[2]);
            Array.Clear(splittedParts, 0, splittedParts.Length);
            
            splittedParts = startTime.Split(':');
            int startHour = Convert.ToInt32(splittedParts[0]);
            int startMinute = Convert.ToInt32(splittedParts[1]);
            int startSecond = Convert.ToInt32(splittedParts[2]);
            Array.Clear(splittedParts, 0, splittedParts.Length);
            if (startTimeIsPM)
            {
                startHour += 12;
            }
            if (!startTimeIsPM && startHour == 12)
            {
                startHour = 0;
            }
            
            
            string[] endDateTimeSplits = endDateTime.Split(' ');
            string endDate = endDateTimeSplits[2];
            string endTime = endDateTimeSplits[3];
            bool endTimeIsPM = string.Equals("pm", endDateTimeSplits[3]);
            
            splittedParts = endDate.Split('-');
            int endYear = Convert.ToInt32(splittedParts[0]);
            int endMonth = Convert.ToInt32(splittedParts[1]);
            int endDay = Convert.ToInt32(splittedParts[2]);
            Array.Clear(splittedParts, 0, splittedParts.Length);
            
            splittedParts = endTime.Split(':');
            int endHour = Convert.ToInt32(splittedParts[0]);
            int endMinute = Convert.ToInt32(splittedParts[1]);
            int endSecond = Convert.ToInt32(splittedParts[2]);
            Array.Clear(splittedParts, 0, splittedParts.Length);
            if (endTimeIsPM)
            {
                endHour += 12;
            }
            if (!endTimeIsPM && endHour == 12)
            {
                endHour = 0;
            }

            int startPoint = startSecond + (60 * startMinute) + (60 * 60 * startHour);
            int endPoint = endSecond + (60 * endMinute) + (60 * 60 * endHour);
            
            
            int totalBill = 0;
            bool billCalculationDone = false;
            bool pulseStartisPeak = false;
            bool pulseStopisPeak = false;
            
            while( !billCalculationDone )
            {
                pulseStartisPeak = this.isPeak(startPoint);
                startPoint += 20;
                pulseStopisPeak = this.isPeak(startPoint);

                if ( pulseStartisPeak || pulseStopisPeak )
                {
                    totalBill += 30;
                }
                else
                {
                    totalBill += 20;
                }

                if ( startPoint >= endPoint )
                {
                    billCalculationDone = true;
                }
            }
            
            return totalBill;
        }
        
        public static void Main(string[] args)
        {
            Console.Out.WriteLine("Mobile Bill Calculation");
            
            string startDateTime = "";
            string endDateTime = "";
            
            startDateTime = Console.ReadLine();
            endDateTime= Console.ReadLine();
            // string startDateTime = "Start time: 2019-08-31 08:59:13 am";
            // string endDateTime= "End time: 2019-08-31 09:00:39 am";

            int billPaisa = new MobileBillCalculation().calculateToralMobileBill(startDateTime, endDateTime);

            double billTaka = ((double) billPaisa / 100.0);
            Console.Out.WriteLine(billPaisa + " taka");
        }
    }
}