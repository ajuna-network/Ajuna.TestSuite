using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config;

namespace Substrate.Integration.Model
{
    /// <summary>
    /// Freemint Transfer Config C# Wrapper
    /// </summary>
    public class FreemintTransferConfigSharp
    {
        /// <summary>
        /// Freemint Transfer Config Constructor
        /// </summary>
        /// <param name="freemintTransfer"></param>
        public FreemintTransferConfigSharp(FreemintTransferConfig freemintTransfer)
        {
            Mode = freemintTransfer.Mode.Value;
            FreeMintTransferFee = freemintTransfer.FreeMintTransferFee.Value;
            MinFreeMintTransfer = freemintTransfer.MinFreeMintTransfer.Value;
        }

        /// <summary>
        /// Mode
        /// </summary>
        public FreeMintTransferMode Mode { get; }

        /// <summary>
        /// Free Mint Transfer Fee
        /// </summary>
        public ushort FreeMintTransferFee { get; }

        /// <summary>
        /// Min Free Mint Transfer
        /// </summary>
        public ushort MinFreeMintTransfer { get; }
    }
}