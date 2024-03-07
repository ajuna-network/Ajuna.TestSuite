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


namespace Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.pallet_scheduler.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> schedule
        /// See [`Pallet::schedule`].
        /// </summary>
        schedule = 0,
        
        /// <summary>
        /// >> cancel
        /// See [`Pallet::cancel`].
        /// </summary>
        cancel = 1,
        
        /// <summary>
        /// >> schedule_named
        /// See [`Pallet::schedule_named`].
        /// </summary>
        schedule_named = 2,
        
        /// <summary>
        /// >> cancel_named
        /// See [`Pallet::cancel_named`].
        /// </summary>
        cancel_named = 3,
        
        /// <summary>
        /// >> schedule_after
        /// See [`Pallet::schedule_after`].
        /// </summary>
        schedule_after = 4,
        
        /// <summary>
        /// >> schedule_named_after
        /// See [`Pallet::schedule_named_after`].
        /// </summary>
        schedule_named_after = 5,
    }
    
    /// <summary>
    /// >> 204 - Variant[pallet_scheduler.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.ajuna_solo_runtime.EnumRuntimeCall>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Types.Base.Arr32U8, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.ajuna_solo_runtime.EnumRuntimeCall>, Substrate.AjunaSolo.NET.NetApiExt.Generated.Types.Base.Arr32U8, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.ajuna_solo_runtime.EnumRuntimeCall>, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Types.Base.Arr32U8, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.ajuna_solo_runtime.EnumRuntimeCall>>
    {
    }
}
