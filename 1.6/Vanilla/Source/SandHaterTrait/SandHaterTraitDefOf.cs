using RimWorld;
using Verse;

namespace SandHaterTrait
{
    [DefOf]
    public class SandHaterTraitDefOf
    {
        static SandHaterTraitDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(SandHaterTraitDefOf));
        }

        public static BiomeDef ExtremeDesert;
        public static ThingDef Filth_Sand;
    }
}
