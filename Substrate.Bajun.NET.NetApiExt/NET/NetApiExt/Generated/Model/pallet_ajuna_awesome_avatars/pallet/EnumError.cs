//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> OrganizerNotSet
        /// There is no account set as the organizer
        /// </summary>
        OrganizerNotSet = 0,
        
        /// <summary>
        /// >> CollectionIdNotSet
        /// There is no collection ID set for NFT handler.
        /// </summary>
        CollectionIdNotSet = 1,
        
        /// <summary>
        /// >> EarlyStartTooEarly
        /// The season starts before the previous season has ended.
        /// </summary>
        EarlyStartTooEarly = 2,
        
        /// <summary>
        /// >> EarlyStartTooLate
        /// The season season start later than its early access
        /// </summary>
        EarlyStartTooLate = 3,
        
        /// <summary>
        /// >> SeasonStartTooLate
        /// The season start date is newer than its end date.
        /// </summary>
        SeasonStartTooLate = 4,
        
        /// <summary>
        /// >> SeasonEndTooLate
        /// The season ends after the new season has started.
        /// </summary>
        SeasonEndTooLate = 5,
        
        /// <summary>
        /// >> PeriodConfigOverflow
        /// The season's per period and periods configuration overflows.
        /// </summary>
        PeriodConfigOverflow = 6,
        
        /// <summary>
        /// >> PeriodsIndivisible
        /// The season's periods configuration is indivisible by max variation.
        /// </summary>
        PeriodsIndivisible = 7,
        
        /// <summary>
        /// >> UnknownSeason
        /// The season doesn't exist.
        /// </summary>
        UnknownSeason = 8,
        
        /// <summary>
        /// >> UnknownAvatar
        /// The avatar doesn't exist.
        /// </summary>
        UnknownAvatar = 9,
        
        /// <summary>
        /// >> UnknownAvatarForSale
        /// The avatar for sale doesn't exist.
        /// </summary>
        UnknownAvatarForSale = 10,
        
        /// <summary>
        /// >> UnknownTier
        /// The tier doesn't exist.
        /// </summary>
        UnknownTier = 11,
        
        /// <summary>
        /// >> UnknownTreasurer
        /// The treasurer doesn't exist.
        /// </summary>
        UnknownTreasurer = 12,
        
        /// <summary>
        /// >> UnknownPreparation
        /// The preparation doesn't exist.
        /// </summary>
        UnknownPreparation = 13,
        
        /// <summary>
        /// >> NonSequentialSeasonId
        /// The season ID of a season to create is not sequential.
        /// </summary>
        NonSequentialSeasonId = 14,
        
        /// <summary>
        /// >> SingleMintProbsOverflow
        /// The sum of the given single mint probabilities overflows.
        /// </summary>
        SingleMintProbsOverflow = 15,
        
        /// <summary>
        /// >> BatchMintProbsOverflow
        /// The sum of the given batch mint probabilities overflows.
        /// </summary>
        BatchMintProbsOverflow = 16,
        
        /// <summary>
        /// >> IncorrectRarityPercentages
        /// Rarity percentages don't add up to 100
        /// </summary>
        IncorrectRarityPercentages = 17,
        
        /// <summary>
        /// >> TooManyRarityPercentages
        /// Max tier is achievable through forging only. Therefore the number of rarity percentages
        /// must be less than that of tiers for a season.
        /// </summary>
        TooManyRarityPercentages = 18,
        
        /// <summary>
        /// >> BaseProbTooHigh
        /// The given base probability is too high. It must be less than 100.
        /// </summary>
        BaseProbTooHigh = 19,
        
        /// <summary>
        /// >> DuplicatedRarityTier
        /// Some rarity tier are duplicated.
        /// </summary>
        DuplicatedRarityTier = 20,
        
        /// <summary>
        /// >> MintClosed
        /// Minting is not available at the moment.
        /// </summary>
        MintClosed = 21,
        
        /// <summary>
        /// >> ForgeClosed
        /// Forging is not available at the moment.
        /// </summary>
        ForgeClosed = 22,
        
        /// <summary>
        /// >> TransferClosed
        /// Transfer is not available at the moment.
        /// </summary>
        TransferClosed = 23,
        
        /// <summary>
        /// >> TradeClosed
        /// Trading is not available at the moment.
        /// </summary>
        TradeClosed = 24,
        
        /// <summary>
        /// >> NftTransferClosed
        /// NFT transfer is not available at the moment.
        /// </summary>
        NftTransferClosed = 25,
        
        /// <summary>
        /// >> FreeMintTransferClosed
        /// Free mint transfer is not available at the moment.
        /// </summary>
        FreeMintTransferClosed = 26,
        
        /// <summary>
        /// >> SeasonClosed
        /// Attempt to mint or forge outside of an active season.
        /// </summary>
        SeasonClosed = 27,
        
        /// <summary>
        /// >> PrematureSeasonEnd
        /// Attempt to mint when the season has ended prematurely.
        /// </summary>
        PrematureSeasonEnd = 28,
        
        /// <summary>
        /// >> MaxOwnershipReached
        /// Max ownership reached.
        /// </summary>
        MaxOwnershipReached = 29,
        
        /// <summary>
        /// >> MaxStorageTierReached
        /// Max storage tier reached.
        /// </summary>
        MaxStorageTierReached = 30,
        
        /// <summary>
        /// >> Ownership
        /// Avatar belongs to someone else.
        /// </summary>
        Ownership = 31,
        
        /// <summary>
        /// >> AlreadyOwned
        /// Attempt to buy his or her own avatar.
        /// </summary>
        AlreadyOwned = 32,
        
        /// <summary>
        /// >> IncorrectDna
        /// Incorrect DNA.
        /// </summary>
        IncorrectDna = 33,
        
        /// <summary>
        /// >> IncorrectData
        /// Incorrect data.
        /// </summary>
        IncorrectData = 34,
        
        /// <summary>
        /// >> IncorrectAvatarId
        /// Incorrect Avatar ID.
        /// </summary>
        IncorrectAvatarId = 35,
        
        /// <summary>
        /// >> IncorrectSeasonId
        /// Incorrect season ID.
        /// </summary>
        IncorrectSeasonId = 36,
        
        /// <summary>
        /// >> MintCooldown
        /// The player must wait cooldown period.
        /// </summary>
        MintCooldown = 37,
        
        /// <summary>
        /// >> MaxComponentsTooLow
        /// The season's max components value is less than the minimum allowed (1).
        /// </summary>
        MaxComponentsTooLow = 38,
        
        /// <summary>
        /// >> MaxComponentsTooHigh
        /// The season's max components value is more than the maximum allowed (random byte: 32).
        /// </summary>
        MaxComponentsTooHigh = 39,
        
        /// <summary>
        /// >> MaxVariationsTooLow
        /// The season's max variations value is less than the minimum allowed (1).
        /// </summary>
        MaxVariationsTooLow = 40,
        
        /// <summary>
        /// >> MaxVariationsTooHigh
        /// The season's max variations value is more than the maximum allowed (15).
        /// </summary>
        MaxVariationsTooHigh = 41,
        
        /// <summary>
        /// >> InsufficientFreeMints
        /// The player has not enough free mints available.
        /// </summary>
        InsufficientFreeMints = 42,
        
        /// <summary>
        /// >> InsufficientBalance
        /// The player has not enough balance available.
        /// </summary>
        InsufficientBalance = 43,
        
        /// <summary>
        /// >> TooLowFreeMints
        /// Attempt to transfer, issue or withdraw free mints lower than the minimum allowed.
        /// </summary>
        TooLowFreeMints = 44,
        
        /// <summary>
        /// >> TooFewSacrifices
        /// Less than minimum allowed sacrifices are used for forging.
        /// </summary>
        TooFewSacrifices = 45,
        
        /// <summary>
        /// >> TooManySacrifices
        /// More than maximum allowed sacrifices are used for forging.
        /// </summary>
        TooManySacrifices = 46,
        
        /// <summary>
        /// >> LeaderSacrificed
        /// Leader is being sacrificed.
        /// </summary>
        LeaderSacrificed = 47,
        
        /// <summary>
        /// >> AvatarCannotBeTraded
        /// This avatar cannot be used in trades.
        /// </summary>
        AvatarCannotBeTraded = 48,
        
        /// <summary>
        /// >> AvatarInTrade
        /// An avatar listed for trade is used to forge.
        /// </summary>
        AvatarInTrade = 49,
        
        /// <summary>
        /// >> AvatarLocked
        /// The avatar is currently locked and cannot be used.
        /// </summary>
        AvatarLocked = 50,
        
        /// <summary>
        /// >> AvatarUnlocked
        /// The avatar is currently unlocked and cannot be locked again.
        /// </summary>
        AvatarUnlocked = 51,
        
        /// <summary>
        /// >> IncorrectAvatarSeason
        /// Tried to forge avatars from different seasons.
        /// </summary>
        IncorrectAvatarSeason = 52,
        
        /// <summary>
        /// >> IncompatibleAvatarVersions
        /// Tried to forge avatars with different DNA versions.
        /// </summary>
        IncompatibleAvatarVersions = 53,
        
        /// <summary>
        /// >> InsufficientStorageForForging
        /// There's not enough space to hold the forging results
        /// </summary>
        InsufficientStorageForForging = 54,
        
        /// <summary>
        /// >> CannotTransferToSelf
        /// Tried transferring to his or her own account.
        /// </summary>
        CannotTransferToSelf = 55,
        
        /// <summary>
        /// >> CannotTransferFromInactiveAccount
        /// Tried transferring while the account still hasn't minted and forged anything.
        /// </summary>
        CannotTransferFromInactiveAccount = 56,
        
        /// <summary>
        /// >> CannotClaimDuringSeason
        /// Tried claiming treasury during a season.
        /// </summary>
        CannotClaimDuringSeason = 57,
        
        /// <summary>
        /// >> CannotClaimZero
        /// Tried claiming treasury which is zero.
        /// </summary>
        CannotClaimZero = 58,
        
        /// <summary>
        /// >> IncompatibleMintComponents
        /// The components tried to mint were not compatible.
        /// </summary>
        IncompatibleMintComponents = 59,
        
        /// <summary>
        /// >> IncompatibleForgeComponents
        /// The components tried to forge were not compatible.
        /// </summary>
        IncompatibleForgeComponents = 60,
        
        /// <summary>
        /// >> InsufficientSacrifices
        /// The amount of sacrifices is not sufficient for forging.
        /// </summary>
        InsufficientSacrifices = 61,
        
        /// <summary>
        /// >> ExcessiveSacrifices
        /// The amount of sacrifices is too much for forging.
        /// </summary>
        ExcessiveSacrifices = 62,
        
        /// <summary>
        /// >> AlreadyPrepared
        /// Tried to prepare an already prepared avatar.
        /// </summary>
        AlreadyPrepared = 63,
        
        /// <summary>
        /// >> NotPrepared
        /// Tried to prepare an IPFS URL for an avatar, that is not yet prepared.
        /// </summary>
        NotPrepared = 64,
        
        /// <summary>
        /// >> NoServiceAccount
        /// No service account has been set.
        /// </summary>
        NoServiceAccount = 65,
        
        /// <summary>
        /// >> EmptyIpfsUrl
        /// Tried to prepare an IPFS URL for an avatar with an empty URL.
        /// </summary>
        EmptyIpfsUrl = 66,
        
        /// <summary>
        /// >> AccountAlreadyInWhitelist
        /// The account trying to be whitelisted is already in the whitelist
        /// </summary>
        AccountAlreadyInWhitelist = 67,
        
        /// <summary>
        /// >> WhitelistedAccountsLimitReached
        /// Cannot add more accounts to the whitelist.
        /// </summary>
        WhitelistedAccountsLimitReached = 68,
        
        /// <summary>
        /// >> AffiliatorNotFound
        /// No account matches the provided affiliator identifier
        /// </summary>
        AffiliatorNotFound = 69,
        
        /// <summary>
        /// >> FeatureLocked
        /// The feature is locked for the current player
        /// </summary>
        FeatureLocked = 70,
        
        /// <summary>
        /// >> FeatureUnlockableInSeason
        /// The feature trying to be unlocked is not available for the selected season
        /// </summary>
        FeatureUnlockableInSeason = 71,
        
        /// <summary>
        /// >> UnlockCriteriaNotFullfilled
        /// The feature trying to be unlocked has missing requirements to be fullfilled by
        /// the accoutn trying to unlock it
        /// </summary>
        UnlockCriteriaNotFullfilled = 72,
    }
    
    /// <summary>
    /// >> 585 - Variant[pallet_ajuna_awesome_avatars.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
