using RimWorld;
using Verse;

namespace SandHaterTrait
{
    public class ThoughtWorker_SandHater : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn pawn)
        {
            if (!(pawn?.Map is Map map)) return false;
            if (map.Biome == BiomeDefOf.Desert || map.Biome == SandHaterTraitDefOf.ExtremeDesert) return true;
            for (int i = 0; i < 48; i++)
            {
                IntVec3 intVec = pawn.Position + GenRadial.RadialPattern[i];
                if (GenSight.LineOfSight(pawn.Position, intVec, map, pawn.OccupiedRect(), CellRect.SingleCell(intVec)) && 
                    map.terrainGrid.TerrainAt(intVec).categoryType == TerrainDef.TerrainCategoryType.Sand
                    ) return true;
            }
            return false;
        }
    }
}
