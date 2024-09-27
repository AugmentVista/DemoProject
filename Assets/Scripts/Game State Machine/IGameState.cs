// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)


// Defines the methods required for implementing a game state in the state machine.
// Each game state should implement this interface to ensure consistent behavior.


using static UnityEngine.Rendering.VirtualTexturing.Debugging;
using System.Runtime.ConstrainedExecution;
using UnityEngine.PlayerLoop;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public interface IGameState
{
    // Called when the game state is entered. This method should handle initialization logic specific to the state.
    void EnterState(GameStateManager gameStateManager);

    // Called once per physics frame to update the state.This method should handle physics-related updates.
    void FixedUpdateState(GameStateManager gameStateManager);
    
    // Called once per frame to update the state.This method should handle regular updates such as input handling and game logic.
    void UpdateState(GameStateManager gameStateManager);

    // Called once per frame after all Update and FixedUpdate calls.This method should handle post-update logic.
    void LateUpdateState(GameStateManager gameStateManager);

    // Called when the game state is exited.This method should handle cleanup and state transition logic.
    void ExitState(GameStateManager gameStateManager);
}
