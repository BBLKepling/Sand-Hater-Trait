using RimWorld;
using RimWorld.Planet;
using Sandstorms;
using Verse;

namespace SandHaterTrait
{
    public class ThoughtWorker_SandHater : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn pawn)
        {
            if (pawn.ParentHolder is Caravan caravan) 
            {
                return (caravan.Biome == BiomeDefOf.Desert || caravan.Biome == SandHaterTraitDefOf.ExtremeDesert) ? ThoughtState.ActiveAtStage(1) : ThoughtState.Inactive;
            }
            if (!(pawn?.Map is Map map)) return ThoughtState.Inactive;
            if (map.weatherManager.curWeather == NCSS_WeatherDefOf.NCSS_Sandstorm) return ThoughtState.ActiveAtStage(2);
            if (map.Biome == BiomeDefOf.Desert || 
                map.Biome == SandHaterTraitDefOf.ExtremeDesert
                ) return ThoughtState.ActiveAtStage(1);
            for (int i = 0; i < 48; i++)
            {
                IntVec3 intVec = pawn.Position + GenRadial.RadialPattern[i];
                if (!intVec.IsValid || 
                    !intVec.InBounds(map) || 
                    !GenSight.LineOfSight(pawn.Position, intVec, map, pawn.OccupiedRect(), CellRect.SingleCell(intVec)) || 
                    (map.terrainGrid.TerrainAt(intVec).categoryType != TerrainDef.TerrainCategoryType.Sand &&
                    map.thingGrid.ThingAt(intVec, SandHaterTraitDefOf.Filth_Sand) == null &&
                    map.GetComponent<SandGrid>().GetDepth(intVec) <= 0f)
                    ) continue;
                return ThoughtState.ActiveAtStage(0);
            }
            return ThoughtState.Inactive;
        }
    }
}
