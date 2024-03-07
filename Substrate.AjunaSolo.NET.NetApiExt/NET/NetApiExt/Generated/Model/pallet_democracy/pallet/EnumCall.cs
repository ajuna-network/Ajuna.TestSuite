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


namespace Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.pallet_democracy.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> propose
        /// See [`Pallet::propose`].
        /// </summary>
        propose = 0,
        
        /// <summary>
        /// >> second
        /// See [`Pallet::second`].
        /// </summary>
        second = 1,
        
        /// <summary>
        /// >> vote
        /// See [`Pallet::vote`].
        /// </summary>
        vote = 2,
        
        /// <summary>
        /// >> emergency_cancel
        /// See [`Pallet::emergency_cancel`].
        /// </summary>
        emergency_cancel = 3,
        
        /// <summary>
        /// >> external_propose
        /// See [`Pallet::external_propose`].
        /// </summary>
        external_propose = 4,
        
        /// <summary>
        /// >> external_propose_majority
        /// See [`Pallet::external_propose_majority`].
        /// </summary>
        external_propose_majority = 5,
        
        /// <summary>
        /// >> external_propose_default
        /// See [`Pallet::external_propose_default`].
        /// </summary>
        external_propose_default = 6,
        
        /// <summary>
        /// >> fast_track
        /// See [`Pallet::fast_track`].
        /// </summary>
        fast_track = 7,
        
        /// <summary>
        /// >> veto_external
        /// See [`Pallet::veto_external`].
        /// </summary>
        veto_external = 8,
        
        /// <summary>
        /// >> cancel_referendum
        /// See [`Pallet::cancel_referendum`].
        /// </summary>
        cancel_referendum = 9,
        
        /// <summary>
        /// >> delegate
        /// See [`Pallet::delegate`].
        /// </summary>
        @delegate = 10,
        
        /// <summary>
        /// >> undelegate
        /// See [`Pallet::undelegate`].
        /// </summary>
        undelegate = 11,
        
        /// <summary>
        /// >> clear_public_proposals
        /// See [`Pallet::clear_public_proposals`].
        /// </summary>
        clear_public_proposals = 12,
        
        /// <summary>
        /// >> unlock
        /// See [`Pallet::unlock`].
        /// </summary>
        unlock = 13,
        
        /// <summary>
        /// >> remove_vote
        /// See [`Pallet::remove_vote`].
        /// </summary>
        remove_vote = 14,
        
        /// <summary>
        /// >> remove_other_vote
        /// See [`Pallet::remove_other_vote`].
        /// </summary>
        remove_other_vote = 15,
        
        /// <summary>
        /// >> blacklist
        /// See [`Pallet::blacklist`].
        /// </summary>
        blacklist = 16,
        
        /// <summary>
        /// >> cancel_proposal
        /// See [`Pallet::cancel_proposal`].
        /// </summary>
        cancel_proposal = 17,
        
        /// <summary>
        /// >> set_metadata
        /// See [`Pallet::set_metadata`].
        /// </summary>
        set_metadata = 18,
    }
    
    /// <summary>
    /// >> 198 - Variant[pallet_democracy.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.frame_support.traits.preimages.EnumBounded, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.pallet_democracy.vote.EnumAccountVote>, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.frame_support.traits.preimages.EnumBounded, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.frame_support.traits.preimages.EnumBounded, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.frame_support.traits.preimages.EnumBounded, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.pallet_democracy.conviction.EnumConviction, Substrate.NetApi.Model.Types.Primitive.U128>, BaseVoid, BaseVoid, Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.U32, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, BaseTuple<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.pallet_democracy.types.EnumMetadataOwner, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256>>>
    {
    }
}
