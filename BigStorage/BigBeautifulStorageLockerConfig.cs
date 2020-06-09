using TUNING;
using UnityEngine;

namespace BigStorage
{
    public class BigBeautifulStorageLocker : IBuildingConfig
    {
        // Token: 0x0400670D RID: 26381
        public const string ID = "BigBeautifulStorage";

        public static LocString NAME = new LocString("Big Beautiful Solid Storage",
            "STRINGS.BUILDINGS.PREFABS." + ID.ToUpper() + ".NAME");
        public static LocString DESC = new LocString("Solid storage that goes with any decor! Big Solid Storage by RoJCo™",
            "STRINGS.BUILDINGS.PREFABS." + ID.ToUpper() + ".DESC");
        public static LocString EFFECT = new LocString("Is it storage, or is it art?",
            "STRINGS.BUILDINGS.PREFABS." + ID.ToUpper() + ".EFFECT");

        // Token: 0x0600641E RID: 25630 RVA: 0x001EE5A4 File Offset: 0x001EC9A4
        public override BuildingDef CreateBuildingDef()
        {
            string id = ID;
            int width = 1;
            int height = 2;
            string anim = "storagelocker_kanim";
            int hitpoints = 30;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
            string[] raw_MINERALS = MATERIALS.REFINED_METALS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, raw_MINERALS, melting_point, build_location_rule, BUILDINGS.DECOR.BONUS.TIER1, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.AudioCategory = "Metal";
            buildingDef.Overheatable = false;
            return buildingDef;
        }

        // Token: 0x0600641F RID: 25631 RVA: 0x001EE62C File Offset: 0x001ECA2C
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            SoundEventVolumeCache.instance.AddVolume("storagelocker_kanim", "StorageLocker_Hit_metallic_low", NOISE_POLLUTION.NOISY.TIER1);
            Prioritizable.AddRef(go);
            Storage storage = go.AddOrGet<Storage>();
            storage.showInUI = true;
            storage.allowItemRemoval = true;
            storage.showDescriptor = true;
            storage.capacityKg = BigStorageConfigMod._configManager.Config.BigBeautifulStorageLockerCapacity;
            storage.storageFilters = STORAGEFILTERS.NOT_EDIBLE_SOLIDS;
            storage.storageFullMargin = STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
            storage.fetchCategory = Storage.FetchCategory.GeneralStorage;
            CopyBuildingSettings copyBuildingSettings = go.AddOrGet<CopyBuildingSettings>();
            copyBuildingSettings.copyGroupTag = GameTags.StorageLocker;
            go.AddOrGet<StorageLocker>();
        }

        // Token: 0x06006420 RID: 25632 RVA: 0x001EE6AA File Offset: 0x001ECAAA
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGetDef<StorageController.Def>();
        }

    }
}
