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


namespace Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_preimage.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> note_preimage
        /// See [`Pallet::note_preimage`].
        /// </summary>
        note_preimage = 0,
        
        /// <summary>
        /// >> unnote_preimage
        /// See [`Pallet::unnote_preimage`].
        /// </summary>
        unnote_preimage = 1,
        
        /// <summary>
        /// >> request_preimage
        /// See [`Pallet::request_preimage`].
        /// </summary>
        request_preimage = 2,
        
        /// <summary>
        /// >> unrequest_preimage
        /// See [`Pallet::unrequest_preimage`].
        /// </summary>
        unrequest_preimage = 3,
        
        /// <summary>
        /// >> ensure_updated
        /// See [`Pallet::ensure_updated`].
        /// </summary>
        ensure_updated = 4,
    }
    
    /// <summary>
    /// >> 325 - Variant[pallet_preimage.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256>>
    {
    }
}
