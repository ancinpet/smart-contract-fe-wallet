using System;
using Xunit;
using static thesis_wallet.Pages.Index;

namespace tests
{
    public class ViewBindTest
    {
        [Fact]
        public void TestViewBindParsing()
        {
            DasContractMenu menu = new DasContractMenu();
            ViewToken parsed = menu.TokenizeCall("isCompleted");
            Assert.True(parsed.FuncName == "isCompleted");
            Assert.True(parsed.Index == -1);
            Assert.True(parsed.Parameters.Count == 0);
            Assert.True(parsed.Property == "");

            parsed = menu.TokenizeCall("isCompleted()");
            Assert.True(parsed.FuncName == "isCompleted");
            Assert.True(parsed.Index == -1);
            Assert.True(parsed.Parameters.Count == 0);
            Assert.True(parsed.Property == "");

            parsed = menu.TokenizeCall("mortgage.propertyPrice");
            Assert.True(parsed.FuncName == "mortgage");
            Assert.True(parsed.Index == -1);
            Assert.True(parsed.Parameters.Count == 0);
            Assert.True(parsed.Property == "propertyPrice");

            parsed = menu.TokenizeCall("mortgage().propertyPrice");
            Assert.True(parsed.FuncName == "mortgage");
            Assert.True(parsed.Index == -1);
            Assert.True(parsed.Parameters.Count == 1);
            Assert.True(parsed.Parameters[0] == "");
            Assert.True(parsed.Property == "propertyPrice");

            parsed = menu.TokenizeCall("mortgage.deposits[0]");
            Assert.True(parsed.FuncName == "mortgage");
            Assert.True(parsed.Index == 0);
            Assert.True(parsed.Parameters.Count == 0);
            Assert.True(parsed.Property == "deposits");

            parsed = menu.TokenizeCall("mortgage.deposits");
            Assert.True(parsed.FuncName == "mortgage");
            Assert.True(parsed.Index == -1);
            Assert.True(parsed.Parameters.Count == 0);
            Assert.True(parsed.Property == "deposits");

            parsed = menu.TokenizeCall("getDownPayment().amount");
            Assert.True(parsed.FuncName == "getDownPayment");
            Assert.True(parsed.Index == -1);
            Assert.True(parsed.Parameters.Count == 1);
            Assert.True(parsed.Parameters[0] == "");
            Assert.True(parsed.Property == "amount");

            parsed = menu.TokenizeCall("getDownPayment.amount");
            Assert.True(parsed.FuncName == "getDownPayment");
            Assert.True(parsed.Index == -1);
            Assert.True(parsed.Parameters.Count == 0);
            Assert.True(parsed.Property == "amount");

            parsed = menu.TokenizeCall("getDeposit(0, true)");
            Assert.True(parsed.FuncName == "getDeposit");
            Assert.True(parsed.Index == -1);
            Assert.True(parsed.Parameters.Count == 2);
            Assert.True(parsed.Parameters[0] == "0");
            Assert.True(parsed.Parameters[1] == "true");
            Assert.True(parsed.Property == "");

            parsed = menu.TokenizeCall("getDeposit(0, false)");
            Assert.True(parsed.FuncName == "getDeposit");
            Assert.True(parsed.Index == -1);
            Assert.True(parsed.Parameters.Count == 2);
            Assert.True(parsed.Parameters[0] == "0");
            Assert.True(parsed.Parameters[1] == "false");
            Assert.True(parsed.Property == "");

            parsed = menu.TokenizeCall("getDeposit(0, false, list).payments[1]");
            Assert.True(parsed.FuncName == "getDeposit");
            Assert.True(parsed.Index == 1);
            Assert.True(parsed.Parameters.Count == 3);
            Assert.True(parsed.Parameters[0] == "0");
            Assert.True(parsed.Parameters[1] == "false");
            Assert.True(parsed.Parameters[2] == "list");
            Assert.True(parsed.Property == "payments");
        }
    }
}
