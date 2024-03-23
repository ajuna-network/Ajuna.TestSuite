using Newtonsoft.Json.Linq;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.bounded_collections.bounded_vec;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.pallet;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.avatar;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.avatar.rarity_tier;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_runtime;
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
using System.Numerics;
using System.Xml.Linq;

namespace Ajuna.TestSuite
{
    public class AwesomeAvatarsTest : NodeTest
    {
        private Account _sudo;
        private Account _organizer;
        private Account _player1;
        private Account _player2;

        private ushort _seasonId;

        [SetUp]
        public void Setup()
        {
            _sudo = Alice;
            _organizer = Bob;
            _player1 = Player1;
            _player2 = Player2;

            _seasonId = 1;
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
                PalletBalances.BalancesTransferKeepAlive(_player1.ToAccountId32(), 1000 * SubstrateNetwork.DECIMALS),
                PalletAwesomeAvatars.SetFreeMints(_player1.ToAccountId32(), 500),
            };

            var subscriptionId = await _client.BatchAllAsync(_organizer, enumCalls, 2, CancellationToken.None);
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

        [Test, Order(3)]
        public async Task FundPlayer2TestAsync()
        {
            var enumCalls = new List<EnumRuntimeCall>
            {
                PalletBalances.BalancesTransferKeepAlive(_player2.ToAccountId32(), 5 * SubstrateNetwork.DECIMALS),
            };

            var subscriptionId = await _client.BatchAllAsync(_organizer, enumCalls, 2, CancellationToken.None);
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

        [Test, Order(4)]
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
                affiliateConfigSharp,
                null);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.ExtrinsicInfo.SystemExtrinsicEvent(out var systemExtrinsicEvent, out var errorMsg), Is.True);
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

        [Test, Order(4)]
        public async Task InitialUnlockConfigTestAsync()
        {
            //1: Minted, 2: Freeminted, 3: Forged, 4: Bought, 5: Sold
            
            var setPriceUnlock = new BoundedVecT6();
            setPriceUnlock.Value = new BaseVec<U8>(
                [new U8(0x05), new U8(0x05), new U8(0x05), new U8(0x00), new U8(0x00)]);
            
            var avatarTransferUnlock = new BoundedVecT6();
            avatarTransferUnlock.Value = new BaseVec<U8>(
                [new U8(0x0A), new U8(0x05), new U8(0x05), new U8(0x00), new U8(0x00)]);
            
            var affiliateUnlock = new BoundedVecT6();
            affiliateUnlock.Value = new BaseVec<U8>(
                [new U8(0x14), new U8(0x05), new U8(0x05), new U8(0x00), new U8(0x00)]);

            var unlockConfigs = new UnlockConfigs
            {
                SetPriceUnlock = new BaseOpt<BoundedVecT6>(),
                AvatarTransferUnlock = new BaseOpt<BoundedVecT6>(),
                AffiliateUnlock = new BaseOpt<BoundedVecT6>()
            };

            unlockConfigs.SetPriceUnlock.Create(setPriceUnlock);
            unlockConfigs.AvatarTransferUnlock.Create(setPriceUnlock);
            unlockConfigs.AffiliateUnlock.Create(affiliateUnlock);

            Assert.That((await UnlockConfigAsync(_organizer,
                _seasonId, unlockConfigs, null)).IsSuccess, Is.True);
        }

        [Test, Order(5)]
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
                    setPriceUnlock: 50 * SubstrateNetwork.DECIMALS,
                    avatarTransferUnlock: 90 * SubstrateNetwork.DECIMALS),
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

            var subscriptionId = await _client.SetSeasonAsync(_organizer, new U16(_seasonId), season, seasonMeta, seasonSchedule, tradeFilter, 1, CancellationToken.None);
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

            var seasonSharpRet = await _client.GetSeasonsAsync(new U16(_seasonId), null, CancellationToken.None);
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

            var seasonMetaSharpRet = await _client.GetSeasonMetasAsync(new U16(_seasonId), null, CancellationToken.None);
            Assert.That(seasonMetaSharpRet, Is.Not.Null);
            Assert.That(seasonMetaSharpRet.Name, Is.EqualTo(seasonMetaSharp.Name));
            Assert.That(seasonMetaSharpRet.Description, Is.EqualTo(seasonMetaSharp.Description));

            var seasonScheduleSharpRet = await _client.GetSeasonSchedulesAsync(new U16(_seasonId), null, CancellationToken.None);
            Assert.That(seasonScheduleSharpRet, Is.Not.Null);
            Assert.That(seasonScheduleSharpRet.EarlyStart, Is.EqualTo(seasonScheduleSharp.EarlyStart));
            Assert.That(seasonScheduleSharpRet.Start, Is.EqualTo(seasonScheduleSharp.Start));
            Assert.That(seasonScheduleSharpRet.End, Is.EqualTo(seasonScheduleSharp.End));

            var tradeFiltersSharpRet = await _client.GetSeasonTradeFiltersAsync(new U16(_seasonId), null, CancellationToken.None);
            Assert.That(tradeFiltersSharpRet, Is.Not.Null);
            Assert.That(tradeFiltersSharpRet.Values.SequenceEqual(tradeFilterSharp.Values), Is.True);
        }

        [Test, Order(6)]
        public async Task BeforeSeasonTestAsync()
        {
            var seasonStatusSharp = await _client.GetCurrentSeasonStatusAsync(null, CancellationToken.None);
            Assert.That(seasonStatusSharp, Is.Not.Null);

            if (!seasonStatusSharp.Early && !seasonStatusSharp.Active && !seasonStatusSharp.EarlyEnded && seasonStatusSharp.SeasonId == 1)
            {
                Assert.That((await MintAsync(_player1, MintPayment.Free, AwesomeAvatarsErrors.SeasonClosed)).IsSuccess, Is.True);
                Assert.That((await MintAsync(_player2, MintPayment.Normal, AwesomeAvatarsErrors.SeasonClosed)).IsSuccess, Is.True);
            }

            seasonStatusSharp = await _client.GetCurrentSeasonStatusAsync(null, CancellationToken.None);
            Assert.That(seasonStatusSharp, Is.Not.Null);

            Assert.That(!seasonStatusSharp.Early && !seasonStatusSharp.Active && !seasonStatusSharp.EarlyEnded && seasonStatusSharp.SeasonId == 1, Is.True, "Conditions maintained");
        }

        [Test, Order(6)]
        public async Task TransferFreeMintsPlayer1TestAsync()
        {
            _ = await TransferFreeMintsAsync(_player1, _organizer.ToAccountId32(), 10, AwesomeAvatarsErrors.FreeMintTransferClosed);
        }

        [Test, Order(7)]
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

        [Test, Order(8)]
        public async Task EarlySeasonPlayer1MintTestAsync()
        {
            var seasonStatusSharp = await _client.GetCurrentSeasonStatusAsync(null, CancellationToken.None);
            Assert.That(seasonStatusSharp, Is.Not.Null);

            if (seasonStatusSharp.Early && !seasonStatusSharp.Active && !seasonStatusSharp.EarlyEnded && seasonStatusSharp.SeasonId == 1)
            {
                _ = await MintAsync(_player1, MintPayment.Free, null);
            }

            seasonStatusSharp = await _client.GetCurrentSeasonStatusAsync(null, CancellationToken.None);
            Assert.That(seasonStatusSharp, Is.Not.Null);

            Assert.That(seasonStatusSharp.Early && !seasonStatusSharp.Active && !seasonStatusSharp.EarlyEnded && seasonStatusSharp.SeasonId == 1, Is.True, "Conditions maintained");
        }

        [Test, Order(8)]
        public async Task EarlySeasonPlayer2MintTestAsync()
        {
            var seasonStatusSharp = await _client.GetCurrentSeasonStatusAsync(null, CancellationToken.None);
            Assert.That(seasonStatusSharp, Is.Not.Null);

            if (seasonStatusSharp.Early && !seasonStatusSharp.Active && !seasonStatusSharp.EarlyEnded && seasonStatusSharp.SeasonId == 1)
            {
                _ = await MintAsync(_player2, MintPayment.Normal, AwesomeAvatarsErrors.SeasonClosed);
            }

            seasonStatusSharp = await _client.GetCurrentSeasonStatusAsync(null, CancellationToken.None);
            Assert.That(seasonStatusSharp, Is.Not.Null);

            Assert.That(seasonStatusSharp.Early && !seasonStatusSharp.Active && !seasonStatusSharp.EarlyEnded && seasonStatusSharp.SeasonId == 1, Is.True, "Conditions maintained");
        }

        [Test, Order(9)]
        public async Task EarlySeasonPlayer1TestsAsync()
        {
            var avatars = await GetAvatarIdsAsync(_player1);

            Assert.That((await ForgeAsync(_player1, 
                avatars[0], [avatars[1]], null)).IsSuccess, Is.True);

            Assert.That((await TransferAvatarAsync(_player1,
                _player2.ToAccountId32(), avatars[2], AwesomeAvatarsErrors.FeatureLocked)).IsSuccess, Is.True);

            Assert.That((await EnableAffiliatorAsync(_player1,
                UnlockTarget.OneselfFree, null, 1, AwesomeAvatarsErrors.UnlockCriteriaNotFullfilled)).IsSuccess, Is.True);
        }


        [Test, Order(10)]
        public async Task EarlySeasonPlayer2TestsAsync()
        {
            Assert.True(true);
        }

        [Test, Order(11)]
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

        [Test, Order(12)]
        public async Task FullMintConfigTestAsync()
        {
            Assert.That((await GlobalConfigAsync(_organizer,
                new MintConfigSharp(false, 1, 1), null, null, null, null, null, null, null)).IsSuccess, Is.True);

            _ = await MintAsync(_player1, MintPayment.Free, AwesomeAvatarsErrors.MintClosed);

            Assert.That((await GlobalConfigAsync(_organizer,
                new MintConfigSharp(true, 1, 1), null, null, null, null, null, null, null)).IsSuccess, Is.True);

            _ = await MintAsync(_player1, MintPayment.Free, null);
        }

        [Test, Order(13)]
        public async Task FullForgeConfigTestAsync()
        {
            Assert.That((await GlobalConfigAsync(_organizer,
                null, new ForgeConfigSharp(false), null, null, null, null, null, null)).IsSuccess, Is.True);

            var avatars = await GetAvatarIdsAsync(_player1);

            _ = await ForgeAsync(_player1, avatars[0], [avatars[1]], AwesomeAvatarsErrors.ForgeClosed);

            Assert.That((await GlobalConfigAsync(_organizer,
                null, new ForgeConfigSharp(true), null, null, null, null, null, null)).IsSuccess, Is.True);

            _ = await ForgeAsync(_player1, avatars[0], [avatars[1]], null);
        }

        [Test, Order(14)]
        public async Task FullAvatarTransferConfigTestAsync()
        {
            Assert.That((await GlobalConfigAsync(_organizer,
                null, null, new AvatarTransferConfigSharp(false), null, null, null, null, null)).IsSuccess, Is.True);

            var avatars = await GetAvatarIdsAsync(_player1);
            _ = await TransferAvatarAsync(_player1, _player2.ToAccountId32(), avatars[0], AwesomeAvatarsErrors.TransferClosed);

            Assert.That((await GlobalConfigAsync(_organizer,
                null, null, new AvatarTransferConfigSharp(true), null, null, null, null, null)).IsSuccess, Is.True);

            _ = await TransferAvatarAsync(_player1, _player2.ToAccountId32(), avatars[0], AwesomeAvatarsErrors.FeatureLocked);
        }

        [Test, Order(15)]
        public async Task FullFreemintTransferConfigTestAsync()
        {
            Assert.That((await GlobalConfigAsync(_organizer,
                null, null, null, new FreemintTransferConfigSharp(FreeMintTransferMode.Closed, 1, 2), null, null, null, null)).IsSuccess, Is.True);

            Assert.That((await TransferFreeMintsAsync(_player1,
                _organizer.ToAccountId32(), 10, AwesomeAvatarsErrors.FreeMintTransferClosed)).IsSuccess, Is.True);

            Assert.That((await GlobalConfigAsync(_organizer,
                null, null, null, new FreemintTransferConfigSharp(FreeMintTransferMode.Open, 1, 2), null, null, null, null)).IsSuccess, Is.True);

            Assert.That((await TransferFreeMintsAsync(_player1,
                _organizer.ToAccountId32(), 2, null)).IsSuccess, Is.True);

            Assert.That((await GlobalConfigAsync(_organizer,
                null, null, null, new FreemintTransferConfigSharp(FreeMintTransferMode.WhitelistOnly, 1, 2), null, null, null, null)).IsSuccess, Is.True);

            Assert.That((await TransferFreeMintsAsync(_player1,
                _organizer.ToAccountId32(), 2, AwesomeAvatarsErrors.FreeMintTransferClosed)).IsSuccess, Is.True);

            Assert.That((await ModifyFreemintWhitelistAsync(_player1,
                _player1.ToAccountId32(), WhitelistOperation.AddAccount, DispatchError.BadOrigin)).IsSuccess, Is.True);

            Assert.That((await ModifyFreemintWhitelistAsync(_player1,
                _player1.ToAccountId32(), WhitelistOperation.AddAccount, DispatchError.BadOrigin)).IsSuccess, Is.True);

            Assert.That((await ModifyFreemintWhitelistAsync(_organizer,
                _player1.ToAccountId32(), WhitelistOperation.AddAccount, null)).IsSuccess, Is.True);

            Assert.That((await TransferFreeMintsAsync(_player1,
                _organizer.ToAccountId32(), 2, null)).IsSuccess, Is.True);

            Assert.That((await ModifyFreemintWhitelistAsync(_organizer,
                _player1.ToAccountId32(), WhitelistOperation.RemoveAccount, null)).IsSuccess, Is.True);
        }

        [Test, Order(16)]
        public async Task FullTradeConfigTestAsync()
        {
            Assert.That((await GlobalConfigAsync(_organizer,
                null, null, null, null, new TradeConfigSharp(false), null, null, null)).IsSuccess, Is.True);

            var avatars = await GetAvatarIdsAsync(_player1);

            Assert.That((await SetPriceAsync(_player1,
                avatars[0], new BigInteger(5 * SubstrateNetwork.DECIMALS), AwesomeAvatarsErrors.TradeClosed)).IsSuccess, Is.True);

            Assert.That((await GlobalConfigAsync(_organizer,
                null, null, null, null, new TradeConfigSharp(true), null, null, null)).IsSuccess, Is.True);

            Assert.That((await SetPriceAsync(_player1,
                avatars[0], new BigInteger(5 * SubstrateNetwork.DECIMALS), AwesomeAvatarsErrors.FeatureLocked)).IsSuccess, Is.True);

            var accountDataSharp = await _client.GetAccountAsync(_player1, null, CancellationToken.None);
            var preFree = (long)accountDataSharp.Data.Free;

            Assert.That((await EnableSetAvatarPriceAsync(_player1,
                UnlockTarget.OneselfFree, null, 1, AwesomeAvatarsErrors.UnlockCriteriaNotFullfilled)).IsSuccess, Is.True);

            Assert.That((await EnableSetAvatarPriceAsync(_player1,
                UnlockTarget.OneselfPaying, null, 1, null)).IsSuccess, Is.True);

            accountDataSharp = await _client.GetAccountAsync(_player1, null, CancellationToken.None);
            var postFree = (long)accountDataSharp.Data.Free;

            Assert.That(preFree - postFree, Is.GreaterThan(50 * SubstrateNetwork.DECIMALS));
            Assert.That(preFree - postFree, Is.LessThan(55 * SubstrateNetwork.DECIMALS));

            var avatarPrice = new BigInteger(5 * SubstrateNetwork.DECIMALS);
            Assert.That((await SetPriceAsync(_player1,
                avatars[0], avatarPrice, null)).IsSuccess, Is.True);

            var key = new BaseTuple<U16, H256>(new U16(_seasonId), avatars[0]);
            var tradePrice = await _client.GetTradeAsync(key, null, CancellationToken.None);

            Assert.That(tradePrice, Is.EqualTo(avatarPrice));

            Assert.That((await RemovePriceAsync(_player1,
                avatars[0], null)).IsSuccess, Is.True);

            Assert.That(await _client.GetTradeAsync(key, null, CancellationToken.None), Is.Null);
        }

        /// <summary>
        /// Mint
        /// </summary>
        /// <param name="account"></param>
        /// <param name="mintPayment"></param>
        /// <param name="avatarsErrors"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, ExtrinsicInfo ExtrinsicInfo)> MintAsync(Account account, MintPayment mintPayment, AwesomeAvatarsErrors? avatarsErrors)
        {
            var method = AwesomeAvatarsCalls.Mint(new MintOptionSharp(mintPayment, PackType.Special, MintPackSize.Six).ToSubstrate());
            return await ExecuteTransactionTestAsync(account, method, avatarsErrors, TimeSpan.FromSeconds(90));
        }

        /// <summary>
        /// Forge
        /// </summary>
        /// <param name="account"></param>
        /// <param name="leader"></param>
        /// <param name="sacrifices"></param>
        /// <param name="avatarsErrors"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, ExtrinsicInfo ExtrinsicInfo)> ForgeAsync(Account account, H256 leader, H256[] sacrifices, AwesomeAvatarsErrors? avatarsErrors)
        {
            var method = AwesomeAvatarsCalls.Forge(leader, new BaseVec<H256>(sacrifices));
            return await ExecuteTransactionTestAsync(account, method, avatarsErrors, TimeSpan.FromSeconds(90));
        }

        /// <summary>
        /// Transfer avatar
        /// </summary>
        /// <param name="account"></param>
        /// <param name="to"></param>
        /// <param name="amount"></param>
        /// <param name="avatarsErrors"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, ExtrinsicInfo ExtrinsicInfo)> TransferFreeMintsAsync(Account account, AccountId32 to, ushort amount, AwesomeAvatarsErrors? avatarsErrors)
        {
            var method = AwesomeAvatarsCalls.TransferFreeMints(to, new U16(amount));
            return await ExecuteTransactionTestAsync(account, method, avatarsErrors, TimeSpan.FromSeconds(90));
        }

        /// <summary>
        /// Transfer avatar
        /// </summary>
        /// <param name="account"></param>
        /// <param name="to"></param>
        /// <param name="avatarId"></param>
        /// <param name="avatarsErrors"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, ExtrinsicInfo ExtrinsicInfo)> TransferAvatarAsync(Account account, AccountId32 to, H256 avatarId, AwesomeAvatarsErrors? avatarsErrors)
        {
            var method = AwesomeAvatarsCalls.TransferAvatar(to, avatarId);
            return await ExecuteTransactionTestAsync(account, method, avatarsErrors, TimeSpan.FromSeconds(90));
        }

        /// <summary>
        /// Add affiliation
        /// </summary>
        /// <param name="account"></param>
        /// <param name="affiliateId"></param>
        /// <param name="seasonId"></param>
        /// <param name="avatarsErrors"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, ExtrinsicInfo ExtrinsicInfo)> AddAffiliationAsync(Account account, uint affiliateId, ushort seasonId, AwesomeAvatarsErrors? avatarsErrors)
        {
            var method = AwesomeAvatarsCalls.AddAffiliation(new U32(affiliateId), new U16(seasonId));
            return await ExecuteTransactionTestAsync(account, method, avatarsErrors, TimeSpan.FromSeconds(90));
        }

        /// <summary>
        /// Buy
        /// </summary>
        /// <param name="account"></param>
        /// <param name="avatarId"></param>
        /// <param name="avatarsErrors"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, ExtrinsicInfo ExtrinsicInfo)> BuyAsync(Account account, H256 avatarId, AwesomeAvatarsErrors? avatarsErrors)
        {
            var method = AwesomeAvatarsCalls.Buy(avatarId);
            return await ExecuteTransactionTestAsync(account, method, avatarsErrors, TimeSpan.FromSeconds(90));
        }

        /// <summary>
        /// Set price
        /// </summary>
        /// <param name="account"></param>
        /// <param name="avatarId"></param>
        /// <param name="price"></param>
        /// <param name="avatarsErrors"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, ExtrinsicInfo ExtrinsicInfo)> SetPriceAsync(Account account, H256 avatarId, BigInteger price, AwesomeAvatarsErrors? avatarsErrors)
        {
            var method = AwesomeAvatarsCalls.SetPrice(avatarId, new BaseCom<U128>(price));
            return await ExecuteTransactionTestAsync(account, method, avatarsErrors, TimeSpan.FromSeconds(90));
        }

        /// <summary>
        /// Remove price
        /// </summary>
        /// <param name="account"></param>
        /// <param name="avatarId"></param>
        /// <param name="avatarsErrors"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, ExtrinsicInfo ExtrinsicInfo)> RemovePriceAsync(Account account, H256 avatarId, AwesomeAvatarsErrors? avatarsErrors)
        {
            var method = AwesomeAvatarsCalls.RemovePrice(avatarId);
            return await ExecuteTransactionTestAsync(account, method, avatarsErrors, TimeSpan.FromSeconds(90));
        }

        /// <summary>
        /// Enable affiliator
        /// </summary>
        /// <param name="account"></param>
        /// <param name="unlockTarget"></param>
        /// <param name="other"></param>
        /// <param name="seasonId"></param>
        /// <param name="avatarsErrors"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, ExtrinsicInfo ExtrinsicInfo)> EnableAffiliatorAsync(Account account, UnlockTarget unlockTarget, AccountId32? other, ushort seasonId, AwesomeAvatarsErrors? avatarsErrors)
        {
            var enumAffiliatorTarget = new EnumUnlockTarget();
            IType otherAccount = other != null ? other : new BaseVoid();
            enumAffiliatorTarget.Create(unlockTarget, otherAccount);
            var method = AwesomeAvatarsCalls.EnableAffiliator(enumAffiliatorTarget, new U16(seasonId));
            return await ExecuteTransactionTestAsync(account, method, avatarsErrors, TimeSpan.FromSeconds(90));
        }

        /// <summary>
        /// Enable avatar transfer
        /// </summary>
        /// <param name="account"></param>
        /// <param name="unlockTarget"></param>
        /// <param name="other"></param>
        /// <param name="seasonId"></param>
        /// <param name="avatarsErrors"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, ExtrinsicInfo ExtrinsicInfo)> EnableAvatarTransferAsync(Account account, UnlockTarget unlockTarget, AccountId32? other, ushort seasonId, AwesomeAvatarsErrors? avatarsErrors)
        {
            var enumAffiliatorTarget = new EnumUnlockTarget();
            IType otherAccount = other != null ? other : new BaseVoid();
            enumAffiliatorTarget.Create(unlockTarget, otherAccount);
            var method = AwesomeAvatarsCalls.EnableAvatarTransfer(enumAffiliatorTarget, new U16(seasonId));
            return await ExecuteTransactionTestAsync(account, method, avatarsErrors, TimeSpan.FromSeconds(90));
        }

        /// <summary>
        /// Enable set avatar price
        /// </summary>
        /// <param name="account"></param>
        /// <param name="unlockTarget"></param>
        /// <param name="other"></param>
        /// <param name="seasonId"></param>
        /// <param name="avatarsErrors"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, ExtrinsicInfo ExtrinsicInfo)> EnableSetAvatarPriceAsync(Account account, UnlockTarget unlockTarget, AccountId32? other, ushort seasonId, AwesomeAvatarsErrors? avatarsErrors)
        {
            var enumAffiliatorTarget = new EnumUnlockTarget();
            IType otherAccount = other != null ? other : new BaseVoid();
            enumAffiliatorTarget.Create(unlockTarget, otherAccount);
            var method = AwesomeAvatarsCalls.EnableSetAvatarPrice(enumAffiliatorTarget, new U16(seasonId));
            return await ExecuteTransactionTestAsync(account, method, avatarsErrors, TimeSpan.FromSeconds(90));
        }

        /// <summary>
        /// Modify freemint whitelist
        /// </summary>
        /// <param name="account"></param>
        /// <param name="accountId"></param>
        /// <param name="whiteListOperation"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, ExtrinsicInfo ExtrinsicInfo)> ModifyFreemintWhitelistAsync(Account account, AccountId32 accountId, WhitelistOperation whiteListOperation, DispatchError? error)
        {
            var enumWhitelistMode = new EnumWhitelistOperation();
            enumWhitelistMode.Create(whiteListOperation);
            var method = AwesomeAvatarsCalls.ModifyFreemintWhitelist(accountId, enumWhitelistMode);
            return await ExecuteTransactionTestAsync(account, method, error, TimeSpan.FromSeconds(90));
        }

        /// <summary>
        /// Global configuration
        /// </summary>
        /// <param name="account"></param>
        /// <param name="mintConfigSharp"></param>
        /// <param name="forgeConfigSharp"></param>
        /// <param name="avatarTransferConfigSharp"></param>
        /// <param name="freemintTransferConfigSharp"></param>
        /// <param name="tradeConfigSharp"></param>
        /// <param name="nftTransferConfigSharp"></param>
        /// <param name="affiliateConfigSharp"></param>
        /// <param name="avatarsErrors"></param>
        /// <returns></returns>
        private async Task<(bool IsSuccess, ExtrinsicInfo ExtrinsicInfo)> GlobalConfigAsync(Account account, MintConfigSharp? mintConfigSharp, ForgeConfigSharp? forgeConfigSharp, AvatarTransferConfigSharp? avatarTransferConfigSharp, FreemintTransferConfigSharp? freemintTransferConfigSharp, TradeConfigSharp? tradeConfigSharp, NftTransferConfigSharp? nftTransferConfigSharp, AffiliateConfigSharp? affiliateConfigSharp, AwesomeAvatarsErrors? avatarsErrors)
        {
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

            var method = AwesomeAvatarsCalls.UpdateGlobalConfig(globalConfig);

            return await ExecuteTransactionTestAsync(account, method, avatarsErrors, TimeSpan.FromSeconds(90));
        }

        /// <summary>
        /// Unlock config
        /// </summary>
        /// <param name="account"></param>
        /// <param name="seasonId"></param>
        /// <param name="unlockConfigs"></param>
        /// <param name="avatarsErrors"></param>
        /// <returns></returns>
        private async Task<(bool IsSuccess, ExtrinsicInfo ExtrinsicInfo)> UnlockConfigAsync(Account account, ushort seasonId, UnlockConfigs unlockConfigs, AwesomeAvatarsErrors? avatarsErrors)
        {
            var method = AwesomeAvatarsCalls.SetUnlockConfig(new U16(seasonId), unlockConfigs);
            return await ExecuteTransactionTestAsync(account, method, avatarsErrors, TimeSpan.FromSeconds(90));
        }

        /// <summary>
        /// Get avatar ids
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<List<H256>> GetAvatarIdsAsync(Account account)
        {
            var key = new BaseTuple<AccountId32, U16>();
            key.Create(account.ToAccountId32(), new U16(_seasonId));

            var avatars = await _client.GetOwnersAsync(key, null, CancellationToken.None);
            Assert.That(avatars, Is.Not.Null);

            return avatars.Select(p => p.ToH256()).ToList();
        }
    }
}