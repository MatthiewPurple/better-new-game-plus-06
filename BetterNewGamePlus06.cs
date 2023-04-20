using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using better_new_game_plus_06;
using Il2Cppnewdata_H;

[assembly: MelonInfo(typeof(BetterNewGamePlus06), "Better New Game Plus (0.6 ver.)", "1.0.0", "Matthiew Purple & xenopiece")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace better_new_game_plus_06;
public class BetterNewGamePlus06 : MelonMod
{
    // When creating a NG+
    [HarmonyPatch(typeof(dds3GlobalWork), nameof(dds3GlobalWork.NewGame2Pop))]
    private class Patch
    {
        public static void Postfix()
        {
            dds3GlobalWork.DDS3_GBWK.encyc_record.Clear(); // Clears the compendium
        }
    }
}
