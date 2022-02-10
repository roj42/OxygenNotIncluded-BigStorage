using Database;
using HarmonyLib;
using CaiLib.Config;
using CaiLib;
using System;
using System.Collections.Generic;
using PeterHan.PLib.Options;

namespace BigStorage
{
    public class ModInfo : IModInfo
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002074 File Offset: 0x00000274
		public string Name { get; } = "Big Storage";
	}

    public class BigStorageConfigMod : KMod.UserMod2
    {

   		public static ConfigManager<Config> _configManager;
		public override void OnLoad(Harmony harmony)
		{
			CaiLib.Logger.Logger.LogInit();
            POptions pOptions = new POptions();
            pOptions.RegisterOptions(this, typeof(Config));
            BigStorageConfigMod._configManager = new ConfigManager<Config>(null, "config.json");
			BigStorageConfigMod._configManager.ReadConfig(null);
            harmony.PatchAll();
        }


        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public class BigStoragePatch
        {
            public static void Prefix()
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

            [HarmonyPatch(typeof(Db), "Initialize")]
            public class BigStorageDbPatch
            {
                public static void Postfix() // Prefix ==TO==> Postfix
                {
                    Db.Get().Techs.Get("LiquidTemperature").unlockedItemIDs.Add(BigLiquidStorage.ID);
                    Db.Get().Techs.Get("Catalytics").unlockedItemIDs.Add(BigGasStorage.ID);
                    Db.Get().Techs.Get("RefinedObjects").unlockedItemIDs.Add(BigSolidStorage.ID);
                    Db.Get().Techs.Get("Smelting").unlockedItemIDs.Add(BigBeautifulStorageLocker.ID);
                }
            }
        }

    }
}