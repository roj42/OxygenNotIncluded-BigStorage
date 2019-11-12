using Harmony;
using System;
using System.Collections.Generic;
using Database;
namespace BigStorage
{
    public class BigStorageConfigMod
    {
        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
	    public class BigStoragePatch
	    {
            public static LocString NAME = new LocString("Big Storage",
                "STRINGS.BUILDINGS.PREFABS." + BigStorage.ID.ToUpper() + ".NAME");
                    public static LocString DESC = new LocString("Using more metal gives you more space!",
                "STRINGS.BUILDINGS.PREFABS." + BigStorage.ID.ToUpper() + ".DESC");
            public static LocString EFFECT = new LocString("Big Storage by RoJCo™",
                "STRINGS.BUILDINGS.PREFABS." + BigStorage.ID.ToUpper() + ".EFFECT");

            private static void Prefix()
            {
                Strings.Add(NAME.key.String, NAME.text);
                Strings.Add(DESC.key.String, DESC.text);
                Strings.Add(EFFECT.key.String, EFFECT.text);
                ModUtil.AddBuildingToPlanScreen("Base", BigStorage.ID);
            }

            private static void Postfix()
            {
                object obj = Activator.CreateInstance(typeof(BigStorage));
                BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
            }

            [HarmonyPatch(typeof(Db), "Initialize")]
            public class BigStorageDbPatch
            {
                private static void Prefix()
                {
                    List<string> ls = new List<string>(Techs.TECH_GROUPING["SmartStorage"]) { BigStorage.ID };
                    Techs.TECH_GROUPING["SmartStorage"] = ls.ToArray();
                }
            }
	    }

    }
}
