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
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> Noted
        /// A preimage has been noted.
        /// </summary>
        Noted = 0,
        
        /// <summary>
        /// >> Requested
        /// A preimage has been requested.
        /// </summary>
        Requested = 1,
        
        /// <summary>
        /// >> Cleared
        /// A preimage has ben cleared.
        /// </summary>
        Cleared = 2,
    }
    
    /// <summary>
    /// >> 45 - Variant[pallet_preimage.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256>
    {
    }
}