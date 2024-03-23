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


namespace Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_nfts.types
{
    
    
    /// <summary>
    /// >> 413 - Composite[pallet_nfts.types.PreSignedMint]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PreSignedMint : BaseType
    {
        
        /// <summary>
        /// >> collection
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Collection { get; set; }
        /// <summary>
        /// >> item
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256 Item { get; set; }
        /// <summary>
        /// >> attributes
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>> Attributes { get; set; }
        /// <summary>
        /// >> metadata
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> Metadata { get; set; }
        /// <summary>
        /// >> only_account
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> OnlyAccount { get; set; }
        /// <summary>
        /// >> deadline
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Deadline { get; set; }
        /// <summary>
        /// >> mint_price
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U128> MintPrice { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "PreSignedMint";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Collection.Encode());
            result.AddRange(Item.Encode());
            result.AddRange(Attributes.Encode());
            result.AddRange(Metadata.Encode());
            result.AddRange(OnlyAccount.Encode());
            result.AddRange(Deadline.Encode());
            result.AddRange(MintPrice.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Collection = new Substrate.NetApi.Model.Types.Primitive.U32();
            Collection.Decode(byteArray, ref p);
            Item = new Substrate.Bajun.NET.NetApiExt.Generated.Model.primitive_types.H256();
            Item.Decode(byteArray, ref p);
            Attributes = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>>();
            Attributes.Decode(byteArray, ref p);
            Metadata = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>();
            Metadata.Decode(byteArray, ref p);
            OnlyAccount = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>();
            OnlyAccount.Decode(byteArray, ref p);
            Deadline = new Substrate.NetApi.Model.Types.Primitive.U32();
            Deadline.Decode(byteArray, ref p);
            MintPrice = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U128>();
            MintPrice.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
