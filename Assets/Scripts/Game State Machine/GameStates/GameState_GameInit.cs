using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class GameState_GameInit : IGameState
{
    // This state is used the first time the game is Initialized (launched/opened)
    // It will be used to set up all default settings
    // I realize this could be done in the MainMenuState as returning to it could count as a game reset of sorts... but it seems cleaner to have it's own state for this

    public void EnterState(GameStateManager gameStateManager)
    {
        Cursor.visible = false;

        // Enable all UI Panels, activates them so any scripts can get references to them if needed, each other state will disable them as needed
        gameStateManager._uIManager.EnableAllUIPanels();
        
        // Switch to MainMenu state
        gameStateManager.SwitchToState(new GameState_MainMenu());

        
    }

    public void FixedUpdateState(GameStateManager gameStateManager) { }
    public void UpdateState(GameStateManager gameStateManager) { }
    public void LateUpdateState(GameStateManager gameStateManager) { }


    public void ExitState(GameStateManager gameStateManager) 
    {
        // Disable all UI Panels
        gameStateManager._uIManager.DisableAllUIPanels();
    }

}
