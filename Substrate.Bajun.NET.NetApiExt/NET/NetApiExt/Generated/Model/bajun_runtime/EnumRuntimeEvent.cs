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


namespace Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime
{
    
    
    /// <summary>
    /// >> RuntimeEvent
    /// </summary>
    public enum RuntimeEvent
    {
        
        /// <summary>
        /// >> System
        /// </summary>
        System = 0,
        
        /// <summary>
        /// >> ParachainSystem
        /// </summary>
        ParachainSystem = 1,
        
        /// <summary>
        /// >> Multisig
        /// </summary>
        Multisig = 4,
        
        /// <summary>
        /// >> Utility
        /// </summary>
        Utility = 5,
        
        /// <summary>
        /// >> Identity
        /// </summary>
        Identity = 6,
        
        /// <summary>
        /// >> Proxy
        /// </summary>
        Proxy = 7,
        
        /// <summary>
        /// >> Scheduler
        /// </summary>
        Scheduler = 8,
        
        /// <summary>
        /// >> Preimage
        /// </summary>
        Preimage = 9,
        
        /// <summary>
        /// >> Balances
        /// </summary>
        Balances = 15,
        
        /// <summary>
        /// >> TransactionPayment
        /// </summary>
        TransactionPayment = 16,
        
        /// <summary>
        /// >> Vesting
        /// </summary>
        Vesting = 17,
        
        /// <summary>
        /// >> CollatorSelection
        /// </summary>
        CollatorSelection = 21,
        
        /// <summary>
        /// >> Session
        /// </summary>
        Session = 22,
        
        /// <summary>
        /// >> XcmpQueue
        /// </summary>
        XcmpQueue = 30,
        
        /// <summary>
        /// >> PolkadotXcm
        /// </summary>
        PolkadotXcm = 31,
        
        /// <summary>
        /// >> CumulusXcm
        /// </summary>
        CumulusXcm = 32,
        
        /// <summary>
        /// >> MessageQueue
        /// </summary>
        MessageQueue = 34,
        
        /// <summary>
        /// >> Sudo
        /// </summary>
        Sudo = 40,
        
        /// <summary>
        /// >> Treasury
        /// </summary>
        Treasury = 41,
        
        /// <summary>
        /// >> Council
        /// </summary>
        Council = 42,
        
        /// <summary>
        /// >> CouncilMembership
        /// </summary>
        CouncilMembership = 43,
        
        /// <summary>
        /// >> TechnicalCommittee
        /// </summary>
        TechnicalCommittee = 44,
        
        /// <summary>
        /// >> TechnicalCommitteeMembership
        /// </summary>
        TechnicalCommitteeMembership = 45,
        
        /// <summary>
        /// >> Democracy
        /// </summary>
        Democracy = 46,
        
        /// <summary>
        /// >> AwesomeAvatars
        /// </summary>
        AwesomeAvatars = 51,
        
        /// <summary>
        /// >> Nft
        /// </summary>
        Nft = 60,
        
        /// <summary>
        /// >> NftTransfer
        /// </summary>
        NftTransfer = 61,
        
        /// <summary>
        /// >> AffiliatesAAA
        /// </summary>
        AffiliatesAAA = 70,
    }
    
    /// <summary>
    /// >> 20 - Variant[bajun_runtime.RuntimeEvent]
    /// </summary>
    public sealed class EnumRuntimeEvent : BaseEnumExt<RuntimeEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.frame_system.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.cumulus_pallet_parachain_system.pallet.EnumEvent, BaseVoid, BaseVoid, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_multisig.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_utility.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_identity.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_proxy.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_scheduler.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_preimage.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_balances.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_transaction_payment.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.orml_vesting.module.EnumEvent, BaseVoid, BaseVoid, BaseVoid, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_collator_selection.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_session.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Substrate.Bajun.NET.NetApiExt.Generated.Model.cumulus_pallet_xcmp_queue.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_xcm.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.cumulus_pallet_xcm.pallet.EnumEvent, BaseVoid, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_message_queue.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_sudo.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_treasury.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_collective.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_membership.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_collective.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_membership.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_democracy.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_nfts.pallet.EnumEvent, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_nft_transfer.pallet.EnumEvent, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_affiliates.pallet.EnumEvent>
    {
    }
}