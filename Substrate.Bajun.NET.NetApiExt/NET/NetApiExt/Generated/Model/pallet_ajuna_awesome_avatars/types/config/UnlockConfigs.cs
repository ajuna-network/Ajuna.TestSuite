//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Attributes;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using System.Collections.Generic;


namespace Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config
{
    
    
    /// <summary>
    /// >> 562 - Composite[pallet_ajuna_awesome_avatars.types.config.UnlockConfigs]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class UnlockConfigs : BaseType
    {
        
        /// <summary>
        /// >> set_price_unlock
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Bajun.NET.NetApiExt.Generated.Model.bounded_collections.bounded_vec.BoundedVecT6> SetPriceUnlock { get; set; }
        /// <summary>
        /// >> avatar_transfer_unlock
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Bajun.NET.NetApiExt.Generated.Model.bounded_collections.bounded_vec.BoundedVecT6> AvatarTransferUnlock { get; set; }
        /// <summary>
        /// >> affiliate_unlock
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Bajun.NET.NetApiExt.Generated.Model.bounded_collections.bounded_vec.BoundedVecT6> AffiliateUnlock { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "UnlockConfigs";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(SetPriceUnlock.Encode());
            result.AddRange(AvatarTransferUnlock.Encode());
            result.AddRange(AffiliateUnlock.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            SetPriceUnlock = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Bajun.NET.NetApiExt.Generated.Model.bounded_collections.bounded_vec.BoundedVecT6>();
            SetPriceUnlock.Decode(byteArray, ref p);
            AvatarTransferUnlock = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Bajun.NET.NetApiExt.Generated.Model.bounded_collections.bounded_vec.BoundedVecT6>();
            AvatarTransferUnlock.Decode(byteArray, ref p);
            AffiliateUnlock = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Bajun.NET.NetApiExt.Generated.Model.bounded_collections.bounded_vec.BoundedVecT6>();
            AffiliateUnlock.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
