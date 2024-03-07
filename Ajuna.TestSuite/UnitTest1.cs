using NUnit.Framework.Interfaces;
using Substrate.NET.Schnorrkel.Keys;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.TestNode;
using System.Security.Principal;

namespace Ajuna.TestSuite
{
    public class BasicTest : NodeTest
    {


        // Secret Key URI `//Alice` is account:
        // Secret seed:      0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a
        // Public key(hex):  0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d
        // Account ID:       0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d
        // SS58 Address:     5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY
        public MiniSecret MiniSecretAlice => new MiniSecret(Utils.HexToByteArray("0xe5be9a5092b81bca64be81d212e7f2f9eba183bb7a90954f7b76361f6edb5c0a"), ExpandMode.Ed25519);

        public Account Alice => Account.Build(KeyType.Sr25519, MiniSecretAlice.ExpandToSecret().ToEd25519Bytes(), MiniSecretAlice.GetPair().Public.Key);

        // Secret Key URI `//Bob` is account:
        // Secret seed:      0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89
        // Public key(hex):  0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48
        // Account ID:       0x8eaf04151687736326c9fea17e25fc5287613693c912909cb226aa4794f26a48
        // SS58 Address:     5FHneW46xGXgs5mUiveU4sbTyGBzmstUspZC92UhjJM694ty
        public MiniSecret MiniSecretBob => new MiniSecret(Utils.HexToByteArray("0x398f0c28f98885e046333d4a41c19cee4c37368a9832c6502f6cfd182e2aef89"), ExpandMode.Ed25519);
        public Account Bob => Account.Build(KeyType.Sr25519, MiniSecretBob.ExpandToSecret().ToEd25519Bytes(), MiniSecretBob.GetPair().Public.Key);
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetSystemChainTestAsync()
        {
            var result = await _substrateClient.System.ChainAsync(CancellationToken.None);

            Assert.AreEqual("Ajuna Dev Testnet", result);
        }

        [Test]
        public async Task GetSystemPropertiesTestAsync()
        {
            var result = await _substrateClient.System.PropertiesAsync(CancellationToken.None);

            Assert.AreEqual(42, result.Ss58Format);
            Assert.AreEqual(12, result.TokenDecimals);
            Assert.AreEqual("AJUN", result.TokenSymbol);
        }
    }
}