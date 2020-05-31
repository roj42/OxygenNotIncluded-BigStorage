using Database;
using Harmony;
using CaiLib.Config;
using CaiLib;
using System;
using System.Collections.Generic;

namespace BigStorage
{
    public class ModInfo : IModInfo
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002074 File Offset: 0x00000274
		public string Name { get; } = "Big Storage";
	}

    public class BigStorageConfigMod
    {

   		public static ConfigManager<Config> _configManager;

		public static class Mod_OnLoad
		{
			public static void OnLoad()
			{
				CaiLib.Logger.Logger.LogInit();
				BigStorageConfigMod._configManager = new ConfigManager<Config>(null, "config.json");
				BigStorageConfigMod._configManager.ReadConfig(null);
			}
		}

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public class BigStoragePatch
        {
            private static void Prefix()
            {
                Strings.Add(BigGasStorage.NAME.key.String, BigGasStorage.NAME.text);
                Strings.Add(BigGasStorage.DESC.key.String, BigGasStorage.DESC.text);
                Strings.Add(BigGasStorage.EFFECT.key.String, BigGasStorage.EFFECT.text);
                ModUtil.AddBuildingToPlanScreen("Base", BigGasStorage.ID);
                Strings.Add(BigLiquidStorage.NAME.key.String, BigLiquidStorage.NAME.text);
                Strings.Add(BigLiquidStorage.DESC.key.String, BigLiquidStorage.DESC.text);
                Strings.Add(BigLiquidStorage.EFFECT.key.String, BigLiquidStorage.EFFECT.text);
                ModUtil.AddBuildingToPlanScreen("Base", BigLiquidStorage.ID);
                Strings.Add(BigSolidStorage.NAME.key.String, BigSolidStorage.NAME.text);
                Strings.Add(BigSolidStorage.DESC.key.String, BigSolidStorage.DESC.text);
                Strings.Add(BigSolidStorage.EFFECT.key.String, BigSolidStorage.EFFECT.text);
                ModUtil.AddBuildingToPlanScreen("Base", BigSolidStorage.ID);
                Strings.Add(BigBeautifulStorageLocker.NAME.key.String, BigBeautifulStorageLocker.NAME.text);
                Strings.Add(BigBeautifulStorageLocker.DESC.key.String, BigBeautifulStorageLocker.DESC.text);
                Strings.Add(BigBeautifulStorageLocker.EFFECT.key.String, BigBeautifulStorageLocker.EFFECT.text);
                ModUtil.AddBuildingToPlanScreen("Base", BigBeautifulStorageLocker.ID);
            }

            private static void Postfix()
            {
                object obj = Activator.CreateInstance(typeof(BigGasStorage));
                BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
                object obj2 = Activator.CreateInstance(typeof(BigLiquidStorage));
                BuildingConfigManager.Instance.RegisterBuilding(obj2 as IBuildingConfig);
                object obj3 = Activator.CreateInstance(typeof(BigSolidStorage));
                BuildingConfigManager.Instance.RegisterBuilding(obj3 as IBuildingConfig);
                object obj4 = Activator.CreateInstance(typeof(BigBeautifulStorageLocker));
                BuildingConfigManager.Instance.RegisterBuilding(obj4 as IBuildingConfig);
            }

            [HarmonyPatch(typeof(Db), "Initialize")]
            public class BigStorageDbPatch
            {
                private static void Prefix()
                {
                    List<string> ls = new List<string>(Techs.TECH_GROUPING["LiquidTemperature"]) { BigLiquidStorage.ID };
                    Techs.TECH_GROUPING["LiquidTemperature"] = ls.ToArray();
                    List<string> ls2 = new List<string>(Techs.TECH_GROUPING["Catalytics"]) { BigGasStorage.ID };
                    Techs.TECH_GROUPING["Catalytics"] = ls2.ToArray();
                    List<string> ls3 = new List<string>(Techs.TECH_GROUPING["RefinedObjects"]) { BigSolidStorage.ID };
                    Techs.TECH_GROUPING["RefinedObjects"] = ls3.ToArray();
                    List<string> ls4 = new List<string>(Techs.TECH_GROUPING["Smelting"]) { BigBeautifulStorageLocker.ID };
                    Techs.TECH_GROUPING["Smelting"] = ls4.ToArray();
                }
            }
        }

    }
}