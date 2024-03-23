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


namespace Substrate.Bajun.NET.NetApiExt.Generated.Model.cumulus_primitives_parachain_inherent
{
    
    
    /// <summary>
    /// >> 249 - Composite[cumulus_primitives_parachain_inherent.ParachainInherentData]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ParachainInherentData : BaseType
    {
        
        /// <summary>
        /// >> validation_data
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.polkadot_primitives.v6.PersistedValidationData ValidationData { get; set; }
        /// <summary>
        /// >> relay_chain_state
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_trie.storage_proof.StorageProof RelayChainState { get; set; }
        /// <summary>
        /// >> downward_messages
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.Bajun.NET.NetApiExt.Generated.Model.polkadot_core_primitives.InboundDownwardMessage> DownwardMessages { get; set; }
        /// <summary>
        /// >> horizontal_messages
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Types.Base.BTreeMapT3 HorizontalMessages { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "ParachainInherentData";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ValidationData.Encode());
            result.AddRange(RelayChainState.Encode());
            result.AddRange(DownwardMessages.Encode());
            result.AddRange(HorizontalMessages.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ValidationData = new Substrate.Bajun.NET.NetApiExt.Generated.Model.polkadot_primitives.v6.PersistedValidationData();
            ValidationData.Decode(byteArray, ref p);
            RelayChainState = new Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_trie.storage_proof.StorageProof();
            RelayChainState.Decode(byteArray, ref p);
            DownwardMessages = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.Bajun.NET.NetApiExt.Generated.Model.polkadot_core_primitives.InboundDownwardMessage>();
            DownwardMessages.Decode(byteArray, ref p);
            HorizontalMessages = new Substrate.Bajun.NET.NetApiExt.Generated.Types.Base.BTreeMapT3();
            HorizontalMessages.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
