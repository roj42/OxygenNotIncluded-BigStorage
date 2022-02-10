using System;
using Newtonsoft.Json;
using PeterHan.PLib.Options;

namespace BigStorage
{
	// Token: 0x02000003 RID: 3
    [Serializable]
    [RestartRequired]
    public class Config : SingletonOptions<Config>
    {
		[JsonProperty]
        [Option("Big Storage Locker Capacity (kg)", "Determines the capacity of the Big Storage Locker in kg.", Format = "F1")]
        [Limit(1f, 1000000f)]
        public float BigStorageLockerCapacity { get; set; } = 100000f;

        [JsonProperty]
        [Option("Big Beautiful Storage Locker Capacity (kg)", "Determines the capacity of the Big Beautiful Storage Locker in kg.", Format = "F1")]
        [Limit(1f, 1000000f)]
        public float BigBeautifulStorageLockerCapacity { get; set; } = 100000f;

        [JsonProperty]
        [Option("Big Gas Container Capacity (kg)", "Determines the capacity of the Big Gas Container in kg.", Format = "F1")]
        [Limit(1f, 1000000f)]
        public float BigGasLockerCapacity { get; set; } = 750f;
        
        [JsonProperty]
        [Option("Big Liquid Storage Capacity (kg)", "Determines the capacity of the Big Liquid Storage in kg.", Format = "F1")]
        [Limit(1f, 1000000f)]
        public float BigLiquidStorageCapacity { get; set; } = 25000f;
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