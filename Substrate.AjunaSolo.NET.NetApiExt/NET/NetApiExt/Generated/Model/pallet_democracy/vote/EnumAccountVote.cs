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


namespace Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.pallet_democracy.vote
{
    
    
    /// <summary>
    /// >> AccountVote
    /// </summary>
    public enum AccountVote
    {
        
        /// <summary>
        /// >> Standard
        /// </summary>
        Standard = 0,
        
        /// <summary>
        /// >> Split
        /// </summary>
        Split = 1,
    }
    
    /// <summary>
    /// >> 52 - Variant[pallet_democracy.vote.AccountVote]
    /// </summary>
    public sealed class EnumAccountVote : BaseEnumExt<AccountVote, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.pallet_democracy.vote.Vote, Substrate.NetApi.Model.Types.Primitive.U128>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>
    {
    }
}
