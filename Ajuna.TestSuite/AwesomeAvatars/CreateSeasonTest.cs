using Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.cumulus_pallet_parachain_system.pallet;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.avatar;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.avatar.rarity_tier;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config;
using Substrate.Integration;
using Substrate.Integration.Call;
using Substrate.Integration.Client;
using Substrate.Integration.Helper;
using Substrate.Integration.Model;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.Modules;
using Substrate.NetApi.TestNode;

namespace Ajuna.TestSuite
{
    public class AwesomeAvatarsTest : NodeTest
    {
        private Account _sudo;
        private Account _organizer;
        private Account _player;

        [SetUp]
        public void Setup()
        {
            _sudo = Alice;
            _organizer = Bob;
            _player = Player;
        }

        [Test, Order(1)]
        public async Task SetOrganizerTestAsync()
        {
            var subscriptionId = await _client.SetOrganizerAsync(_sudo, _organizer.ToAccountId32(), 1, CancellationToken.None);
            Assert.That(subscriptionId, Is.Not.Null);

            var tcs = new TaskCompletionSource<bool>();
            void OnExtrinsicUpdated(string subId, ExtrinsicInfo extrinsicInfo)
            {
                if (subId == subscriptionId && extrinsicInfo.TransactionEvent == Substrate.NetApi.Model.Rpc.TransactionEvent.BestChainBlockIncluded)
                {
                    tcs.TrySetResult(true);
                }
            }
            _client.ExtrinsicManager.ExtrinsicUpdated += OnExtrinsicUpdated;
            await tcs.Task;
            _client.ExtrinsicManager.ExtrinsicUpdated -= OnExtrinsicUpdated;
        }

        [Test, Order(2)]
        public async Task FundPlayerTestAsync()
        {
            var enumCalls = new List<EnumRuntimeCall>
            {
                PalletBalances.BalancesTransferKeepAlive(_player.ToAccountId32(), 5 * SubstrateNetwork.DECIMALS),
                PalletAwesomeAvatars.SetFreeMints(_player.ToAccountId32(), 100),
            };
            
            var subscriptionId = await _client.BatchAllAsync(_organizer, enumCalls, 1, CancellationToken.None);
            Assert.That(subscriptionId, Is.Not.Null);

            var tcs = new TaskCompletionSource<bool>();
            void OnExtrinsicUpdated(string subId, ExtrinsicInfo extrinsicInfo)
            {
                if (subId == subscriptionId && extrinsicInfo.TransactionEvent == Substrate.NetApi.Model.Rpc.TransactionEvent.BestChainBlockIncluded)
                {
                    tcs.TrySetResult(true);
                }
            }
            _client.ExtrinsicManager.ExtrinsicUpdated += OnExtrinsicUpdated;
            await tcs.Task;
            _client.ExtrinsicManager.ExtrinsicUpdated -= OnExtrinsicUpdated;
        }

        [Test, Order(3)]
        public async Task CreateNewSeasonTestAsync()
        {
            var currentBlocknumber = await _client.SubstrateClient.SystemStorage.Number(null, CancellationToken.None);
            Assert.That(currentBlocknumber, Is.Not.Null);

            var seasonId = new U16(1);

            var seasonSharp = new SeasonSharp(
                100, 6, 11, 1, 4,
                [RarityTier.Common, RarityTier.Rare, RarityTier.Legendary],
                [0x5f, 0x05],
                [0x50, 0x14],
                20, 20, 12,
                new FeeSharp(
                    new MintFeesSharp(550000000000, 500000000000, 450000000000),
                    100000000000,
                    1000000000000,
                    1,
                    36900000000000,
                    20000000000000,
                    50000000000000,
                    90000000000000),
                LogicGeneration.First,
                LogicGeneration.First);
            var season = seasonSharp.ToSubstrate();

            var seasonMetaSharp = new SeasonMetaSharp(
                "Test Season One",
                "This is a test season, to see if it works!");
            var seasonMeta = seasonMetaSharp.ToSubstrate();

            var seasonScheduleSharp = new SeasonScheduleSharp(
                earlyStart: currentBlocknumber.Value + 5,
                start: currentBlocknumber.Value + 10,
                end: currentBlocknumber.Value + 500);
            var seasonSchedule = seasonScheduleSharp.ToSubstrate();

            var tradeFilterSharp = new TradeFiltersSharp([0]);
            var tradeFilter = tradeFilterSharp.ToSubstrate();

            var subscriptionId = await _client.SetSeasonAsync(_organizer, seasonId, season, seasonMeta, seasonSchedule, tradeFilter, 1, CancellationToken.None);
            Assert.That(subscriptionId, Is.Not.Null);

            var tcs = new TaskCompletionSource<bool>();
            void OnExtrinsicUpdated(string subId, ExtrinsicInfo extrinsicInfo)
            {
                if (subId == subscriptionId && extrinsicInfo.TransactionEvent == Substrate.NetApi.Model.Rpc.TransactionEvent.BestChainBlockIncluded)
                {
                    tcs.TrySetResult(true);
                }
            }
            _client.ExtrinsicManager.ExtrinsicUpdated += OnExtrinsicUpdated;
            await tcs.Task;
            _client.ExtrinsicManager.ExtrinsicUpdated -= OnExtrinsicUpdated;

            var seasonSharpRet = await _client.GetSeasonsAsync(seasonId, null, CancellationToken.None);
            Assert.That(seasonSharpRet, Is.Not.Null);
            Assert.That(seasonSharpRet.MaxTierForges, Is.EqualTo(seasonSharp.MaxTierForges));
            Assert.That(seasonSharpRet.MaxVariations, Is.EqualTo(seasonSharp.MaxVariations));
            Assert.That(seasonSharpRet.MaxComponents, Is.EqualTo(seasonSharp.MaxComponents));
            Assert.That(seasonSharpRet.MinSacrifices, Is.EqualTo(seasonSharp.MinSacrifices));
            Assert.That(seasonSharpRet.MaxSacrifices, Is.EqualTo(seasonSharp.MaxSacrifices));
            Assert.That(seasonSharpRet.Tiers.SequenceEqual(seasonSharp.Tiers), Is.True);
            Assert.That(seasonSharpRet.SingleMintProbs.SequenceEqual(seasonSharp.SingleMintProbs), Is.True);
            Assert.That(seasonSharpRet.BatchMintProbs.SequenceEqual(seasonSharp.BatchMintProbs), Is.True);
            Assert.That(seasonSharpRet.BaseProb, Is.EqualTo(seasonSharp.BaseProb));
            Assert.That(seasonSharpRet.PerPeriod, Is.EqualTo(seasonSharp.PerPeriod));
            Assert.That(seasonSharpRet.Periods, Is.EqualTo(seasonSharp.Periods));
            Assert.That(seasonSharpRet.Fee.MintFees.One, Is.EqualTo(seasonSharp.Fee.MintFees.One));
            Assert.That(seasonSharpRet.Fee.MintFees.Three, Is.EqualTo(seasonSharp.Fee.MintFees.Three));
            Assert.That(seasonSharpRet.Fee.MintFees.Six, Is.EqualTo(seasonSharp.Fee.MintFees.Six));
            Assert.That(seasonSharpRet.Fee.TransferAvatar, Is.EqualTo(seasonSharp.Fee.TransferAvatar));
            Assert.That(seasonSharpRet.Fee.BuyMinimum, Is.EqualTo(seasonSharp.Fee.BuyMinimum));
            Assert.That(seasonSharpRet.Fee.BuyPercent, Is.EqualTo(seasonSharp.Fee.BuyPercent));
            Assert.That(seasonSharpRet.Fee.UpgradeStorage, Is.EqualTo(seasonSharp.Fee.UpgradeStorage));
            Assert.That(seasonSharpRet.Fee.PrepareAvatar, Is.EqualTo(seasonSharp.Fee.PrepareAvatar));
            Assert.That(seasonSharpRet.Fee.SetPriceUnlock, Is.EqualTo(seasonSharp.Fee.SetPriceUnlock));
            Assert.That(seasonSharpRet.Fee.AvatarTransferUnlock, Is.EqualTo(seasonSharp.Fee.AvatarTransferUnlock));
            Assert.That(seasonSharpRet.MintLogic, Is.EqualTo(seasonSharp.MintLogic));
            Assert.That(seasonSharpRet.ForgeLogic, Is.EqualTo(seasonSharp.ForgeLogic));

            var seasonMetaSharpRet = await _client.GetSeasonMetasAsync(seasonId, null, CancellationToken.None);
            Assert.That(seasonMetaSharpRet, Is.Not.Null);
            Assert.That(seasonMetaSharpRet.Name, Is.EqualTo(seasonMetaSharp.Name));
            Assert.That(seasonMetaSharpRet.Description, Is.EqualTo(seasonMetaSharp.Description));

            var seasonScheduleSharpRet = await _client.GetSeasonSchedulesAsync(seasonId, null, CancellationToken.None);
            Assert.That(seasonScheduleSharpRet, Is.Not.Null);
            Assert.That(seasonScheduleSharpRet.EarlyStart, Is.EqualTo(seasonScheduleSharp.EarlyStart));
            Assert.That(seasonScheduleSharpRet.Start, Is.EqualTo(seasonScheduleSharp.Start));
            Assert.That(seasonScheduleSharpRet.End, Is.EqualTo(seasonScheduleSharp.End));

            var tradeFiltersSharpRet = await _client.GetSeasonTradeFiltersAsync(seasonId, null, CancellationToken.None);
            Assert.That(tradeFiltersSharpRet, Is.Not.Null);
            Assert.That(tradeFiltersSharpRet.Values.SequenceEqual(tradeFilterSharp.Values), Is.True);
        }

        [Test, Order(4)]
        public async Task PlayInSeasonAsync()
        {

            var mintOptionSharp = new MintOptionSharp(MintPayment.Free, PackType.Special, MintPackSize.Six);
            var mintOption = mintOptionSharp.ToSubstrate();

            var subscriptionId = await _client.MintAsync(_player, mintOption, 1, CancellationToken.None);
            Assert.That(subscriptionId, Is.Not.Null);

            var tcs = new TaskCompletionSource<bool>();
            void OnExtrinsicUpdated(string subId, ExtrinsicInfo extrinsicInfo)
            {
                if (subId == subscriptionId && extrinsicInfo.TransactionEvent == Substrate.NetApi.Model.Rpc.TransactionEvent.BestChainBlockIncluded)
                {
                    tcs.TrySetResult(true);
                }
            }
            _client.ExtrinsicManager.ExtrinsicUpdated += OnExtrinsicUpdated;
            await tcs.Task;
            _client.ExtrinsicManager.ExtrinsicUpdated -= OnExtrinsicUpdated;
        }    
    }
}