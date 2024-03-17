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
    /// >> 167 - Composite[pallet_ajuna_awesome_avatars.types.config.GlobalConfig]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class GlobalConfig : BaseType
    {
        
        /// <summary>
        /// >> mint
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.MintConfig Mint { get; set; }
        /// <summary>
        /// >> forge
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.ForgeConfig Forge { get; set; }
        /// <summary>
        /// >> avatar_transfer
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.AvatarTransferConfig AvatarTransfer { get; set; }
        /// <summary>
        /// >> freemint_transfer
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.FreemintTransferConfig FreemintTransfer { get; set; }
        /// <summary>
        /// >> trade
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.TradeConfig Trade { get; set; }
        /// <summary>
        /// >> nft_transfer
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.NftTransferConfig NftTransfer { get; set; }
        /// <summary>
        /// >> affiliate_config
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.AffiliateConfig AffiliateConfig { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "GlobalConfig";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Mint.Encode());
            result.AddRange(Forge.Encode());
            result.AddRange(AvatarTransfer.Encode());
            result.AddRange(FreemintTransfer.Encode());
            result.AddRange(Trade.Encode());
            result.AddRange(NftTransfer.Encode());
            result.AddRange(AffiliateConfig.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Mint = new Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.MintConfig();
            Mint.Decode(byteArray, ref p);
            Forge = new Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.ForgeConfig();
            Forge.Decode(byteArray, ref p);
            AvatarTransfer = new Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.AvatarTransferConfig();
            AvatarTransfer.Decode(byteArray, ref p);
            FreemintTransfer = new Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.FreemintTransferConfig();
            FreemintTransfer.Decode(byteArray, ref p);
            Trade = new Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.TradeConfig();
            Trade.Decode(byteArray, ref p);
            NftTransfer = new Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.NftTransferConfig();
            NftTransfer.Decode(byteArray, ref p);
            AffiliateConfig = new Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.AffiliateConfig();
            AffiliateConfig.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}