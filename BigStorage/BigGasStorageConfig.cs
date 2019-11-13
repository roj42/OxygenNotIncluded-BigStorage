using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace BigStorage
{
    public class BigGasStorage : IBuildingConfig
    {
        // Token: 0x0400670D RID: 26381
        public const string ID = "BigGasReservoir";

        // Token: 0x0400670E RID: 26382
        private const ConduitType CONDUIT_TYPE = ConduitType.Gas;

        // Token: 0x0400670F RID: 26383
        private const int WIDTH = 5;

        // Token: 0x04006710 RID: 26384
        private const int HEIGHT = 3;

        public static LocString NAME = new LocString("Big Gas Storage",
            "STRINGS.BUILDINGS.PREFABS." + ID.ToUpper() + ".NAME");
        public static LocString DESC = new LocString("Using more metal gives you more space! Big Gas Storage by RoJCo™",
            "STRINGS.BUILDINGS.PREFABS." + ID.ToUpper() + ".DESC");
        public static LocString EFFECT = new LocString("Five times the space at twenty times the pressure!",
            "STRINGS.BUILDINGS.PREFABS." + ID.ToUpper() + ".EFFECT");

        // Token: 0x04006711 RID: 26385
        public static readonly List<Storage.StoredItemModifier> ReservoirStoredItemModifiers = new List<Storage.StoredItemModifier>
        {
        Storage.StoredItemModifier.Hide,
        Storage.StoredItemModifier.Seal
        };


        // Token: 0x06005F42 RID: 24386 RVA: 0x001D303C File Offset: 0x001D143C
        public override BuildingDef CreateBuildingDef()
        {
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("BigGasReservoir", WIDTH, HEIGHT, "gasstorage_kanim", 100, 120f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER6, MATERIALS.ALL_METALS, 800f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.PENALTY.TIER1, NOISE_POLLUTION.NOISY.TIER0, 0.2f);
            buildingDef.InputConduitType = ConduitType.Gas;
            buildingDef.OutputConduitType = ConduitType.Gas;
            buildingDef.Floodable = false;
            buildingDef.ViewMode = OverlayModes.GasConduits.ID;
            buildingDef.AudioCategory = "HollowMetal";
            buildingDef.UtilityInputOffset = new CellOffset(1, 2);
            buildingDef.UtilityOutputOffset = new CellOffset(0, 0);
            return buildingDef;
        }

        // Token: 0x06005F43 RID: 24387 RVA: 0x001D30C8 File Offset: 0x001D14C8
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<Reservoir>();
            Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
            storage.showDescriptor = true;
            storage.storageFilters = STORAGEFILTERS.GASES;
            storage.capacityKg = 750f;
            storage.SetDefaultStoredItemModifiers(GasReservoirConfig.ReservoirStoredItemModifiers);
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Gas;
            conduitConsumer.ignoreMinMassCheck = true;
            conduitConsumer.forceAlwaysSatisfied = true;
            conduitConsumer.alwaysConsume = true;
            conduitConsumer.capacityKG = storage.capacityKg;
            ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
            conduitDispenser.conduitType = ConduitType.Gas;
            conduitDispenser.elementFilter = null;
        }

        // Token: 0x06005F44 RID: 24388 RVA: 0x001D3150 File Offset: 0x001D1550
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGetDef<StorageController.Def>();
        }


    }

}
