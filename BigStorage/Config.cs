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
		[JsonProperty]
		public byte Red { get; set; } = 0;
		[JsonProperty]
		public byte Green { get; set; } = 150;
		[JsonProperty]
		public byte Blue { get; set; } = 255;
        [JsonProperty]
		public byte BeautifulRed { get; set; } = 200;
		[JsonProperty]
		public byte BeautifulGreen { get; set; } = 0;
		[JsonProperty]
		public byte BeautifulBlue { get; set; } = 255;
	}
}