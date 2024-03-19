using Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.avatar;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.avatar.rarity_tier;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto;
using Substrate.Bajun.NET.NetApiExt.Generated.Storage;
using Substrate.Integration;
using Substrate.Integration.Call;
using Substrate.Integration.Client;
using Substrate.Integration.Helper;
using Substrate.Integration.Model;
using Substrate.NetApi;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.TestNode;

namespace Ajuna.TestSuite
{
    public class AwesomeAvatarsTest : NodeTest
    {
        private Account _sudo;
        private Account _organizer;
        private Account _player1;
        private Account _player2;

        private U16 _seasonId;

        [SetUp]
        public void Setup()
        {
            _sudo = Alice;
            _organizer = Bob;
            _player1 = Player1;
            _player2 = Player2;

            _seasonId = new U16(1);
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
        public async Task FundPlayer1TestAsync()
        {
            var enumCalls = new List<EnumRuntimeCall>
            {
                PalletBalances.BalancesTransferKeepAlive(_player1.ToAccountId32(), 5 * SubstrateNetwork.DECIMALS),
                PalletAwesomeAvatars.SetFreeMints(_player1.ToAccountId32(), 100),
            };

            var subscriptionId = await _client.BatchAllAsync(_organizer, enumCalls, 1, CancellationToken.None);
            Assert.That(subscriptionId, Is.Not.Null);

            var tcs = new TaskCompletionSource<bool>();
            void OnExtrinsicUpdated(string subId, ExtrinsicInfo extrinsicInfo)
            {
                if (subId == subscriptionId && extrinsicInfo.TransactionEvent == TransactionEvent.BestChainBlockIncluded)
                {
                    tcs.TrySetResult(true);
                }
            }
            _client.ExtrinsicManager.ExtrinsicUpdated += OnExtrinsicUpdated;
            await tcs.Task;
            _client.ExtrinsicManager.ExtrinsicUpdated -= OnExtrinsicUpdated;
        }


        [Test, Order(2)]
        public async Task FundPlayer2TestAsync()
        {
            var enumCalls = new List<EnumRuntimeCall>
            {
                PalletBalances.BalancesTransferKeepAlive(_player2.ToAccountId32(), 5 * SubstrateNetwork.DECIMALS),
            };

            var subscriptionId = await _client.BatchAllAsync(_organizer, enumCalls, 1, CancellationToken.None);
            Assert.That(subscriptionId, Is.Not.Null);

            var tcs = new TaskCompletionSource<bool>();
            void OnExtrinsicUpdated(string subId, ExtrinsicInfo extrinsicInfo)
            {
                if (subId == subscriptionId && extrinsicInfo.TransactionEvent == TransactionEvent.BestChainBlockIncluded)
                {
                    tcs.TrySetResult(true);
                }
            }
            _client.ExtrinsicManager.ExtrinsicUpdated += OnExtrinsicUpdated;
            await tcs.Task;
            _client.ExtrinsicManager.ExtrinsicUpdated -= OnExtrinsicUpdated;
        }

        [Test, Order(2)]
        public async Task InitialGlobalConfigTestAsync()
        {
            var mintConfigSharp = new MintConfigSharp(true, 1, 1);
            var forgeConfigSharp = new ForgeConfigSharp(true);
            var avatarTransferConfigSharp = new AvatarTransferConfigSharp(true);
            var freemintTransferConfigSharp = new FreemintTransferConfigSharp(FreeMintTransferMode.WhitelistOnly, 1, 2);
            var tradeConfigSharp = new TradeConfigSharp(true);
            var nftTransferConfigSharp = new NftTransferConfigSharp(true);
            var affiliateConfigSharp = new AffiliateConfigSharp(AffiliateMode.Open, true, true, true, 10 * SubstrateNetwork.DECIMALS);

            var result = await GlobalConfigAsync(_organizer,
                mintConfigSharp,
                forgeConfigSharp,
                avatarTransferConfigSharp,
                freemintTransferConfigSharp,
                tradeConfigSharp,
                nftTransferConfigSharp,
               affiliateConfigSharp);

            Assert.That(result.Item2.SystemExtrinsicEvent(out var systemExtrinsicEvent, out var errorMsg), Is.True);
            Assert.That(systemExtrinsicEvent, Is.Not.Null);
            Assert.That(systemExtrinsicEvent, Is.EqualTo(Substrate.Bajun.NET.NetApiExt.Generated.Model.frame_system.pallet.Event.ExtrinsicSuccess));

            var globalConfigSharp = await _client.GetGlobalConfigsAsync(null, CancellationToken.None);
            Assert.That(globalConfigSharp, Is.Not.Null);

            Assert.That(globalConfigSharp.Mint.Open, Is.EqualTo(mintConfigSharp.Open));
            Assert.That(globalConfigSharp.Mint.Cooldown, Is.EqualTo(mintConfigSharp.Cooldown));
            Assert.That(globalConfigSharp.Mint.FreeMintFeeMultiplier, Is.EqualTo(mintConfigSharp.FreeMintFeeMultiplier));

            Assert.That(globalConfigSharp.Forge.Open, Is.EqualTo(forgeConfigSharp.Open));

            Assert.That(globalConfigSharp.AvatarTransfer.Open, Is.EqualTo(avatarTransferConfigSharp.Open));

            Assert.That(globalConfigSharp.FreemintTransfer.Mode, Is.EqualTo(freemintTransferConfigSharp.Mode));
            Assert.That(globalConfigSharp.FreemintTransfer.FreeMintTransferFee, Is.EqualTo(freemintTransferConfigSharp.FreeMintTransferFee));
            Assert.That(globalConfigSharp.FreemintTransfer.MinFreeMintTransfer, Is.EqualTo(freemintTransferConfigSharp.MinFreeMintTransfer));

            Assert.That(globalConfigSharp.Trade.Open, Is.EqualTo(tradeConfigSharp.Open));

            Assert.That(globalConfigSharp.NftTransfer.Open, Is.EqualTo(nftTransferConfigSharp.Open));

            Assert.That(globalConfigSharp.AffiliateConfig.Mode, Is.EqualTo(affiliateConfigSharp.Mode));
            Assert.That(globalConfigSharp.AffiliateConfig.EnabledInMint, Is.EqualTo(affiliateConfigSharp.EnabledInMint));
            Assert.That(globalConfigSharp.AffiliateConfig.EnabledInBuy, Is.EqualTo(affiliateConfigSharp.EnabledInBuy));
            Assert.That(globalConfigSharp.AffiliateConfig.EnabledInUpgrade, Is.EqualTo(affiliateConfigSharp.EnabledInUpgrade));
            Assert.That(globalConfigSharp.AffiliateConfig.AffiliatorEnableFee, Is.EqualTo(affiliateConfigSharp.AffiliatorEnableFee));
        }

        [Test, Order(3)]
        public async Task CreateNewSeasonTestAsync()
        {
            var currentBlocknumber = await _client.SubstrateClient.SystemStorage.Number(null, CancellationToken.None);
            Assert.That(currentBlocknumber, Is.Not.Null);

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

            var earlyStart = currentBlocknumber.Value + 5;

            var seasonScheduleSharp = new SeasonScheduleSharp(
                earlyStart: earlyStart,
                start: earlyStart + 5,
                end: earlyStart + 500);
            var seasonSchedule = seasonScheduleSharp.ToSubstrate();

            var tradeFilterSharp = new TradeFiltersSharp([0]);
            var tradeFilter = tradeFilterSharp.ToSubstrate();

            var subscriptionId = await _client.SetSeasonAsync(_organizer, _seasonId, season, seasonMeta, seasonSchedule, tradeFilter, 1, CancellationToken.None);
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

            var seasonSharpRet = await _client.GetSeasonsAsync(_seasonId, null, CancellationToken.None);
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

            var seasonMetaSharpRet = await _client.GetSeasonMetasAsync(_seasonId, null, CancellationToken.None);
            Assert.That(seasonMetaSharpRet, Is.Not.Null);
            Assert.That(seasonMetaSharpRet.Name, Is.EqualTo(seasonMetaSharp.Name));
            Assert.That(seasonMetaSharpRet.Description, Is.EqualTo(seasonMetaSharp.Description));

            var seasonScheduleSharpRet = await _client.GetSeasonSchedulesAsync(_seasonId, null, CancellationToken.None);
            Assert.That(seasonScheduleSharpRet, Is.Not.Null);
            Assert.That(seasonScheduleSharpRet.EarlyStart, Is.EqualTo(seasonScheduleSharp.EarlyStart));
            Assert.That(seasonScheduleSharpRet.Start, Is.EqualTo(seasonScheduleSharp.Start));
            Assert.That(seasonScheduleSharpRet.End, Is.EqualTo(seasonScheduleSharp.End));

            var tradeFiltersSharpRet = await _client.GetSeasonTradeFiltersAsync(_seasonId, null, CancellationToken.None);
            Assert.That(tradeFiltersSharpRet, Is.Not.Null);
            Assert.That(tradeFiltersSharpRet.Values.SequenceEqual(tradeFilterSharp.Values), Is.True);
        }

        [Test, Order(4)]
        public async Task BeforeSeasonTestAsync()
        {
            var seasonStatusSharp = await _client.GetCurrentSeasonStatusAsync(null, CancellationToken.None);
            Assert.That(seasonStatusSharp, Is.Not.Null);

            if (!seasonStatusSharp.Early && !seasonStatusSharp.Active && !seasonStatusSharp.EarlyEnded && seasonStatusSharp.SeasonId == 1)
            {
                _ = await MinitingAsync(_player1, MintPayment.Free, AwesomeAvatarsErrors.SeasonClosed);
                _ = await MinitingAsync(_player2, MintPayment.Free, AwesomeAvatarsErrors.SeasonClosed);
            }

            seasonStatusSharp = await _client.GetCurrentSeasonStatusAsync(null, CancellationToken.None);
            Assert.That(seasonStatusSharp, Is.Not.Null);

            Assert.That(!seasonStatusSharp.Early && !seasonStatusSharp.Active && !seasonStatusSharp.EarlyEnded && seasonStatusSharp.SeasonId == 1, Is.True, "Conditions maintained");
        }

        [Test, Order(6)]
        public async Task WaitForSeasonToStartAsync()
        {
            SeasonStatusSharp? seasonStatusSharp;
            do
            {
                seasonStatusSharp = await _client.GetCurrentSeasonStatusAsync(null, CancellationToken.None);
                Assert.That(seasonStatusSharp, Is.Not.Null);

                if (!seasonStatusSharp.Early && seasonStatusSharp.SeasonId == 1)
                {
                    await Task.Delay(3000); // Non-blocking wait before retrying
                }
            }
            while (!seasonStatusSharp.Early && seasonStatusSharp.SeasonId == 1);
        }

        [Test, Order(7)]
        public async Task EarlySeasonTestAsync()
        {
            var seasonStatusSharp = await _client.GetCurrentSeasonStatusAsync(null, CancellationToken.None);
            Assert.That(seasonStatusSharp, Is.Not.Null);

            if (seasonStatusSharp.Early && !seasonStatusSharp.Active && !seasonStatusSharp.EarlyEnded && seasonStatusSharp.SeasonId == 1)
            {
                _ = await MinitingAsync(_player1, MintPayment.Free, null);
                _ = await MinitingAsync(_player2, MintPayment.Free, AwesomeAvatarsErrors.TooLowFreeMints);
            }

            seasonStatusSharp = await _client.GetCurrentSeasonStatusAsync(null, CancellationToken.None);
            Assert.That(seasonStatusSharp, Is.Not.Null);

            Assert.That(seasonStatusSharp.Early && !seasonStatusSharp.Active && !seasonStatusSharp.EarlyEnded && seasonStatusSharp.SeasonId == 1, Is.True, "Conditions maintained");
        }

        [Test, Order(8)]
        public async Task WaitForActiveSeasonAsync()
        {
            SeasonStatusSharp? seasonStatusSharp;
            do
            {
                seasonStatusSharp = await _client.GetCurrentSeasonStatusAsync(null, CancellationToken.None);
                Assert.That(seasonStatusSharp, Is.Not.Null);

                if (!seasonStatusSharp.Active && seasonStatusSharp.SeasonId == 1)
                {
                    await Task.Delay(3000); // Non-blocking wait before retrying
                }
            }
            while (!seasonStatusSharp.Active && seasonStatusSharp.SeasonId == 1);
        }

        [Test, Order(9)]
        public async Task FullMintConfigTestAsync()
        {
            var mintConfigSharp = new MintConfigSharp(true, 1, 1);
            var forgeConfigSharp = new ForgeConfigSharp(true);
            var avatarTransferConfigSharp = new AvatarTransferConfigSharp(true);
            var freemintTransferConfigSharp = new FreemintTransferConfigSharp(FreeMintTransferMode.WhitelistOnly, 1, 2);
            var tradeConfigSharp = new TradeConfigSharp(true);
            var nftTransferConfigSharp = new NftTransferConfigSharp(true);
            var affiliateConfigSharp = new AffiliateConfigSharp(AffiliateMode.Open, true, true, true, 10 * SubstrateNetwork.DECIMALS);

            var result = await GlobalConfigAsync(_organizer,
                new MintConfigSharp(false, 1, 1),
                null,
                null,
                null,
                null,
                null,
                null);

            Assert.That(result.Item2.SystemExtrinsicEvent(out var systemExtrinsicEvent, out var errorMsg), Is.True);
            Assert.That(systemExtrinsicEvent, Is.EqualTo(Substrate.Bajun.NET.NetApiExt.Generated.Model.frame_system.pallet.Event.ExtrinsicSuccess));

            _ = await MinitingAsync(_player1, MintPayment.Free, AwesomeAvatarsErrors.MintClosed);
        }

        [Test, Order(10)]
        public async Task FullForgeConfigTestAsync()
        {
            var mintConfigSharp = new MintConfigSharp(true, 1, 1);
            var forgeConfigSharp = new ForgeConfigSharp(true);
            var avatarTransferConfigSharp = new AvatarTransferConfigSharp(true);
            var freemintTransferConfigSharp = new FreemintTransferConfigSharp(FreeMintTransferMode.WhitelistOnly, 1, 2);
            var tradeConfigSharp = new TradeConfigSharp(true);
            var nftTransferConfigSharp = new NftTransferConfigSharp(true);
            var affiliateConfigSharp = new AffiliateConfigSharp(AffiliateMode.Open, true, true, true, 10 * SubstrateNetwork.DECIMALS);

            var result = await GlobalConfigAsync(_organizer,
                null,
                new ForgeConfigSharp(false),
                null,
                null,
                null,
                null,
                null);

            Assert.That(result.Item2.SystemExtrinsicEvent(out var systemExtrinsicEvent, out var errorMsg), Is.True);
            Assert.That(systemExtrinsicEvent, Is.EqualTo(Substrate.Bajun.NET.NetApiExt.Generated.Model.frame_system.pallet.Event.ExtrinsicSuccess));

            var avatars = await GetAvatarIdsAsync(_player1);

            _ = await ForgingAsync(_player1, avatars[0], [avatars[1]], AwesomeAvatarsErrors.ForgeClosed);
        }

        public async Task<(bool, ExtrinsicInfo)> MinitingAsync(Account account, MintPayment mintPayment, AwesomeAvatarsErrors? avatarsErrors)
        {
            var tcs = new TaskCompletionSource<(bool, ExtrinsicInfo)>();
            var subscriptionId = "";

            var mintOptionSharp = new MintOptionSharp(mintPayment, PackType.Special, MintPackSize.Six);
            var mintOption = mintOptionSharp.ToSubstrate();

            void OnExtrinsicUpdated(string subId, ExtrinsicInfo extrinsicInfo)
            {
                if (subId == subscriptionId && (extrinsicInfo.HasEvents || extrinsicInfo.Error != null))
                {
                    tcs.SetResult((true, extrinsicInfo));
                }
            }

            _client.ExtrinsicManager.ExtrinsicUpdated += OnExtrinsicUpdated;
            subscriptionId = await _client.MintAsync(account, mintOption, 1, CancellationToken.None);
            Assert.That(subscriptionId, Is.Not.Null);

            var finished = await Task.WhenAny(tcs.Task, Task.Delay(TimeSpan.FromSeconds(90)));
            _client.ExtrinsicManager.ExtrinsicUpdated -= OnExtrinsicUpdated;

            Assert.That(finished, Is.EqualTo(tcs.Task), "Test timed out waiting for final callback");
            var taskResult = (await tcs.Task);

            Assert.That(taskResult.Item1, Is.True);

            Assert.That(taskResult.Item2.SystemExtrinsicEvent(out var systemExtrinsicEvent, out var errorMsg), Is.True);
            Assert.That(systemExtrinsicEvent, Is.Not.Null);

            if (avatarsErrors != null)
            {
                Assert.That(systemExtrinsicEvent, Is.EqualTo(Substrate.Bajun.NET.NetApiExt.Generated.Model.frame_system.pallet.Event.ExtrinsicFailed));
                Assert.That(errorMsg, Is.Not.Null);
                Assert.That((AwesomeAvatarsErrors)BitConverter.ToUInt32(Utils.HexToByteArray(errorMsg.Split(";")[3]), 0), Is.EqualTo(avatarsErrors));
            }
            else
            {
                Assert.That(systemExtrinsicEvent, Is.EqualTo(Substrate.Bajun.NET.NetApiExt.Generated.Model.frame_system.pallet.Event.ExtrinsicSuccess));
                Assert.That(errorMsg, Is.Null);
            }

            return taskResult;
        }

        public async Task<(bool, ExtrinsicInfo)> ForgingAsync(Account account, H256 leader, H256[] sacrifices, AwesomeAvatarsErrors? avatarsErrors)
        {
            var tcs = new TaskCompletionSource<(bool, ExtrinsicInfo)>();
            var subscriptionId = "";

            void OnExtrinsicUpdated(string subId, ExtrinsicInfo extrinsicInfo)
            {
                if (subId == subscriptionId && (extrinsicInfo.HasEvents || extrinsicInfo.Error != null))
                {
                    tcs.SetResult((true, extrinsicInfo));
                }
            }

            _client.ExtrinsicManager.ExtrinsicUpdated += OnExtrinsicUpdated;
            subscriptionId = await _client.ForgeAsync(account, leader, new BaseVec<H256>(sacrifices), 1, CancellationToken.None);
            Assert.That(subscriptionId, Is.Not.Null);

            var finished = await Task.WhenAny(tcs.Task, Task.Delay(TimeSpan.FromSeconds(90)));
            _client.ExtrinsicManager.ExtrinsicUpdated -= OnExtrinsicUpdated;

            Assert.That(finished, Is.EqualTo(tcs.Task), "Test timed out waiting for final callback");
            var taskResult = (await tcs.Task);

            Assert.That(taskResult.Item1, Is.True);

            Assert.That(taskResult.Item2.SystemExtrinsicEvent(out var systemExtrinsicEvent, out var errorMsg), Is.True);
            Assert.That(systemExtrinsicEvent, Is.Not.Null);

            if (avatarsErrors != null)
            {
                Assert.That(systemExtrinsicEvent, Is.EqualTo(Substrate.Bajun.NET.NetApiExt.Generated.Model.frame_system.pallet.Event.ExtrinsicFailed));
                Assert.That(errorMsg, Is.Not.Null);
                Assert.That((AwesomeAvatarsErrors)BitConverter.ToUInt32(Utils.HexToByteArray(errorMsg.Split(";")[3]), 0), Is.EqualTo(avatarsErrors));
            }
            else
            {
                Assert.That(systemExtrinsicEvent, Is.EqualTo(Substrate.Bajun.NET.NetApiExt.Generated.Model.frame_system.pallet.Event.ExtrinsicSuccess));
                Assert.That(errorMsg, Is.Null);
            }

            return taskResult;
        }

        public async Task<(bool, ExtrinsicInfo)> GlobalConfigAsync(Account account, MintConfigSharp? mintConfigSharp, ForgeConfigSharp? forgeConfigSharp, AvatarTransferConfigSharp? avatarTransferConfigSharp, FreemintTransferConfigSharp? freemintTransferConfigSharp, TradeConfigSharp? tradeConfigSharp, NftTransferConfigSharp? nftTransferConfigSharp, AffiliateConfigSharp? affiliateConfigSharp)
        {
            var tcs = new TaskCompletionSource<(bool, ExtrinsicInfo)>();
            var subscriptionId = "";

            var currentGlobalConfig = await _client.GetGlobalConfigsAsync(null, CancellationToken.None);
            Assert.That(currentGlobalConfig, Is.Not.Null);

            var globalConfigSharp = new GlobalConfigSharp(
                mintConfigSharp ?? currentGlobalConfig.Mint,
                forgeConfigSharp ?? currentGlobalConfig.Forge,
                avatarTransferConfigSharp ?? currentGlobalConfig.AvatarTransfer,
                freemintTransferConfigSharp ?? currentGlobalConfig.FreemintTransfer,
                tradeConfigSharp ?? currentGlobalConfig.Trade,
                nftTransferConfigSharp ?? currentGlobalConfig.NftTransfer,
                affiliateConfigSharp ?? currentGlobalConfig.AffiliateConfig);
            var globalConfig = globalConfigSharp.ToSubstrate();

            void OnExtrinsicUpdated(string subId, ExtrinsicInfo extrinsicInfo)
            {
                if (subId == subscriptionId && (extrinsicInfo.HasEvents || extrinsicInfo.Error != null))
                {
                    tcs.SetResult((true, extrinsicInfo));
                }
            }

            _client.ExtrinsicManager.ExtrinsicUpdated += OnExtrinsicUpdated;
            subscriptionId = await _client.UpdateGlobalConfigAsync(account, globalConfig, 1, CancellationToken.None);
            Assert.That(subscriptionId, Is.Not.Null);

            var finished = await Task.WhenAny(tcs.Task, Task.Delay(TimeSpan.FromSeconds(90)));
            _client.ExtrinsicManager.ExtrinsicUpdated -= OnExtrinsicUpdated;

            Assert.That(finished, Is.EqualTo(tcs.Task), "Test timed out waiting for final callback");
            var taskResult = (await tcs.Task);

            Assert.That(taskResult.Item1, Is.True);

            return taskResult;
        }

        public async Task<List<H256>> GetAvatarIdsAsync(Account account)
        {
            var key = new BaseTuple<AccountId32, U16>();
            key.Create(account.ToAccountId32(), _seasonId);

            var avatars = await _client.GetOwnersAsync(key, null, CancellationToken.None);
            Assert.That(avatars, Is.Not.Null);

            return avatars.Select(p => p.ToH256()).ToList();
        }
    }
}