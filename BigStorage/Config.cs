﻿using System;
using Newtonsoft.Json;
using PeterHan.PLib.Options;

namespace BigStorage
{
	// Token: 0x02000003 RID: 3
    [Serializable]
    [RestartRequired]
    public class Config : SingletonOptions<Config>
    {
        // Capacity
        [JsonProperty] [Option("Big Storage Locker Capacity (kg)", "Determines the capacity of the Big Storage Locker in kg.", Format = "F1")] [Limit(1000f, 1000000f)]
        public float BigStorageLockerCapacity { get; set; } = 100000f;
        [JsonProperty] [Option("Big Beautiful Storage Locker Capacity (kg)", "Determines the capacity of the Big Beautiful Storage Locker in kg.", Format = "F1")] [Limit(1000f, 1000000f)]
        public float BigBeautifulStorageLockerCapacity { get; set; } = 100000f;
        [JsonProperty] [Option("Big Gas Container Capacity (kg)", "Determines the capacity of the Big Gas Container in kg.", Format = "F1")] [Limit(100f, 10000f)]
        public float BigGasLockerCapacity { get; set; } = 750f;
        [JsonProperty] [Option("Big Liquid Storage Capacity (kg)", "Determines the capacity of the Big Liquid Storage in kg.", Format = "F1")] [Limit(1000f, 100000f)]
        public float BigLiquidStorageCapacity { get; set; } = 25000f; 
        
        // Colour
        [JsonProperty] [Option("Red", "Set the RED tint for the Big Storages.", Format = "F1")] [Limit(0f, 255f)]
        public byte Red { get; set; } = 0;
        [JsonProperty] [Option("Green", "Set the GREEN tint for the Big Storages.", Format = "F1")] [Limit(0f, 255f)]
		public byte Green { get; set; } = 150;
        [JsonProperty] [Option("Blue", "Set the BLUE tint for the Big Storages.", Format = "F1")] [Limit(0f, 255f)]
		public byte Blue { get; set; } = 255;

        //Colour Beautiful
        [JsonProperty] [Option("Red", "Set the RED tint for the Big Beautiful Storages.", Format = "F1")] [Limit(0f, 255f)]
		public byte BeautifulRed { get; set; } = 200;
        [JsonProperty] [Option("Red", "Set the GREEN tint for the Big Beautiful Storages.", Format = "F1")] [Limit(0f, 255f)]
		public byte BeautifulGreen { get; set; } = 0;
        [JsonProperty] [Option("Red", "Set the BLUE tint for the Big Beautiful Storages.", Format = "F1")] [Limit(0f, 255f)]
		public byte BeautifulBlue { get; set; } = 255;
	}
}