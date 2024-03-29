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
        [JsonProperty] [Option("Big Storage Locker Capacity (kg)", "Determines the capacity of the Big Storage Locker in kg.", "Capacity", Format = "F1")] [Limit(1000, 1000000)]
        public int BigStorageLockerCapacity { get; set; } = 100000;
        [JsonProperty] [Option("Big Beautiful Storage Locker Capacity (kg)", "Determines the capacity of the Big Beautiful Storage Locker in kg.", "Capacity", Format = "F1")] [Limit(1000, 1000000)]
        public int BigBeautifulStorageLockerCapacity { get; set; } = 100000;
        [JsonProperty] [Option("Big Gas Container Capacity (kg)", "Determines the capacity of the Big Gas Container in kg.", "Capacity", Format = "F1")] [Limit(100, 10000)]
        public int BigGasLockerCapacity { get; set; } = 750;
        [JsonProperty] [Option("Big Liquid Storage Capacity (kg)", "Determines the capacity of the Big Liquid Storage in kg.", "Capacity", Format = "F1")] [Limit(1000, 100000)]
        public int BigLiquidStorageCapacity { get; set; } = 25000; 
        
        // Color
        [JsonProperty] [Option("Red", "Set the RED tint for the Big Storages.", "Color Storage Locker")] [Limit(0, 255)]
        public int Red { get; set; } = 0;
        [JsonProperty] [Option("Green", "Set the GREEN tint for the Big Storages.", "Color Storage Locker")] [Limit(0, 255)]
		public int Green { get; set; } = 150;
        [JsonProperty] [Option("Blue", "Set the BLUE tint for the Big Storages.", "Color Storage Locker")] [Limit(0, 255)]
		public int Blue { get; set; } = 255;

        //Color Beautiful
        [JsonProperty] [Option("Red (Beautiful)", "Set the RED tint for the Big Beautiful Storages.", "Color Beautiful Storage Locker")] [Limit(0, 255)]
		public int BeautifulRed { get; set; } = 200;
        [JsonProperty] [Option("Green (Beautiful)", "Set the GREEN tint for the Big Beautiful Storages.", "Color Beautiful Storage Locker")] [Limit(0, 255)]
		public int BeautifulGreen { get; set; } = 0;
        [JsonProperty] [Option("Blue (Beautiful)", "Set the BLUE tint for the Big Beautiful Storages.", "Color Beautiful Storage Locker")] [Limit(0, 255)]
		public int BeautifulBlue { get; set; } = 255;
	}
}