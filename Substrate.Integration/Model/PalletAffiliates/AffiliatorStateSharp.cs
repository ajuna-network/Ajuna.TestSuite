using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_affiliates.traits;

namespace Substrate.Integration.Model
{
    /// <summary>
    /// Wrapped AffiliatorState
    /// </summary>
    public class AffiliatorStateSharp
    {
        /// <summary>
        /// AffiliatorStateSharp constructor
        /// </summary>
        /// <param name="affiliatorState"></param>
        public AffiliatorStateSharp(AffiliatorState affiliatorState)
        {
            Status = affiliatorState.Status.Value;
            Affiliates = affiliatorState.Affiliates;
        }

        /// <summary>
        /// Status
        /// </summary>
        public AffiliatableStatus Status { get; }

        /// <summary>
        /// Affiliates
        /// </summary>
        public uint Affiliates { get; }
    }
}