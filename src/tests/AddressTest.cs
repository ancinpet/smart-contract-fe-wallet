using System;
using Xunit;
using static thesis_wallet.Pages.Index;

namespace tests
{
    public class AddressTest
    {
        [Fact]
        public void TestAddressCheck() {
            Assert.False(DasContractMenu.IsValidAddress(""));
            Assert.False(DasContractMenu.IsValidAddress("0x0"));
            Assert.False(DasContractMenu.IsValidAddress("0x00000000000"));
            Assert.False(DasContractMenu.IsValidAddress("0xdasdasdas"));
            Assert.False(DasContractMenu.IsValidAddress("0x1234657897465"));
            Assert.False(DasContractMenu.IsValidAddress("0x07cb10c24ebe643b4c4d2db77dca15baa1544c5eb"));
            Assert.False(DasContractMenu.IsValidAddress("07ab9c24ebe643b4c4d2db77dca15baa1544c5eb"));
            Assert.False(DasContractMenu.IsValidAddress("0xghab9c24ebe643b4c4d2db77dca15baa1544c5eb"));
            Assert.True(DasContractMenu.IsValidAddress("0x07ab9c24ebe643b4c4d2db77dca15baa1544c5eb"));
            Assert.True(DasContractMenu.IsValidAddress("0x0e3918efec28549af51a80f7776d0a75783083ec"));
            Assert.True(DasContractMenu.IsValidAddress("0x20b6346742aa2a86cb8f52a6ff77e0704773008f"));
            Assert.True(DasContractMenu.IsValidAddress("0x0000000000000000000000000000000000000000"));
        }
    }
}
