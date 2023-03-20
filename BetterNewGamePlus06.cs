using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using better_new_game_plus_06;

[assembly: MelonInfo(typeof(BetterNewGamePlus06), "Better New Game Plus [items only] (0.6 ver.)", "1.0.0", "Matthiew Purple & xenopiece")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace better_new_game_plus_06;
public class BetterNewGamePlus06 : MelonMod
{
    private static byte[] itemList;

    // When destroying a savefile for a NG+
    [HarmonyPatch(typeof(dds3GlobalWork), nameof(dds3GlobalWork.NewGame2Push))]
    private class Patch
    {
        public static void Postfix()
        {
            itemList = dds3GlobalWork.DDS3_GBWK.item; // Items
        }
    }

    // When creating a NG+
    [HarmonyPatch(typeof(dds3GlobalWork), nameof(dds3GlobalWork.NewGame2Pop))]
    private class Patch2
    {
        public static void Postfix()
        {
            dds3GlobalWork.DDS3_GBWK.item = itemList; // Items
        }
    }
}
