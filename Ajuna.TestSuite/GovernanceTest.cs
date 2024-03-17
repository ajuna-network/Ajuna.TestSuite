using Substrate.NetApi.TestNode;

namespace Ajuna.TestSuite
{
    public class GovernanceTest : NodeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetSystemChainTestAsync()
        {
            var result = await _client.SubstrateClient.System.ChainAsync(CancellationToken.None);

            Assert.That(result, Is.EqualTo("Bajun Local Testnet"));
        }

        [Test]
        public async Task GetSystemPropertiesTestAsync()
        {
            var result = await _client.SubstrateClient.System.PropertiesAsync(CancellationToken.None);

            Assert.That(result.Ss58Format, Is.EqualTo(1337));
            Assert.That(result.TokenDecimals, Is.EqualTo(12));
            Assert.That(result.TokenSymbol, Is.EqualTo("BAJU"));
        }
    }
}