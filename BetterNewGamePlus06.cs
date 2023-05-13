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
    private static datUnitWork_t[] partyList = new datUnitWork_t[12];
    private static int stockCount;
    private static int[] stockList;
    private static byte[] itemList;
    private static byte[] magatamaList;
    private static int macca = 0;

    // When destroying a savefile for a NG+
    [HarmonyPatch(typeof(dds3GlobalWork), nameof(dds3GlobalWork.NewGame2Push))]
    private class Patch
    {
        public static void Postfix()
        {
            rstCalcCore.cmbSubHeartsParam(dds3GlobalWork.DDS3_GBWK.heartsequip, dds3GlobalWork.DDS3_GBWK.unitwork[0]); // Remove Demi-fiend's current Magatama
            partyList = dds3GlobalWork.DDS3_GBWK.unitwork; // Demi-fiend and his demons in party and stock
            stockCount = dds3GlobalWork.DDS3_GBWK.stockcnt; // Number of demons in stock
            stockList = dds3GlobalWork.DDS3_GBWK.stocklist; // Demons in stock

            itemList = dds3GlobalWork.DDS3_GBWK.item; // Items

            macca = dds3GlobalWork.DDS3_GBWK.maka; // Macca

            magatamaList = dds3GlobalWork.DDS3_GBWK.hearts; // Collected Magamata
        }
    }

    // When creating a NG+
    [HarmonyPatch(typeof(dds3GlobalWork), nameof(dds3GlobalWork.NewGame2Pop))]
    private class Patch2
    {
        public static void Postfix()
        {
            dds3GlobalWork.DDS3_GBWK.maxstock = 12; // Maximum number of slots in stock
            dds3GlobalWork.DDS3_GBWK.item[12] = itemList[12]; // Chakra Elixir
            dds3GlobalWork.DDS3_GBWK.item[44] = itemList[44]; // Blessed Fan
            dds3GlobalWork.DDS3_GBWK.item[45] = itemList[45]; // Soul Return
            dds3GlobalWork.DDS3_GBWK.item[46] = itemList[46]; // Spyglass
            dds3GlobalWork.DDS3_GBWK.item[60] = itemList[60]; // Cursed Gospel (mod)
        }
    }

    [HarmonyPatch(typeof(EventBit), nameof(EventBit.evtBitOn))]
    private class Patch4
    {
        public static void Postfix(ref int no)
        {
            // If the leather jacket was selected
            if (no == 2224)
            {
                dds3GlobalWork.DDS3_GBWK.unitwork = partyList; // Demi-fiend and his demons in party and stock
                dds3GlobalWork.DDS3_GBWK.maxstock = 12; // Maximum number of slots in stock
                dds3GlobalWork.DDS3_GBWK.stockcnt = stockCount; // Number of demons in stock
                dds3GlobalWork.DDS3_GBWK.stocklist = stockList; // Demons in stock

                dds3GlobalWork.DDS3_GBWK.item = itemList; // Items

                dds3GlobalWork.DDS3_GBWK.maka = macca; // Macca

                foreach (byte item in magatamaList) // Collected Magatama
                {
                    datCalc.datAddHearts(item);
                }

                dds3GlobalWork.DDS3_GBWK.unitwork[0].param[2] -= 2; // Removes the 2 bonus magic points from the leather jacket
                dds3GlobalWork.DDS3_GBWK.unitwork[0].param[4] -= 1; // Removes the 1 bonus agility points from the leather jacket
            }
        }
    }

}
