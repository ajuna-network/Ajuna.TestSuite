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


namespace Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.frame_system
{
    
    
    /// <summary>
    /// >> 116 - Composite[frame_system.CodeUpgradeAuthorization]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CodeUpgradeAuthorization : BaseType
    {
        
        /// <summary>
        /// >> code_hash
        /// </summary>
        public Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256 CodeHash { get; set; }
        /// <summary>
        /// >> check_version
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.Bool CheckVersion { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "CodeUpgradeAuthorization";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(CodeHash.Encode());
            result.AddRange(CheckVersion.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            CodeHash = new Substrate.AjunaSolo.NET.NetApiExt.Generated.Model.primitive_types.H256();
            CodeHash.Decode(byteArray, ref p);
            CheckVersion = new Substrate.NetApi.Model.Types.Primitive.Bool();
            CheckVersion.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
