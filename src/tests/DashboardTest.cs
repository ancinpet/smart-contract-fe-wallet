using System;
using Xunit;
using static thesis_wallet.Pages.DashBoard;

namespace tests
{
    public class DashboardTest
    {
        [Fact]
        public void TestDashboard() {
            DashBoardItem dashboard = new DashBoardItem(null, "test", 8, new DateTime(0));
            Assert.True(dashboard.TimeLeft() == "Never");

            dashboard = new DashBoardItem(null, "test", 8, DateTime.Now.AddMinutes(-10));
            Assert.Contains("Overdue", dashboard.TimeLeft());

            dashboard = new DashBoardItem(null, "test", 8, DateTime.Now.AddMinutes(-10));
            Assert.Contains("Overdue", dashboard.TimeLeft());

            dashboard = new DashBoardItem(null, "test", 8, DateTime.Now.AddMinutes(10));
            Assert.Contains("minutes", dashboard.TimeLeft());

            dashboard = new DashBoardItem(null, "test", 8, DateTime.Now.AddMinutes(1));
            Assert.Contains("minute", dashboard.TimeLeft());
            Assert.DoesNotContain("hour", dashboard.TimeLeft());
            Assert.DoesNotContain("day", dashboard.TimeLeft());

            dashboard = new DashBoardItem(null, "test", 8, DateTime.Now.AddHours(10));
            Assert.Contains("hour", dashboard.TimeLeft());
            Assert.Contains("and", dashboard.TimeLeft());
            Assert.Contains("minute", dashboard.TimeLeft());

            dashboard = new DashBoardItem(null, "test", 8, DateTime.Now.AddDays(10));
            Assert.Contains("day", dashboard.TimeLeft());
            Assert.Contains("and", dashboard.TimeLeft());
            Assert.Contains("hour", dashboard.TimeLeft());
            Assert.DoesNotContain("minute", dashboard.TimeLeft());

            dashboard = new DashBoardItem(null, "test", 8, DateTime.Now.AddDays(100));
            Assert.Contains("day", dashboard.TimeLeft());
            Assert.DoesNotContain("hour", dashboard.TimeLeft());
        }
    }
}
