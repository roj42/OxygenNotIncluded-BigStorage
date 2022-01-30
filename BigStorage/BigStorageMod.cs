using Database;
using HarmonyLib;
using CaiLib.Config;
using CaiLib;
using System;
using UnityEngine;
using System.Collections.Generic;

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
			_configManager = new ConfigManager<Config>(null, "config.json");
			_configManager.ReadConfig(null);
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

            private static Color32 defaultColor = new Color32(_configManager.Config.Red, _configManager.Config.Green, _configManager.Config.Blue, 255);
            private static Color32 beautifulColor = new Color32(_configManager.Config.BeautifulRed, _configManager.Config.BeautifulGreen, _configManager.Config.BeautifulBlue, 255);



            [HarmonyPatch(typeof(FilteredStorage), "OnFilterChanged")]
            public static class FilteredStorage_OnFilterChanged
            {
                public static void Postfix(KMonoBehaviour ___root, Tag[] tags)
                {
                    if (!IsActive(tags)) {
                        return;
                    }
                    try{
                       
                        KAnimControllerBase kanim = ___root.GetComponent<KAnimControllerBase>();
                            if (kanim != null) {
                                if (___root.name.ToString().StartsWith("BigSolidStorage")){
                                    kanim.TintColour = defaultColor;
                                CaiLib.Logger.Logger.Log(string.Concat("Updating Filterable Object Color:", ___root.name.ToString()));
                                }
                                if ( ___root.name.ToString().StartsWith("BigBeautifulStorage")){
                                    kanim.TintColour = beautifulColor;
                                CaiLib.Logger.Logger.Log(string.Concat("Updating Filterable Object Color:", ___root.name.ToString()));
                                }
                            }
                    }
                    catch (Exception ex){
                        CaiLib.Logger.Logger.Log(ex.ToString());
                    }
                }
                private static bool IsActive(Tag[] tags) => tags != null && (uint) tags.Length > 0U;
            }

            [HarmonyPatch(typeof(Game), "OnSpawn")]
            public static class GameStart
            {
                public static void Postfix() => TryInitMod();

                    private static void ApplyColorToBuilding(BuildingComplete building)
                    {
                        if (building.name.ToString().StartsWith("BigLiquidStorage") || building.name.ToString().StartsWith("BigGasReservoir"))
                        {
                            KAnimControllerBase kanim = building.GetComponent<KAnimControllerBase>();
                            if (kanim != null)
                            {
                                kanim.TintColour = defaultColor;
                                CaiLib.Logger.Logger.Log(string.Concat("Updating Object Color:", building.name.ToString()));
                            }
                        }

                        if (building.name.ToString().StartsWith("BigSolidStorage") || building.name.ToString().StartsWith("BigBeautifulStorage"))
                        {
                            TreeFilterable treeFilterable = building.GetComponent<TreeFilterable>();
                            if (treeFilterable != null)
                            {
                                Traverse traverse = Traverse.Create(treeFilterable);
                            if (building.name.ToString().StartsWith("BigSolidStorage"))
                            {
                                traverse.Field("filterTint").SetValue(defaultColor);
                            }
                            if (building.name.ToString().StartsWith("BigBeautifulStorage"))
                            {
                                traverse.Field("filterTint").SetValue(beautifulColor);
                            }
                                Tag[] array = traverse.Field<List<Tag>>("acceptedTags").Value.ToArray();
                                treeFilterable.OnFilterChanged(array);
                            }
                        }
                    }

                private static void TryInitMod()
                {
                    try
                    {
                        Components.BuildingCompletes.OnAdd += new Action<BuildingComplete>(ApplyColorToBuilding);
                    }
                    catch (Exception ex)
                    {
                        CaiLib.Logger.Logger.Log(ex.ToString());
                    }
                }
            }
        }
    }
}