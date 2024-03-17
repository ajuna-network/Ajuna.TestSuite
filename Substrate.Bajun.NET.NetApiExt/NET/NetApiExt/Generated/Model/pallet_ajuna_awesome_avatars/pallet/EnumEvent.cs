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
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> OrganizerSet
        /// An organizer has been set.
        /// </summary>
        OrganizerSet = 0,
        
        /// <summary>
        /// >> ServiceAccountSet
        /// A service account has been set.
        /// </summary>
        ServiceAccountSet = 1,
        
        /// <summary>
        /// >> CollectionIdSet
        /// A collection ID has been set.
        /// </summary>
        CollectionIdSet = 2,
        
        /// <summary>
        /// >> TreasurerSet
        /// A treasurer has been set for a season.
        /// </summary>
        TreasurerSet = 3,
        
        /// <summary>
        /// >> TreasuryClaimed
        /// A season's treasury has been claimed by a treasurer.
        /// </summary>
        TreasuryClaimed = 4,
        
        /// <summary>
        /// >> UpdatedSeason
        /// The season configuration for {season_id} has been updated.
        /// </summary>
        UpdatedSeason = 5,
        
        /// <summary>
        /// >> UpdatedGlobalConfig
        /// Global configuration updated.
        /// </summary>
        UpdatedGlobalConfig = 6,
        
        /// <summary>
        /// >> AvatarsMinted
        /// Avatars minted.
        /// </summary>
        AvatarsMinted = 7,
        
        /// <summary>
        /// >> AvatarsForged
        /// Avatar forged.
        /// </summary>
        AvatarsForged = 8,
        
        /// <summary>
        /// >> AvatarTransferred
        /// Avatar transferred.
        /// </summary>
        AvatarTransferred = 9,
        
        /// <summary>
        /// >> SeasonStarted
        /// A season has started.
        /// </summary>
        SeasonStarted = 10,
        
        /// <summary>
        /// >> SeasonFinished
        /// A season has finished.
        /// </summary>
        SeasonFinished = 11,
        
        /// <summary>
        /// >> FreeMintsTransferred
        /// Free mints transferred between accounts.
        /// </summary>
        FreeMintsTransferred = 12,
        
        /// <summary>
        /// >> FreeMintsSet
        /// Free mints set for target account.
        /// </summary>
        FreeMintsSet = 13,
        
        /// <summary>
        /// >> AvatarPriceSet
        /// Avatar has price set for trade.
        /// </summary>
        AvatarPriceSet = 14,
        
        /// <summary>
        /// >> AvatarPriceUnset
        /// Avatar has price removed for trade.
        /// </summary>
        AvatarPriceUnset = 15,
        
        /// <summary>
        /// >> AvatarTraded
        /// Avatar has been traded.
        /// </summary>
        AvatarTraded = 16,
        
        /// <summary>
        /// >> AvatarLocked
        /// Avatar locked.
        /// </summary>
        AvatarLocked = 17,
        
        /// <summary>
        /// >> AvatarUnlocked
        /// Avatar unlocked.
        /// </summary>
        AvatarUnlocked = 18,
        
        /// <summary>
        /// >> StorageTierUpgraded
        /// Storage tier has been upgraded.
        /// </summary>
        StorageTierUpgraded = 19,
        
        /// <summary>
        /// >> PreparedAvatar
        /// Avatar prepared.
        /// </summary>
        PreparedAvatar = 20,
        
        /// <summary>
        /// >> UnpreparedAvatar
        /// Avatar unprepared.
        /// </summary>
        UnpreparedAvatar = 21,
        
        /// <summary>
        /// >> PreparedIpfsUrl
        /// IPFS URL prepared.
        /// </summary>
        PreparedIpfsUrl = 22,
    }
    
    /// <summary>
    /// >> 147 - Variant[pallet_ajuna_awesome_avatars.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.season.Season>, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.season.SeasonMeta>, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.season.SeasonSchedule>, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.season.TradeFilters>>, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.GlobalConfig, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.NetApi.Model.Types.Primitive.U8>>, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256>, Substrate.NetApi.Model.Types.Primitive.U16, Substrate.NetApi.Model.Types.Primitive.U16, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U16>, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U16>, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U16>, Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.Bajun.NET.NetApiExt.Generated.Model.bounded_collections.bounded_vec.BoundedVecT10>
    {
    }
}
