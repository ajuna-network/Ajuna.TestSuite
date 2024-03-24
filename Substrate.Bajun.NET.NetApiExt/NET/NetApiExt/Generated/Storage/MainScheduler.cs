//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Substrate.Bajun.NET.NetApiExt.Generated.Storage
{
    
    
    /// <summary>
    /// >> SchedulerStorage
    /// </summary>
    public sealed class SchedulerStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> SchedulerStorage Constructor
        /// </summary>
        public SchedulerStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Scheduler", "IncompleteSince"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Scheduler", "Agenda"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substrate.NetApi.Model.Types.Primitive.U32), typeof(Substrate.Bajun.NET.NetApiExt.Generated.Model.bounded_collections.bounded_vec.BoundedVecT28)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Scheduler", "Lookup"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substrate.Bajun.NET.NetApiExt.Generated.Types.Base.Arr32U8), typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>)));
        }
        
        /// <summary>
        /// >> IncompleteSinceParams
        /// </summary>
        public static string IncompleteSinceParams()
        {
            return RequestGenerator.GetStorage("Scheduler", "IncompleteSince", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> IncompleteSinceDefault
        /// Default value as hex string
        /// </summary>
        public static string IncompleteSinceDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> IncompleteSince
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> IncompleteSince(string blockhash, CancellationToken token)
        {
            string parameters = SchedulerStorage.IncompleteSinceParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> AgendaParams
        ///  Items to be executed, indexed by the block number that they should be executed on.
        /// </summary>
        public static string AgendaParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("Scheduler", "Agenda", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> AgendaDefault
        /// Default value as hex string
        /// </summary>
        public static string AgendaDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Agenda
        ///  Items to be executed, indexed by the block number that they should be executed on.
        /// </summary>
        public async Task<Substrate.Bajun.NET.NetApiExt.Generated.Model.bounded_collections.bounded_vec.BoundedVecT28> Agenda(Substrate.NetApi.Model.Types.Primitive.U32 key, string blockhash, CancellationToken token)
        {
            string parameters = SchedulerStorage.AgendaParams(key);
            var result = await _client.GetStorageAsync<Substrate.Bajun.NET.NetApiExt.Generated.Model.bounded_collections.bounded_vec.BoundedVecT28>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> LookupParams
        ///  Lookup from a name to the block number and index of the task.
        /// 
        ///  For v3 -> v4 the previously unbounded identities are Blake2-256 hashed to form the v4
        ///  identities.
        /// </summary>
        public static string LookupParams(Substrate.Bajun.NET.NetApiExt.Generated.Types.Base.Arr32U8 key)
        {
            return RequestGenerator.GetStorage("Scheduler", "Lookup", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> LookupDefault
        /// Default value as hex string
        /// </summary>
        public static string LookupDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Lookup
        ///  Lookup from a name to the block number and index of the task.
        /// 
        ///  For v3 -> v4 the previously unbounded identities are Blake2-256 hashed to form the v4
        ///  identities.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> Lookup(Substrate.Bajun.NET.NetApiExt.Generated.Types.Base.Arr32U8 key, string blockhash, CancellationToken token)
        {
            string parameters = SchedulerStorage.LookupParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> SchedulerCalls
    /// </summary>
    public sealed class SchedulerCalls
    {
        
        /// <summary>
        /// >> schedule
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Schedule(Substrate.NetApi.Model.Types.Primitive.U32 when, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> maybe_periodic, Substrate.NetApi.Model.Types.Primitive.U8 priority, Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime.EnumRuntimeCall call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(when.Encode());
            byteArray.AddRange(maybe_periodic.Encode());
            byteArray.AddRange(priority.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(8, "Scheduler", 0, "schedule", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> cancel
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Cancel(Substrate.NetApi.Model.Types.Primitive.U32 when, Substrate.NetApi.Model.Types.Primitive.U32 index)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(when.Encode());
            byteArray.AddRange(index.Encode());
            return new Method(8, "Scheduler", 1, "cancel", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> schedule_named
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ScheduleNamed(Substrate.Bajun.NET.NetApiExt.Generated.Types.Base.Arr32U8 id, Substrate.NetApi.Model.Types.Primitive.U32 when, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> maybe_periodic, Substrate.NetApi.Model.Types.Primitive.U8 priority, Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime.EnumRuntimeCall call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(id.Encode());
            byteArray.AddRange(when.Encode());
            byteArray.AddRange(maybe_periodic.Encode());
            byteArray.AddRange(priority.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(8, "Scheduler", 2, "schedule_named", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> cancel_named
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method CancelNamed(Substrate.Bajun.NET.NetApiExt.Generated.Types.Base.Arr32U8 id)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(id.Encode());
            return new Method(8, "Scheduler", 3, "cancel_named", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> schedule_after
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ScheduleAfter(Substrate.NetApi.Model.Types.Primitive.U32 after, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> maybe_periodic, Substrate.NetApi.Model.Types.Primitive.U8 priority, Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime.EnumRuntimeCall call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(after.Encode());
            byteArray.AddRange(maybe_periodic.Encode());
            byteArray.AddRange(priority.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(8, "Scheduler", 4, "schedule_after", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> schedule_named_after
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ScheduleNamedAfter(Substrate.Bajun.NET.NetApiExt.Generated.Types.Base.Arr32U8 id, Substrate.NetApi.Model.Types.Primitive.U32 after, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> maybe_periodic, Substrate.NetApi.Model.Types.Primitive.U8 priority, Substrate.Bajun.NET.NetApiExt.Generated.Model.bajun_runtime.EnumRuntimeCall call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(id.Encode());
            byteArray.AddRange(after.Encode());
            byteArray.AddRange(maybe_periodic.Encode());
            byteArray.AddRange(priority.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(8, "Scheduler", 5, "schedule_named_after", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> SchedulerConstants
    /// </summary>
    public sealed class SchedulerConstants
    {
        
        /// <summary>
        /// >> MaximumWeight
        ///  The maximum weight that may be scheduled per block for any dispatchables.
        /// </summary>
        public Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight MaximumWeight()
        {
            var result = new Substrate.Bajun.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight();
            result.Create("0x0700A0DB215D02000001");
            return result;
        }
        
        /// <summary>
        /// >> MaxScheduledPerBlock
        ///  The maximum number of scheduled calls in the queue for a single block.
        /// 
        ///  NOTE:
        ///  + Dependent pallets' benchmarks might require a higher limit for the setting. Set a
        ///  higher limit under `runtime-benchmarks` feature.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxScheduledPerBlock()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x32000000");
            return result;
        }
    }
    
    /// <summary>
    /// >> SchedulerErrors
    /// </summary>
    public enum SchedulerErrors
    {
        
        /// <summary>
        /// >> FailedToSchedule
        /// Failed to schedule a call
        /// </summary>
        FailedToSchedule,
        
        /// <summary>
        /// >> NotFound
        /// Cannot find the scheduled call.
        /// </summary>
        NotFound,
        
        /// <summary>
        /// >> TargetBlockNumberInPast
        /// Given target block number is in the past.
        /// </summary>
        TargetBlockNumberInPast,
        
        /// <summary>
        /// >> RescheduleNoChange
        /// Reschedule failed because it does not change scheduled time.
        /// </summary>
        RescheduleNoChange,
        
        /// <summary>
        /// >> Named
        /// Attempt to use a non-named function on a named task.
        /// </summary>
        Named,
    }
}
