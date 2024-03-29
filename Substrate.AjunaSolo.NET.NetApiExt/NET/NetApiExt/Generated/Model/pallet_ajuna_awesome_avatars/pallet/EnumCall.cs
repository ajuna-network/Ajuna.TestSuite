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


namespace Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> mint
        /// See [`Pallet::mint`].
        /// </summary>
        mint = 0,
        
        /// <summary>
        /// >> forge
        /// See [`Pallet::forge`].
        /// </summary>
        forge = 1,
        
        /// <summary>
        /// >> transfer_avatar
        /// See [`Pallet::transfer_avatar`].
        /// </summary>
        transfer_avatar = 2,
        
        /// <summary>
        /// >> transfer_free_mints
        /// See [`Pallet::transfer_free_mints`].
        /// </summary>
        transfer_free_mints = 3,
        
        /// <summary>
        /// >> set_price
        /// See [`Pallet::set_price`].
        /// </summary>
        set_price = 4,
        
        /// <summary>
        /// >> remove_price
        /// See [`Pallet::remove_price`].
        /// </summary>
        remove_price = 5,
        
        /// <summary>
        /// >> buy
        /// See [`Pallet::buy`].
        /// </summary>
        buy = 6,
        
        /// <summary>
        /// >> upgrade_storage
        /// See [`Pallet::upgrade_storage`].
        /// </summary>
        upgrade_storage = 7,
        
        /// <summary>
        /// >> set_organizer
        /// See [`Pallet::set_organizer`].
        /// </summary>
        set_organizer = 8,
        
        /// <summary>
        /// >> set_treasurer
        /// See [`Pallet::set_treasurer`].
        /// </summary>
        set_treasurer = 9,
        
        /// <summary>
        /// >> claim_treasury
        /// See [`Pallet::claim_treasury`].
        /// </summary>
        claim_treasury = 10,
        
        /// <summary>
        /// >> set_season
        /// See [`Pallet::set_season`].
        /// </summary>
        set_season = 11,
        
        /// <summary>
        /// >> update_global_config
        /// See [`Pallet::update_global_config`].
        /// </summary>
        update_global_config = 12,
        
        /// <summary>
        /// >> set_free_mints
        /// See [`Pallet::set_free_mints`].
        /// </summary>
        set_free_mints = 13,
        
        /// <summary>
        /// >> set_collection_id
        /// See [`Pallet::set_collection_id`].
        /// </summary>
        set_collection_id = 14,
        
        /// <summary>
        /// >> lock_avatar
        /// See [`Pallet::lock_avatar`].
        /// </summary>
        lock_avatar = 15,
        
        /// <summary>
        /// >> unlock_avatar
        /// See [`Pallet::unlock_avatar`].
        /// </summary>
        unlock_avatar = 16,
        
        /// <summary>
        /// >> set_service_account
        /// See [`Pallet::set_service_account`].
        /// </summary>
        set_service_account = 17,
        
        /// <summary>
        /// >> prepare_avatar
        /// See [`Pallet::prepare_avatar`].
        /// </summary>
        prepare_avatar = 18,
        
        /// <summary>
        /// >> unprepare_avatar
        /// See [`Pallet::unprepare_avatar`].
        /// </summary>
        unprepare_avatar = 19,
        
        /// <summary>
        /// >> prepare_ipfs
        /// See [`Pallet::prepare_ipfs`].
        /// </summary>
        prepare_ipfs = 20,
    }
    
    /// <summary>
    /// >> 260 - Variant[pallet_ajuna_awesome_avatars.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.MintOption, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256>>, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256>, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U16>, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U16>>, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>, Substrate.NetApi.Model.Types.Primitive.U16, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.season.Season>, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.GlobalConfig, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U16>, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.bounded_collections.bounded_vec.BoundedVecT7>>
    {
    }
}
