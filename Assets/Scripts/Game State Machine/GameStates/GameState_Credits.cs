using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class GameState_Credits : IGameState
{
    void IGameState.EnterState(GameStateManager gameStateManager)
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        gameStateManager._uIManager.UICredits();
        gameStateManager._cameraManager.isCameraMoveEnabled = false;        
    }

    void IGameState.FixedUpdateState(GameStateManager gameStateManager)
    {
        
    }

    void IGameState.UpdateState(GameStateManager gameStateManager)
    {
        
    }

    void IGameState.LateUpdateState(GameStateManager gameStateManager)
    {

    }

    void IGameState.ExitState(GameStateManager gameStateManager)
    {

    }

}
