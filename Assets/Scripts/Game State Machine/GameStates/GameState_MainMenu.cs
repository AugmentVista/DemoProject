using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class GameState_MainMenu : IGameState
{
    public void EnterState(GameStateManager gameStateManager)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        // May want to consider locking the cursor to the center of the screen

        gameStateManager._uIManager.UIMainMenu();
        gameStateManager._playerManager.player.SetActive(false);
        gameStateManager._cameraManager.isCameraMoveEnabled = false;

        
    }

    public void FixedUpdateState(GameStateManager gameStateManager) { }
    public void UpdateState(GameStateManager gameStateManager) { }
    public void LateUpdateState(GameStateManager gameStateManager) { }
    public void ExitState(GameStateManager gameStateManager) { }


}
