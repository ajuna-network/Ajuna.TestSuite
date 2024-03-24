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
    /// >> 388 - Composite[pallet_ajuna_awesome_avatars.types.config.MintOption]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class MintOption : BaseType
    {
        
        /// <summary>
        /// >> payment
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.EnumMintPayment Payment { get; set; }
        /// <summary>
        /// >> pack_type
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.EnumPackType PackType { get; set; }
        /// <summary>
        /// >> pack_size
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.EnumMintPackSize PackSize { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "MintOption";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Payment.Encode());
            result.AddRange(PackType.Encode());
            result.AddRange(PackSize.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Payment = new Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.EnumMintPayment();
            Payment.Decode(byteArray, ref p);
            PackType = new Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.EnumPackType();
            PackType.Decode(byteArray, ref p);
            PackSize = new Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config.EnumMintPackSize();
            PackSize.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
