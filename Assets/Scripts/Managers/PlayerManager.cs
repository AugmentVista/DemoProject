using System.Collections;
using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class PlayerManager : MonoBehaviour
{
    [Header("References")]
    public GameObject player;  

    [Header("Script References")]
    public GameStateManager _gameStateManager;
    public CameraManager _cameraManager;
    public GameManager _gameManager;
    public LevelManager _levelManager;
    public UIManager _uIManager;
    public InputManager _inputManager;
    public PlayerLocomotionHandler _playerLocomotionHandler;



    

    public void Awake()
    {
        
        // Check for missing script references
        if (_gameStateManager == null) { Debug.LogError("GameStateManager is not assigned to PlayerManager in the inspector!"); }
        if (_cameraManager == null) { Debug.LogError("CameraManager is not assigned to PlayerManager in the inspector!"); }
        if (_gameManager == null) { Debug.LogError("GameManager is not assigned to PlayerManager in the inspector!"); }
        if (_levelManager == null) { Debug.LogError("LevelManager is not assigned to PlayerManager in the inspector!"); }
        if (_uIManager == null) { Debug.LogError("UIManager is not assigned to PlayerManager in the inspector!"); }
        if (_inputManager == null) { Debug.LogError("InputManager is not assigned to PlayerManager in the inspector!"); }
        if (_playerLocomotionHandler == null) { Debug.LogError("PlayerLocomotionHandler is not assigned to PlayerManager in the inspector!"); }
        
    }



    private void Start()
    {
        
    }

 
    void Update()
    {
        _inputManager.HandleAllInputs();
        _playerLocomotionHandler.HandleAllPlayerMovement();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LevelEndTrigger")
        {
            // Change tag to level end
        }

        else if (other.gameObject.tag == "ResetTrigger") 
        {
            ResetPlayerToSpawn();
        }
    }

    

    public void ResetPlayerToSpawn()
    {
        // TODO: lock out Character controller while move is performed...
        
        player.transform.position = new Vector3(0, 1, 0);


   
    }



}
