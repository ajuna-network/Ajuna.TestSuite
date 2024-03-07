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


namespace Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.pallet_grandpa.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> report_equivocation
        /// See [`Pallet::report_equivocation`].
        /// </summary>
        report_equivocation = 0,
        
        /// <summary>
        /// >> report_equivocation_unsigned
        /// See [`Pallet::report_equivocation_unsigned`].
        /// </summary>
        report_equivocation_unsigned = 1,
        
        /// <summary>
        /// >> note_stalled
        /// See [`Pallet::note_stalled`].
        /// </summary>
        note_stalled = 2,
    }
    
    /// <summary>
    /// >> 143 - Variant[pallet_grandpa.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.sp_consensus_grandpa.EquivocationProof, Substrate.NetApi.Model.Types.Base.BaseVoid>, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.sp_consensus_grandpa.EquivocationProof, Substrate.NetApi.Model.Types.Base.BaseVoid>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}