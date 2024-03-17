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


namespace Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.account
{
    
    
    /// <summary>
    /// >> 576 - Composite[pallet_ajuna_awesome_avatars.types.account.SeasonInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class SeasonInfo : BaseType
    {
        
        /// <summary>
        /// >> minted
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Minted { get; set; }
        /// <summary>
        /// >> free_minted
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 FreeMinted { get; set; }
        /// <summary>
        /// >> forged
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Forged { get; set; }
        /// <summary>
        /// >> bought
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Bought { get; set; }
        /// <summary>
        /// >> sold
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Sold { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "SeasonInfo";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Minted.Encode());
            result.AddRange(FreeMinted.Encode());
            result.AddRange(Forged.Encode());
            result.AddRange(Bought.Encode());
            result.AddRange(Sold.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Minted = new Substrate.NetApi.Model.Types.Primitive.U32();
            Minted.Decode(byteArray, ref p);
            FreeMinted = new Substrate.NetApi.Model.Types.Primitive.U32();
            FreeMinted.Decode(byteArray, ref p);
            Forged = new Substrate.NetApi.Model.Types.Primitive.U32();
            Forged.Decode(byteArray, ref p);
            Bought = new Substrate.NetApi.Model.Types.Primitive.U32();
            Bought.Decode(byteArray, ref p);
            Sold = new Substrate.NetApi.Model.Types.Primitive.U32();
            Sold.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
