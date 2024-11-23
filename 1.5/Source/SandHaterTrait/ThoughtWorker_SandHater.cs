using RimWorld;
using Verse;

namespace SandHaterTrait
{
    public class ThoughtWorker_SandHater : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn pawn)
        {
            Map map = pawn.Map;
            if (map.Biome == BiomeDefOf.Desert || map.Biome == SandHaterTraitDefOf.ExtremeDesert) return true;
            for (int i = 0; i < 48; i++)
            {
                IntVec3 intVec = pawn.Position + GenRadial.RadialPattern[i];
                if (GenSight.LineOfSight(pawn.Position, intVec, map, pawn.OccupiedRect(), CellRect.SingleCell(intVec)) && 
                    (map.terrainGrid.TerrainAt(intVec) == TerrainDefOf.Sand || map.terrainGrid.TerrainAt(intVec) == SandHaterTraitDefOf.SoftSand)
                    ) return true;
            }
            return false;
        }
    }
}
