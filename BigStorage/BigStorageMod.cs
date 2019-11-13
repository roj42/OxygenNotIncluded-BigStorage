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
