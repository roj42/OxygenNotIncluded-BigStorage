using System;
using Newtonsoft.Json;

namespace BigStorage
{
	// Token: 0x02000003 RID: 3
	public class Config
	{
		[JsonProperty]
		public float BigStorageLockerCapacity { get; set; } = 100000f;
		[JsonProperty]
		public float BigGasLockerCapacity { get; set; } = 750f;
		[JsonProperty]
		public float BigLiquidStorageCapacity { get; set; } = 25000f;
		[JsonProperty]
		public float BigBeautifulStorageLockerCapacity { get; set; } = 100000f;
	}
}