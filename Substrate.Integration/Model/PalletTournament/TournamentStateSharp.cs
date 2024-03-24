﻿using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_tournament.config;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Numerics;

namespace Substrate.Integration.Model
{
    /// <summary>
    /// Wrapped TournamentState
    /// </summary>
    public class TournamentStateSharp
    {
        /// <summary>
        /// TournamentStateSharp constructor
        /// </summary>
        /// <param name="tournamentState"></param>
        public TournamentStateSharp(EnumTournamentState tournamentState)
        {
            TournamentState = tournamentState.Value;
            switch (TournamentState)
            {
                case TournamentState.Inactive:
                    BlockNumber = null;
                    break;

                case TournamentState.ActivePeriod:
                    BlockNumber = (U32)tournamentState.Value2;
                    break;

                case TournamentState.ClaimPeriod:
                    BlockNumber = (U32)((BaseTuple<U32, U128>)tournamentState.Value2).Value[0];
                    Reward = (U128)((BaseTuple<U32, U128>)tournamentState.Value2).Value[1];
                    break;
            }
        }

        /// <summary>
        /// TournamentState
        /// </summary>
        public TournamentState TournamentState { get; }

        /// <summary>
        /// BlockNumber
        /// </summary>
        public uint? BlockNumber { get; }

        /// <summary>
        /// Reward
        /// </summary>
        public BigInteger? Reward { get; }
    }
}