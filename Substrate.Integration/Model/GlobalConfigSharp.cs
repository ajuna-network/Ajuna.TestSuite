using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config;

namespace Substrate.Integration.Model
{
    /// <summary>
    /// Global Config C# Wrapper
    /// </summary>
    public class GlobalConfigSharp
    {
        /// <summary>
        /// Global Config Constructor
        /// </summary>
        /// <param name="globalConfig"></param>
        public GlobalConfigSharp(GlobalConfig globalConfig)
        {
            Mint = new MintConfigSharp(globalConfig.Mint);
            Forge = new ForgeConfigSharp(globalConfig.Forge);
            AvatarTransfer = new AvatarTransferConfigSharp(globalConfig.AvatarTransfer);
            FreemintTransfer = new FreemintTransferConfigSharp(globalConfig.FreemintTransfer);
            Trade = new TradeConfigSharp(globalConfig.Trade);
            NftTransfer = new NftTransferConfigSharp(globalConfig.NftTransfer);
            AffiliateConfig = new AffiliateConfigSharp(globalConfig.AffiliateConfig);
        }

        /// <summary>
        /// Mint
        /// </summary>
        public MintConfigSharp Mint { get; }

        /// <summary>
        /// Forge
        /// </summary>
        public ForgeConfigSharp Forge { get; }

        /// <summary>
        /// Avatar Transfer
        /// </summary>
        public AvatarTransferConfigSharp AvatarTransfer { get; }

        /// <summary>
        /// Freemint Transfer
        /// </summary>
        public FreemintTransferConfigSharp FreemintTransfer { get; }

        /// <summary>
        /// Trade
        /// </summary>
        public TradeConfigSharp Trade { get; }

        /// <summary>
        /// NftTransfer
        /// </summary>
        public NftTransferConfigSharp NftTransfer { get; }

        /// <summary>
        /// Affiliate Config
        /// </summary>
        public AffiliateConfigSharp AffiliateConfig { get; }
    }
}