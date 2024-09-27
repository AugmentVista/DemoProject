using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class GameManager : MonoBehaviour
{
    [Header("Gameplay Info")]
    // store a ref to GamePlay specific variables here
    // Ammo/health/points etc 
    // Could also use static variables for those and just store a ref to them here.

    public GameObject startPosition;

    [Header("Script References")]
    public GameManager _gameManager;
    public GameStateManager _gameStateManager;
    public PlayerManager _playerManager;
    public UIManager _uIManager;
    public CameraManager _cameraManager;
    public LevelManager _levelManager;

    public void Awake()
    {
        // Check for missing script references
        if (_gameManager == null) { Debug.LogError("GameManager is not assigned to GameManager in the inspector!"); }
        if (_gameStateManager == null) { Debug.LogError("GameStateManager is not assigned to GameManager in the inspector!"); }
        if (_playerManager == null) { Debug.LogError("PlayerManager is not assigned to GameManager in the inspector!"); }
        if (_uIManager == null) { Debug.LogError("UIManager is not assigned to GameManager in the inspector!"); }
        if (_cameraManager == null) { Debug.LogError("CameraManager is not assigned to GameManager in the inspector!"); }
        if (_levelManager == null) { Debug.LogError("LevelManager is not assigned to GameManager in the inspector!"); }

    }   
}
