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


namespace Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.ajuna_solo_runtime
{
    
    
    /// <summary>
    /// >> OriginCaller
    /// </summary>
    public enum OriginCaller
    {
        
        /// <summary>
        /// >> system
        /// </summary>
        system = 0,
        
        /// <summary>
        /// >> Council
        /// </summary>
        Council = 9,
        
        /// <summary>
        /// >> TechnicalCommittee
        /// </summary>
        TechnicalCommittee = 10,
        
        /// <summary>
        /// >> Void
        /// </summary>
        Void = 3,
    }
    
    /// <summary>
    /// >> 255 - Variant[ajuna_solo_runtime.OriginCaller]
    /// </summary>
    public sealed class EnumOriginCaller : BaseEnumExt<OriginCaller, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.frame_support.dispatch.EnumRawOrigin, BaseVoid, BaseVoid, Substrate.NetApi.Model.Types.Base.BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.pallet_collective.EnumRawOrigin, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.pallet_collective.EnumRawOrigin>
    {
    }
}
