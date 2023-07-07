using MelonLoader;
using BTD_Mod_Helper;
using RoundSplitter;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Pause;

[assembly: MelonInfo(typeof(RoundSplitter.RoundSplitter), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace RoundSplitter;

public class RoundSplitter : BloonsTD6Mod
{

    int round = 0;
    bool gameStarted = false;

    public override void OnApplicationStart()
    {
        ModHelper.Msg<RoundSplitter>("RoundSplitter v0.1 loaded!");

        WriteToFile(""); // blank round file
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        bool inAGame = InGame.instance != null && InGame.instance.bridge != null;
        
        if (inAGame)
        {
            // Write to file to signal when the rounds start
            if (!gameStarted && InGame.instance.bridge.AreRoundsActive())
            {
                gameStarted = true;
                WriteToFile("start");
            }
            // Only write round every 5 rounds
            // MODIFY THIS if you want more updates. Try not to have it on a round when the game starts,
            // As it might overwrite too fast before livesplit can signal a start.
            else if (gameStarted && round != GetCurrentRound() && (GetCurrentRound() % 5 == 0))
            {
                round = GetCurrentRound();
                WriteToFile(round + "");
            }
        }
    }

    public override void OnVictory()
    {
        base.OnVictory();
        WriteToFile("win");
        resetVars();
    }

    public override void OnDefeat()
    {
        base.OnDefeat();
        WriteToFile("reset");
        resetVars();
    }

    public override void OnRestart()
    {
        base.OnRestart();
        WriteToFile("reset");
        resetVars();
    }

    public override void OnMainMenu()
    {
        base.OnMainMenu();
        WriteToFile("reset");
        resetVars();
    }

    public override void OnTitleScreen()
    {
        base.OnTitleScreen();
        WriteToFile("reset");
        resetVars();
    }

    public int GetCurrentRound()
    {
        return InGame.instance.bridge.GetCurrentRound() + 1; // btd6 returns rounds-1
    }

    public void resetVars()
    {
        round = 0;
        gameStarted = false;
    }

    // Write the input text to the mod file
    public void WriteToFile(string text)
    {
        try
        {
            System.IO.File.WriteAllText("Mods/LiveSplit/round.txt", text);
        }
        catch
        {

        }
    }
}