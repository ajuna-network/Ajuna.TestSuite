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


namespace Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_balances.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> transfer_allow_death
        /// See [`Pallet::transfer_allow_death`].
        /// </summary>
        transfer_allow_death = 0,
        
        /// <summary>
        /// >> force_transfer
        /// See [`Pallet::force_transfer`].
        /// </summary>
        force_transfer = 2,
        
        /// <summary>
        /// >> transfer_keep_alive
        /// See [`Pallet::transfer_keep_alive`].
        /// </summary>
        transfer_keep_alive = 3,
        
        /// <summary>
        /// >> transfer_all
        /// See [`Pallet::transfer_all`].
        /// </summary>
        transfer_all = 4,
        
        /// <summary>
        /// >> force_unreserve
        /// See [`Pallet::force_unreserve`].
        /// </summary>
        force_unreserve = 5,
        
        /// <summary>
        /// >> upgrade_accounts
        /// See [`Pallet::upgrade_accounts`].
        /// </summary>
        upgrade_accounts = 6,
        
        /// <summary>
        /// >> force_set_balance
        /// See [`Pallet::force_set_balance`].
        /// </summary>
        force_set_balance = 8,
        
        /// <summary>
        /// >> force_adjust_total_issuance
        /// See [`Pallet::force_adjust_total_issuance`].
        /// </summary>
        force_adjust_total_issuance = 9,
    }
    
    /// <summary>
    /// >> 326 - Variant[pallet_balances.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>, BaseVoid, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.Bool>, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>, BaseVoid, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_balances.types.EnumAdjustmentDirection, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>
    {
    }
}
