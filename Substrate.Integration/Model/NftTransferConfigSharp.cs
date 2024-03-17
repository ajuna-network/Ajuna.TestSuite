using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config;

namespace Substrate.Integration.Model
{
    /// <summary>
    /// Nft Transfer Config C# Wrapper
    /// </summary>
    public class NftTransferConfigSharp
    {
        /// <summary>
        /// Nft Transfer Config Constructor
        /// </summary>
        /// <param name="nftTransfer"></param>
        public NftTransferConfigSharp(NftTransferConfig nftTransfer)
        {
            Open = nftTransfer.Open.Value;
        }

        /// <summary>
        /// Open
        /// </summary>
        public bool Open { get; private set; }
    }
}