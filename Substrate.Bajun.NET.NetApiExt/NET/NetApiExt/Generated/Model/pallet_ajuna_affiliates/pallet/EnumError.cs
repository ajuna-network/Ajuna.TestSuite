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


namespace Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_affiliates.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> CannotAffiliateSelf
        /// An account cannot affiliate itself
        /// </summary>
        CannotAffiliateSelf = 0,
        
        /// <summary>
        /// >> TargetAccountIsNotAffiliatable
        /// The account is not allowed to receive affiliates
        /// </summary>
        TargetAccountIsNotAffiliatable = 1,
        
        /// <summary>
        /// >> CannotAffiliateMoreAccounts
        /// This account has reached the affiliate limit
        /// </summary>
        CannotAffiliateMoreAccounts = 2,
        
        /// <summary>
        /// >> CannotAffiliateAlreadyAffiliatedAccount
        /// This account has already been affiliated by another affiliator
        /// </summary>
        CannotAffiliateAlreadyAffiliatedAccount = 3,
        
        /// <summary>
        /// >> CannotAffiliateToExistingAffiliator
        /// This account is already an affiliator, so it cannot affiliate to another account
        /// </summary>
        CannotAffiliateToExistingAffiliator = 4,
        
        /// <summary>
        /// >> CannotAffiliateBlocked
        /// The account is blocked, so it cannot be affiliated to
        /// </summary>
        CannotAffiliateBlocked = 5,
        
        /// <summary>
        /// >> ExtrinsicAlreadyHasRule
        /// The given extrinsic identifier is already paired with an affiliate rule
        /// </summary>
        ExtrinsicAlreadyHasRule = 6,
        
        /// <summary>
        /// >> ExtrinsicHasNoRule
        /// The given extrinsic identifier is not associated with any rule
        /// </summary>
        ExtrinsicHasNoRule = 7,
    }
    
    /// <summary>
    /// >> 616 - Variant[pallet_ajuna_affiliates.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
