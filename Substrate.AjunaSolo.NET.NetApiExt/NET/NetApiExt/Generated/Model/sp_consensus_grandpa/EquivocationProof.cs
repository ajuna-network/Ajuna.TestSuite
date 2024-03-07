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


namespace Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.sp_consensus_grandpa
{
    
    
    /// <summary>
    /// >> 144 - Composite[sp_consensus_grandpa.EquivocationProof]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class EquivocationProof : BaseType
    {
        
        /// <summary>
        /// >> set_id
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 SetId { get; set; }
        /// <summary>
        /// >> equivocation
        /// </summary>
        public Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.sp_consensus_grandpa.EnumEquivocation Equivocation { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "EquivocationProof";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(SetId.Encode());
            result.AddRange(Equivocation.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            SetId = new Substrate.NetApi.Model.Types.Primitive.U64();
            SetId.Decode(byteArray, ref p);
            Equivocation = new Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.sp_consensus_grandpa.EnumEquivocation();
            Equivocation.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
