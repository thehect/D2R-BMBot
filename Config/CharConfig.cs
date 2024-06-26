﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app
{
    public static class CharConfig
    {

        //#######################################
        //SHORTCUT KEY TO START/STOP BOT
        //#######################################
        public static System.Windows.Forms.Keys StartStopKey = Keys.NumPad5;   //numpad5 -> refer to virtual key code (vkcode)
        public static System.Windows.Forms.Keys PauseResumeKey = Keys.NumPad6;   //numpad6 -> refer to virtual key code (vkcode)

        //#######################################
        //SHORTCUT KEYS SETTINGS (FOR PALADIN)
        //#######################################
        public static System.Windows.Forms.Keys KeySkillAttack = Keys.F1;               //hammer
        public static System.Windows.Forms.Keys KeySkillAura = Keys.F2;                 //concentration
        public static System.Windows.Forms.Keys KeySkillfastMoveAtTown = Keys.F7;       //vigor
        public static System.Windows.Forms.Keys KeySkillfastMoveOutsideTown = Keys.F7;  //refer to teleport if have teleport else vigor
        public static System.Windows.Forms.Keys KeySkillDefenseAura = Keys.F6;          //defiance
        public static System.Windows.Forms.Keys KeySkillCastDefense = Keys.F5;          //sacred shield
        public static System.Windows.Forms.Keys KeySkillLifeAura = Keys.F3;             //prayer
        public static System.Windows.Forms.Keys KeySkillBattleOrder = Keys.D5;          //BO - BattleOrder
        public static System.Windows.Forms.Keys KeySkillBattleCommand = Keys.D6;        //BattleCommand
        public static System.Windows.Forms.Keys KeySkillBattleCry = Keys.D7;            //BattleCry

        //#######################################
        //BELT AND INVENTORY SETTINGS
        //#######################################
        public static System.Windows.Forms.Keys KeyPotion1 = Keys.D1;
        public static System.Windows.Forms.Keys KeyPotion2 = Keys.D2;
        public static System.Windows.Forms.Keys KeyPotion3 = Keys.D3;
        public static System.Windows.Forms.Keys KeyPotion4 = Keys.D4;
        public static int[] BeltPotTypeToHave = new int[4] { 0, 0, 1, 3 };  //HP-HP-MANA-FULL RV -> 0=HP, 1=MANA, 2=RV, 3=FULL RV
        public static int[] InventoryDontCheckItem = new int[40]
        {
            0, 0, 0, 0, 0, 1, 1, 1, 1, 1,   //IF EQUAL 0, WE CAN USE THIS SPOT FOR BOT
            0, 0, 0, 0, 0, 1, 1, 1, 1, 1,   //IF EQUAL 0, WE CAN USE THIS SPOT FOR BOT
            0, 0, 0, 0, 1, 1, 1, 1, 1, 1,   //IF EQUAL 0, WE CAN USE THIS SPOT FOR BOT
            0, 0, 0, 0, 1, 1, 1, 1, 1, 1    //IF EQUAL 0, WE CAN USE THIS SPOT FOR BOT
        };
        public static string DummyItemSharedStash1 = "Key";                     //PUT THIS DUMMY ITEM IN SHARED STASH1 SO ITEMS DETECTION CORRECTLY APPLY TO THIS STASH
        public static string DummyItemSharedStash2 = "Scroll of Identify";      //PUT THIS DUMMY ITEM IN SHARED STASH2 SO ITEMS DETECTION CORRECTLY APPLY TO THIS STASH
        public static string DummyItemSharedStash3 = "Scroll of Town Portal";   //PUT THIS DUMMY ITEM IN SHARED STASH3 SO ITEMS DETECTION CORRECTLY APPLY TO THIS STASH

        //#######################################
        //PLAYER SETTINGS
        //#######################################
        public static string PlayerCharName = ""; //CHAR NAME
        public static bool UseTeleport = true;
        public static bool UseBO = true;
        public static int ChickenHP = 22;           //VALUE IN PERCENT
        public static int TakeHPPotUnder = 85;      //VALUE IN PERCENT
        public static int TakeRVPotUnder = 35;      //VALUE IN PERCENT
        public static int TakeManaPotUnder = 15;    //VALUE IN PERCENT
        public static int GambleAboveGoldAmount = 500000;   //IF GOLD IN STASH EXCEED AMOUNT, WE GAMBLE FOR GOLD
        public static int GambleUntilGoldAmount = 100000;   //GAMBLE UNTIL THIS LOW GOLD AMOUNT IS REACHED
        public static bool PlayerAttackWithRightHand = true;
        public static (int, int) KeysLocationInInventory = (8, 0);
        public static bool GrabForGold = true;
        public static bool IDAtShop = true;
        public static bool LeaveDiabloClone = true;
        public static bool GambleGold = true;
        public static bool UseKeys = true;
        public static List<string> GambleItems = new List<string> { "Amulet", "Ring" };

        //#######################################
        //MERC SETTINGS
        //#######################################
        public static bool UsingMerc = true;
        public static int MercTakeHPPotUnder = 40; //NOT YET WORKING

        //#######################################
        //BOT SETTINGS (USE ONLY CHAOS OR BAAL, NOT BOTH AT SAME TIME)
        //#######################################
        public static int MaxGameTime = 7;                  //9MINS -> TIME IN MINUTES
        public static bool IsRushing = false;
        public static string RunningOnChar = "";
        public static string RushLeecherName = "";
        public static bool ClearAfterBoss = false;
        public static bool ShowOverlay = true;
        public static bool RunWPTaker = false;
        public static bool RunNoLobbyScript = false;
        public static bool RunMapHackOnly = false;
        public static bool RunAnyaRush = false;
        public static bool RunDarkWoodRush = false;
        public static bool RunTristramRush = false;
        public static bool RunAndarielRush = false;
        public static bool RunRadamentRush = false;
        public static bool RunHallOfDeadRush = false;
        public static bool RunFarOasisRush = false;
        public static bool RunLostCityRush = false;
        public static bool RunSummonerRush = false;
        public static bool RunDurielRush = false;
        public static bool RunKahlimEyeRush = false;
        public static bool RunKahlimBrainRush = false;
        public static bool RunKahlimHeartRush = false;
        public static bool RunTravincalRush = false;
        public static bool RunMephistoRush = false;
        public static bool RunChaosRush = false;
        public static bool RunAncientsRush = false;
        public static bool RunBaalRush = false;
        //public static bool RunRush = false;
        public static bool RunCowsScript = false;
        public static bool RunEldritchScript = false;
        public static bool RunShenkScript = false;
        public static bool RunNihlatakScript = false;
        public static bool RunFrozensteinScript = false;
        public static bool RunPindleskinScript = false;
        public static bool RunTravincalScript = false;
        public static bool RunMephistoScript = false;
        public static bool RunAndarielScript = false;
        public static bool RunCountessScript = false;
        public static bool RunSummonerScript = false;
        public static bool RunDurielScript = false;
        public static bool RunChaosScript = false;
        public static bool RunChaosLeechScript = false;          //CHAOS LEECH SCRIPT **NOT FINISHED**
        public static bool RunLowerKurastScript = false;     //LOWER KURAST SCRIPT
        public static bool RunUpperKurastScript = false;
        public static bool RunA3SewersScript = false;
        public static bool RunBaalScript = true;
        public static bool RunBaalLeechScript = true;       //BAAL LEECH SCRIPT
        public static bool RunItemGrabScriptOnly = false;
        //NOT IN GAME SCRIPT (SEARCH GAMES OR CREATE A NEW GAME)
        public static bool RunChaosSearchGameScript = false; //CHAOS GAMES SEARCHER SCRIPT
        public static bool RunBaalSearchGameScript = true; //BAAL GAMES SEARCHER SCRIPT
        public static bool RunGameMakerScript = false;       //CREATE NEW GAME SCRIPT
        public static string GameName = "LOWERKTEST";         //SET GAME NAME, IF USING GAME MAKER
        public static string GamePass = "33";               //SET GAME PASS, IF USING GAME MAKER
        public static int GameDifficulty = 2;      //0 = normal, 1 = nighmare, 2 = hell

        //#######################################
        //AVOID IMMUNE SETTINGS
        //#######################################
        public static bool AvoidColdImmune = false;
        public static bool AvoidFireImmune = false;
        public static bool AvoidLightImmune = false;
        public static bool AvoidPoisonImmune = false;
        public static bool AvoidMagicImmune = false;

        //#######################################
        //GAME/PC SCREEN SETTINGS
        //#######################################
        //public static int ScreenX = 1920;
        //public static int ScreenY = 1080;
        //public static int ScreenYMenu = 180;    //REMOVE 180 PIXEL FROM THE BOTTOM SCREEN TO NOT CLIC ANY BOTTOM MENU BUTTONS



    }
}
