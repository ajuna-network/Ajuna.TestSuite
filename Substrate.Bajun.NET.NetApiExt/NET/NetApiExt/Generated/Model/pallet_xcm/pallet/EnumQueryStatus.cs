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


namespace Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_xcm.pallet
{
    
    
    /// <summary>
    /// >> QueryStatus
    /// </summary>
    public enum QueryStatus
    {
        
        /// <summary>
        /// >> Pending
        /// </summary>
        Pending = 0,
        
        /// <summary>
        /// >> VersionNotifier
        /// </summary>
        VersionNotifier = 1,
        
        /// <summary>
        /// >> Ready
        /// </summary>
        Ready = 2,
    }
    
    /// <summary>
    /// >> 498 - Variant[pallet_xcm.pallet.QueryStatus]
    /// </summary>
    public sealed class EnumQueryStatus : BaseEnumExt<QueryStatus, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.xcm.EnumVersionedLocation, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Bajun.NET.NetApiExt.Generated.Model.xcm.EnumVersionedLocation>, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.U8>>, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.xcm.EnumVersionedLocation, Substrate.NetApi.Model.Types.Primitive.Bool>, BaseTuple<Substrate.Bajun.NET.NetApiExt.Generated.Model.xcm.EnumVersionedResponse, Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}