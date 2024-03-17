using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config;

namespace Substrate.Integration.Model
{
    /// <summary>
    /// Avatar Transfer Config C# Wrapper
    /// </summary>
    public class AvatarTransferConfigSharp
    {
        /// <summary>
        /// Avatar Transfer Config Constructor
        /// </summary>
        /// <param name="avatarTransfer"></param>
        public AvatarTransferConfigSharp(AvatarTransferConfig avatarTransfer)
        {
            Open = avatarTransfer.Open.Value;
        }

        /// <summary>
        /// Open
        /// </summary>
        public bool Open { get; }
    }
}