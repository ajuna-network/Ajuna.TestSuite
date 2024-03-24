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


namespace Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_utility.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> batch
        /// See [`Pallet::batch`].
        /// </summary>
        batch = 0,
        
        /// <summary>
        /// >> as_derivative
        /// See [`Pallet::as_derivative`].
        /// </summary>
        as_derivative = 1,
        
        /// <summary>
        /// >> batch_all
        /// See [`Pallet::batch_all`].
        /// </summary>
        batch_all = 2,
        
        /// <summary>
        /// >> dispatch_as
        /// See [`Pallet::dispatch_as`].
        /// </summary>
        dispatch_as = 3,
        
        /// <summary>
        /// >> force_batch
        /// See [`Pallet::force_batch`].
        /// </summary>
        force_batch = 4,
        
        /// <summary>
        /// >> with_weight
        /// See [`Pallet::with_weight`].
        /// </summary>
        with_weight = 5,
    }
    
    /// <summary>
    /// >> 266 - Variant[pallet_utility.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime.EnumRuntimeCall>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime.EnumRuntimeCall>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime.EnumRuntimeCall>, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime.EnumOriginCaller, Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime.EnumRuntimeCall>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime.EnumRuntimeCall>, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime.EnumRuntimeCall, Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight>>
    {
    }
}
