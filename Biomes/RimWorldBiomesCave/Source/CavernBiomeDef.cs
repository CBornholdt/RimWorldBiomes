using System;
using Verse;
using RimWorld;

namespace RimWorldBiomesCaves
{
    [DefOf]
    static public class CavernDefs
    {
		public static BiomeDef RWBCavern;
    }
    
    [DefOf]
    public static class CavernRoofDefOf
    {
        public static RoofDef UncollapsableNaturalRoof;
    }
    
    [DefOf]
    public static class RWBBuildingDefOf
    {
        public static ThingDef Stalagmite1;

    }
    
    [DefOf]
    public static class RWBTerrainDefOf
    {
        public static TerrainDef RWBRockySoil;
        public static TerrainDef RWBSandstoneSoil;
        public static TerrainDef RWBGraniteSoil;
        public static TerrainDef RWBMarbleSoil;
        public static TerrainDef RWBSlateSoil;
        public static TerrainDef RWBLimestoneSoil;

    }
}
