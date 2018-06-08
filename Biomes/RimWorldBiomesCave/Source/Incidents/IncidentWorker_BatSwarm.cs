using System;
using System.Linq;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace RimWorldBiomesCaves
{
    public class IncidentWorker_BatSwarm : IncidentWorker
    {
        //Based on IncidentWorker_Alphabeavers
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = (Map)parms.target;

			if(map.Biome != CavernDefs.RWBCavern)
				return false;

			map.Biome.AllWildAnimals.Where(def => def.defName.ToLower().Contains("bat")).TryRandomElement(out PawnKindDef batKind);
			if(batKind == null)
				return false;
                
            IntVec3 intVec;
            if (!RCellFinder.TryFindRandomPawnEntryCell(out intVec, map, CellFinder.EdgeRoadChance_Animal, null))
            {
                return false;
            }
            int num = Rand.RangeInclusive(12, 24);
            for (int i = 0; i < num; i++)
            {
                IntVec3 loc = CellFinder.RandomClosewalkCellNear(intVec, map, 10, null);
                Pawn newThing = PawnGenerator.GeneratePawn(batKind, null);
                GenSpawn.Spawn(newThing, loc, map);
            }
            Find.LetterStack.ReceiveLetter("RWB.BatSwarmArrived.LetterLabel".Translate()
                    , "RWB.BatSwarmArrived.LetterText".Translate(batKind.labelPlural)
                    , LetterDefOf.ThreatSmall, new TargetInfo(intVec, map, false), null);
            return true;
        }
    }
}
