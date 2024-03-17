using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.account;

namespace Substrate.Integration.Model
{
    /// <summary>
    /// Wrapped PlayerSeasonConfig
    /// </summary>
    public class PlayerSeasonConfigsSharp
    {
        /// <summary>
        /// Wrapped PlayerSeasonConfig constructor
        /// </summary>
        /// <param name="playerSeasonConfig"></param>
        public PlayerSeasonConfigsSharp(PlayerSeasonConfig playerSeasonConfig)
        {
            StorageTier = playerSeasonConfig.StorageTier.Value;
            StatsSharp = new StatsSharp(playerSeasonConfig.Stats);
        }

        /// <summary>
        /// Storage Tier
        /// </summary>
        public StorageTier StorageTier { get; private set; }

        /// <summary>
        /// Stats
        /// </summary>
        public StatsSharp StatsSharp { get; private set; }
    }
}