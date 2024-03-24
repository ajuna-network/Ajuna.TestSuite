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


namespace Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_trie.storage_proof
{
    
    
    /// <summary>
    /// >> 233 - Composite[sp_trie.storage_proof.StorageProof]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class StorageProof : BaseType
    {
        
        /// <summary>
        /// >> trie_nodes
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Types.Base.BTreeSetT1 TrieNodes { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "StorageProof";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(TrieNodes.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            TrieNodes = new Substrate.Bajun.NET.NetApiExt.Generated.Types.Base.BTreeSetT1();
            TrieNodes.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
