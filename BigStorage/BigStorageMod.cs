using Database;
using Harmony;
using System;
using System.Collections.Generic;

namespace BigStorage
{
    public class BigStorageConfigMod
    {
        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public class BigStoragePatch
        {
            public static LocString NAMEGAS = new LocString("Big Gas Storage",
                "STRINGS.BUILDINGS.PREFABS." + BigGasStorage.ID.ToUpper() + ".NAME");
            public static LocString DESCGAS = new LocString("Using more metal gives you more space! Big Gas Storage by RoJCo™",
        "STRINGS.BUILDINGS.PREFABS." + BigGasStorage.ID.ToUpper() + ".DESC");
            public static LocString EFFECTGAS = new LocString("Five times the space at twenty times the pressure!",
                "STRINGS.BUILDINGS.PREFABS." + BigGasStorage.ID.ToUpper() + ".EFFECT");

            public static LocString NAMELIQ = new LocString("Big Liquid Storage",
               "STRINGS.BUILDINGS.PREFABS." + BigLiquidStorage.ID.ToUpper() + ".NAME");
            public static LocString DESCLIQ = new LocString("Compacted into buckyballs, maybe. Who knows? Big Liquid Storage by RoJCo™",
        "STRINGS.BUILDINGS.PREFABS." + BigLiquidStorage.ID.ToUpper() + ".DESC");
            public static LocString EFFECTLIQ = new LocString("Five times the storage through the magic of superdense alloys.",
                "STRINGS.BUILDINGS.PREFABS." + BigLiquidStorage.ID.ToUpper() + ".EFFECT");

            private static void Prefix()
            {
                Strings.Add(NAMEGAS.key.String, NAMEGAS.text);
                Strings.Add(DESCGAS.key.String, DESCGAS.text);
                Strings.Add(EFFECTGAS.key.String, EFFECTGAS.text);
                ModUtil.AddBuildingToPlanScreen("Base", BigGasStorage.ID);
                Strings.Add(NAMELIQ.key.String, NAMELIQ.text);
                Strings.Add(DESCLIQ.key.String, DESCLIQ.text);
                Strings.Add(EFFECTLIQ.key.String, EFFECTLIQ.text);
                ModUtil.AddBuildingToPlanScreen("Base", BigLiquidStorage.ID);
            }

            private static void Postfix()
            {
                object obj = Activator.CreateInstance(typeof(BigGasStorage));
                BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
                object obj2 = Activator.CreateInstance(typeof(BigLiquidStorage));
                BuildingConfigManager.Instance.RegisterBuilding(obj2 as IBuildingConfig);
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
                }
            }
        }

    }
}
