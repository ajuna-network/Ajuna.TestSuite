using Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime;
using Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_core.crypto;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Substrate.Integration.Call
{
    /// <summary>
    /// Pallet Hexalem
    /// </summary>
    public static class PalletAwesomeAvatars
    {
        /// <summary>
        /// Transfer Free Mints call
        /// </summary>
        /// <param name="target"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static EnumRuntimeCall TransferFreeMints(AccountId32 target, ushort amount)
        {
            var baseTubleParams = new BaseTuple<AccountId32, U16>();
            baseTubleParams.Create(target, new U16(amount));

            var enumPalletCall = new Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.pallet.EnumCall();
            enumPalletCall.Create(Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.pallet.Call.transfer_free_mints, baseTubleParams);

            var enumCall = new EnumRuntimeCall();
            enumCall.Create(RuntimeCall.AwesomeAvatars, enumPalletCall);

            return enumCall;
        }

        /// <summary>
        /// Set Free Mints call
        /// </summary>
        /// <param name="target"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static EnumRuntimeCall SetFreeMints(AccountId32 target, ushort amount)
        {
            var baseTubleParams = new BaseTuple<AccountId32, U16>();
            baseTubleParams.Create(target, new U16(amount));

            var enumPalletCall = new Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.pallet.EnumCall();
            enumPalletCall.Create(Bajun.NET.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.pallet.Call.set_free_mints, baseTubleParams);

            var enumCall = new EnumRuntimeCall();
            enumCall.Create(RuntimeCall.AwesomeAvatars, enumPalletCall);

            return enumCall;
        }
    }
}