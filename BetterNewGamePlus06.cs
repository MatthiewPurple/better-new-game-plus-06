using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using better_new_game_plus_06;
using Il2Cppnewdata_H;

[assembly: MelonInfo(typeof(BetterNewGamePlus06), "Better New Game Plus [macca only] (0.6 ver.)", "1.0.0", "Matthiew Purple & xenopiece")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace better_new_game_plus_06;
public class BetterNewGamePlus06 : MelonMod
{
    private static int macca = 0;

    // When destroying a savefile for a NG+
    [HarmonyPatch(typeof(dds3GlobalWork), nameof(dds3GlobalWork.NewGame2Push))]
    private class Patch
    {
        public static void Postfix()
        {
            macca = dds3GlobalWork.DDS3_GBWK.maka; // Macca
        }
    }

    // When creating a NG+
    [HarmonyPatch(typeof(dds3GlobalWork), nameof(dds3GlobalWork.NewGame2Pop))]
    private class Patch2
    {
        public static void Postfix()
        {
            dds3GlobalWork.DDS3_GBWK.maka = macca; // Macca
        }
    }
}
