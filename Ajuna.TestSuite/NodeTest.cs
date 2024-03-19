using Substrate.NetApi.Model.Extrinsics;

namespace Substrate.NetApi.TestNode
{
    public abstract class NodeTest
    {
        protected const string WebSocketUrl = "wss://unique-rpc.dwellir.com";

        protected SubstrateClient _substrateClient;


        [SetUp]
        public async Task ConnectAsync()
        {
            await _substrateClient.ConnectAsync();
        }

        [TearDown]
        public async Task CloseAsync()
        {
            await _substrateClient.CloseAsync();
        }

        [OneTimeSetUp]
        public void CreateClient()
        {
            _substrateClient = new SubstrateClient(new Uri(WebSocketUrl), ChargeTransactionPayment.Default());
        }

        [OneTimeTearDown]
        public void DisposeClient()
        {
            _substrateClient.Dispose();
        }

        /// <summary>
        /// Return the 20th hash block from now (totally arbitrary)
        /// </summary>
        /// <returns></returns>
        protected async Task<byte[]> GivenBlockAsync()
        {
            var lastBlockData = await _substrateClient.Chain.GetBlockAsync();
            var lastBlockNumber = lastBlockData.Block.Header.Number.Value;

            var blockNumber = new Model.Types.Base.BlockNumber();
            blockNumber.Create((uint)(lastBlockNumber - 20));
            return (await _substrateClient.Chain.GetBlockHashAsync(blockNumber)).Bytes;
        }
    }
}