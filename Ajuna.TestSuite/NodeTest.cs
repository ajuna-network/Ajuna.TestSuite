using Substrate.Integration;
using Substrate.Integration.Client;
using Substrate.NET.Schnorrkel.Keys;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types;

namespace Substrate.NetApi.TestNode
{
    public abstract class NodeTest
    {
        protected const string WebSocketUrl = "ws://127.0.0.1:42181";

        protected SubstrateNetwork _client;

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

        public MiniSecret MiniSecretPlayer1 => new MiniSecret(Utils.HexToByteArray("0x0a52c9148e690566d64e080ffafdda6111d3404ee122d7caf5dd7d25573b07f5"), ExpandMode.Ed25519);
        public Account Player1 => Account.Build(KeyType.Sr25519, MiniSecretPlayer1.ExpandToSecret().ToEd25519Bytes(), MiniSecretPlayer1.GetPair().Public.Key);

        public MiniSecret MiniSecretPlayer2 => new MiniSecret(Utils.HexToByteArray("0xa07e56ddadf45a99b71861c0e42493b254a53f9ffcdaec81de423bbd178becae"), ExpandMode.Ed25519);
        public Account Player2 => Account.Build(KeyType.Sr25519, MiniSecretPlayer2.ExpandToSecret().ToEd25519Bytes(), MiniSecretPlayer2.GetPair().Public.Key);


        [SetUp]
        public async Task ConnectAsync()
        {
            await _client.ConnectAsync(true, true, CancellationToken.None);
        }

        [TearDown]
        public async Task CloseAsync()
        {
            await _client.DisconnectAsync();
        }

        [OneTimeSetUp]
        public void CreateClient()
        {
            _client = new SubstrateNetwork(Alice, Integration.Helper.NetworkType.Live, WebSocketUrl);
        }

        [OneTimeTearDown]
        public void DisposeClient()
        {
            _client.SubstrateClient.Dispose();
        }

        /// <summary>
        /// Return the 20th hash block from now (totally arbitrary)
        /// </summary>
        /// <returns></returns>
        protected async Task<byte[]> GivenBlockAsync()
        {
            var lastBlockData = await _client.SubstrateClient.Chain.GetBlockAsync();
            var lastBlockNumber = lastBlockData.Block.Header.Number.Value;

            var blockNumber = new Model.Types.Base.BlockNumber();
            blockNumber.Create((uint)(lastBlockNumber - 20));
            return (await _client.SubstrateClient.Chain.GetBlockHashAsync(blockNumber)).Bytes;
        }
    }
}