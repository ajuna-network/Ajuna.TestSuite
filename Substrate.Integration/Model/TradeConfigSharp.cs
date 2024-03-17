using Substrate.Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types.config;

namespace Substrate.Integration.Model
{
    /// <summary>
    /// Transfer Config C# Wrapper
    /// </summary>
    public class TradeConfigSharp
    {
        /// <summary>
        /// Transfer Config Constructor
        /// </summary>
        /// <param name="trade"></param>
        public TradeConfigSharp(TradeConfig trade)
        {
            Open = trade.Open.Value;
        }

        /// <summary>
        /// Open
        /// </summary>
        public bool Open { get; private set; }
    }
}