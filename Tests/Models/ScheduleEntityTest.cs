using GymWebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebAPI.Tests.Models
{
    [TestClass]
    public class ScheduleEntityTest : TestBaseClass<ScheduleEntity>
    {
        [TestClass]
        public class ValidateHourFormatProperty : ScheduleEntityTest
        {

            [TestMethod]
            public void Check_9_Hour_00_Minutes_Schedule_Format()
            {
                var hours = "09:00 Hs";
                Target = new ScheduleEntity(DayOfWeek.Monday, 9, 0);
                Assert.AreEqual(hours, Target.HourFormat);
            }

            [TestMethod]
            public void Check_10_Hour_00_Minute_Schedule_Format()
            {
                var hours = "10:00 Hs";
                Target = new ScheduleEntity(DayOfWeek.Monday, 10, 0);
                Assert.AreEqual(hours, Target.HourFormat);
            }
        }

    }
}
