﻿using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.account;

namespace Substrate.Integration.Model
{
    /// <summary>
    /// Wrapped Season Info
    /// </summary>
    public class SeasonInfoSharp
    {
        /// <summary>
        /// Wrapped Season Info constructor
        /// </summary>
        /// <param name="seasonInfo"></param>
        public SeasonInfoSharp(SeasonInfo seasonInfo)
        {
            Minted = seasonInfo.Minted.Value;
            Freeminted = seasonInfo.FreeMinted.Value;
            Forged = seasonInfo.Forged.Value;
            Bought = seasonInfo.Bought.Value;
            Sold = seasonInfo.Sold.Value;
        }

        /// <summary>
        /// Minted
        /// </summary>
        public uint Minted { get; }

        /// <summary>
        /// Forged
        /// </summary>
        public uint Forged { get; }

        /// <summary>
        /// Freeminted
        /// </summary>
        public uint Freeminted { get; }

        /// <summary>
        /// Bought
        /// </summary>
        public uint Bought { get; }

        /// <summary>
        /// Sold
        /// </summary>
        public uint Sold { get; }
    }
}