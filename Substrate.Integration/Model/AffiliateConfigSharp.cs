using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config;
using System.Numerics;

namespace Substrate.Integration.Model
{
    /// <summary>
    /// Affiliate Config C# Wrapper
    /// </summary>
    public class AffiliateConfigSharp
    {
        /// <summary>
        /// Affiliate Config Constructor
        /// </summary>
        /// <param name="affiliateConfig"></param>
        public AffiliateConfigSharp(AffiliateConfig affiliateConfig)
        {
            Mode = affiliateConfig.Mode.Value;
            EnabledInMint = affiliateConfig.EnabledInMint.Value;
            EnabledInBuy = affiliateConfig.EnabledInBuy.Value;
            EnabledInUpgrade = affiliateConfig.EnabledInUpgrade.Value;
            AffiliatorEnableFee = affiliateConfig.AffiliatorEnableFee.Value;
        }

        /// <summary>
        /// Affiliate Mode
        /// </summary>
        public AffiliateMode Mode { get; }

        /// <summary>
        /// Enabled In Mint
        /// </summary>
        public bool EnabledInMint { get; }

        /// <summary>
        /// Enabled In Buy
        /// </summary>
        public bool EnabledInBuy { get; }

        /// <summary>
        /// Enabled In Upgrade
        /// </summary>
        public bool EnabledInUpgrade { get; }

        /// <summary>
        /// Affiliator Enable Fee
        /// </summary>
        public BigInteger AffiliatorEnableFee { get; }
    }
}