using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config;
using Substrate.NetApi.Modules;

namespace Substrate.Integration.Model
{
    /// <summary>
    /// Mint Config C# Wrapper
    /// </summary>
    public class MintConfigSharp
    {
        /// <summary>
        /// Mint Config Constructor
        /// </summary>
        /// <param name="mint"></param>
        public MintConfigSharp(MintConfig mint)
        {
            Open = mint.Open.Value;
            Cooldown = mint.Cooldown.Value;
            FreeMintFeeMultiplier = mint.FreeMintFeeMultiplier.Value;
        }

        /// <summary>
        /// Open
        /// </summary>
        public bool Open { get; private set; }

        /// <summary>
        /// Cooldown
        /// </summary>
        public uint Cooldown { get; private set; }

        /// <summary>
        /// Free Mint Fee Multiplier
        /// </summary>
        public ushort FreeMintFeeMultiplier { get; private set; }
    }
}