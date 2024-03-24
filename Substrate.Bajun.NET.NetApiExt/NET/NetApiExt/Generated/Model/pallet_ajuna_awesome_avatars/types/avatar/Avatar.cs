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


namespace Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.avatar
{
    
    
    /// <summary>
    /// >> 572 - Composite[pallet_ajuna_awesome_avatars.types.avatar.Avatar]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Avatar : BaseType
    {
        
        /// <summary>
        /// >> season_id
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U16 SeasonId { get; set; }
        /// <summary>
        /// >> encoding
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.avatar.EnumDnaEncoding Encoding { get; set; }
        /// <summary>
        /// >> dna
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.bounded_collections.bounded_vec.BoundedVecT7 Dna { get; set; }
        /// <summary>
        /// >> souls
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Souls { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Avatar";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(SeasonId.Encode());
            result.AddRange(Encoding.Encode());
            result.AddRange(Dna.Encode());
            result.AddRange(Souls.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            SeasonId = new Substrate.NetApi.Model.Types.Primitive.U16();
            SeasonId.Decode(byteArray, ref p);
            Encoding = new Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.avatar.EnumDnaEncoding();
            Encoding.Decode(byteArray, ref p);
            Dna = new Substrate.Bajun.NET.NetApiExt.Generated.Model.bounded_collections.bounded_vec.BoundedVecT7();
            Dna.Decode(byteArray, ref p);
            Souls = new Substrate.NetApi.Model.Types.Primitive.U32();
            Souls.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
