using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumHW
{
    internal class Program
    {
        enum DayOfWeekEnum
        {
            monday = 1,
            tuesday = 2,
            wednesday = 3,
            thursday = 4,
            friday = 5,
            saturday = 6,
            sunday = 7
        }
        class Date
        {
            private DateTime dateTime = DateTime.Now;
            private int year;
            private int month;
            private int day;
            public int Year 
            { 
                get { return year; } 
                set
                {
                    if(value <= 1970 || value > dateTime.Year)
                    {
                        throw new Exception("Ошибка! Неверный год.");
                    }
                    else 
                    { 
                        year = value; 
                    }
                }
            }
            public int Month
            {
                get { return month; }
                set
                {
                    if(value < 1 || value > 12)
                    {
                        throw new Exception("Ошибка! Неверный месяц.");
                    }
                    else
                    {
                        month = value;
                    }
                }
            }
            public int Day
            {
                get { return day; }
                set
                {
                    if(value < 1 || value > 31)
                    {
                        throw new Exception("Ошибка! Неверный день.");
                    }
                    else
                    {
                        day = value;
                    }
                }
            }

            public void check()
            {
                bool leapYear = false;
                if (year % 4 == 0)
                {
                    leapYear = true;
                }
                //Пятница
                if ((month == 2 && day == 29 && !leapYear) || (month == 2 && day == 30) || (month == 2 && day == 31))
                {
                    throw new Exception("Неверная дата!");
                }
                //Апрель,Июль,Сентябрь,Ноябрь
                if ((month == 4 && day == 31) || (month == 6 && day == 31) || (month == 9 && day == 31) || (month == 11 && day == 31))
                {
                    throw new Exception("Неверная дата!");
                }
            }
            public void dayOfWeek()
            {
                DateTime timeToWorkWith = new DateTime(year, month, day);
                int dayCheck = (int)timeToWorkWith.DayOfWeek;
                switch (dayCheck)
                {
                    case (int)DayOfWeekEnum.monday:
                        Console.WriteLine("Сегодня понедельник");
                        break;
                    case (int)DayOfWeekEnum.tuesday:
                        Console.WriteLine("Сегодня вторник");
                        break;
                    case (int)DayOfWeekEnum.wednesday:
                        Console.WriteLine("Сегодня среда");
                        break;
                    case (int)DayOfWeekEnum.thursday:
                        Console.WriteLine("Сегодня четверг");
                        break;
                    case (int)DayOfWeekEnum.friday:
                        Console.WriteLine("Сегодня пятница");
                        break;
                    case (int)DayOfWeekEnum.saturday:
                        Console.WriteLine("Сегодня суббота");
                        break;
                    case (int)DayOfWeekEnum.sunday:
                        Console.WriteLine("Сегодня воскресенье");
                        break;
                    default: break;
                }
            }

        }
        static void Main(string[] args)
        {
            try
            {
                Date date = new Date();
                Console.WriteLine("Введите дату в формате DD.MM.YYYY(даты позднее 01.01.1970 - не принимаются): ");
                string answer = Console.ReadLine();
                string[] split = answer.Split('.');
                date.Day = int.Parse(split[0]);
                date.Month = int.Parse(split[1]);
                date.Year = int.Parse(split[2]);
                date.check();
                date.dayOfWeek();
            }
            catch (Exception e)
            {

                Console.WriteLine("Ошибка пользователя: {0}", e.Message);
            }
            

        }
    }
}
