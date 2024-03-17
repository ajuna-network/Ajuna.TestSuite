using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config;

namespace Substrate.Integration.Model
{
    /// <summary>
    /// Wrapper Forge Config
    /// </summary>
    public class ForgeConfigSharp
    {
        /// <summary>
        /// Forge Config Constructor
        /// </summary>
        /// <param name="forge"></param>
        public ForgeConfigSharp(ForgeConfig forge)
        {
            Open = forge.Open.Value;
        }

        /// <summary>
        /// Open
        /// </summary>
        public bool Open { get; private set; }
    }
}