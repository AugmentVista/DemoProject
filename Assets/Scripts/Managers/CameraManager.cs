using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class CameraManager : MonoBehaviour
{
    [Header("Reference to the player's camera")]
    [SerializeField] public Camera playerCamera;

    [Header("The target the camera will follow")]
    [SerializeField] private Transform followTarget;
    [SerializeField] private Transform initialCameraOrientationTarget;

    [Header("Camera Distance Settings")]
    [SerializeField] private float distance = 5.0f; // Default distance from the target    
    [SerializeField] private float minDistance = 2.0f; // Minimum distance from the target
    [SerializeField] private float maxDistance = 8.0f; // Maximum distance from the target

    [Header("Camera Rotation Speed Settings")]
    [SerializeField] private float xSpeed = 120f; // Horizontal rotation speed
    [SerializeField] private float ySpeed = 120f; // Vertical rotation speed

    [Header("Camera Vertical Rotation Limits")]
    [SerializeField] private float yMinLimit = -20f; // Minimum vertical angle
    [SerializeField] private float yMaxLimit = 80f; // Maximum vertical angle

    [Header("Camera Inputs, values fed from InputManager")]
    public Vector2 cameraInput;
    public float zoomInput;

    public bool isCameraMoveEnabled = true;

    // Initial camera rotation angles
    private float x = 0.0f;
    private float y = 0.0f;


    private void Start()
    {
        SetInitialCameraOrientation(initialCameraOrientationTarget);

        // Get the initial rotation angles of the camera
        Vector3 angles = playerCamera.transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    private void LateUpdate()
    {
        if (isCameraMoveEnabled)
        { HandleCamera(); }
        
    }


    private void HandleCamera()
    {
        // Exit if there is no target
        if (followTarget == null) return;

        // Update the camera rotation and distance
        UpdateCameraRotation();
        UpdateDistance();

        // Calculate the new camera rotation and position
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 direction = rotation * new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = playerCamera.transform.position = rotation * new Vector3(0.0f, 0.0f, -distance) + followTarget.position;

        // Apply the new rotation and position to the camera
        playerCamera.transform.rotation = rotation;
        playerCamera.transform.position = position;
    }

    private void UpdateCameraRotation()
    {
        // Update the horizontal rotation based on mouse X movement
        x += cameraInput.x * xSpeed * Time.deltaTime;

        // Update the vertical rotation based on mouse Y movement
        y -= cameraInput.y * ySpeed * Time.deltaTime;

        // Clamp the vertical rotation to the specified limits
        y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
    }

    private void UpdateDistance()
    {
        // Update the distance based on mouse scroll wheel input
        distance -= zoomInput * Time.deltaTime * 1000;

        // Clamp the distance to the specified limits
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }

    private void SetInitialCameraOrientation(Transform orientationTarget)
    {
        // Ensure the target is assigned
        if (orientationTarget != null)
        {
            // Match the camera's initial rotation to the target's rotation
            Quaternion targetRotation = orientationTarget.rotation;
            Vector3 angles = targetRotation.eulerAngles;
            x = angles.y;
            y = angles.x;

            // Set the camera's initial position based on the target's position and distance
            Vector3 position = orientationTarget.position - (targetRotation * Vector3.forward * distance);
            playerCamera.transform.position = position;
            playerCamera.transform.rotation = targetRotation;
        }
        else
        {
            Debug.LogWarning("Target not assigned for CameraManager.");
            Debug.Log(orientationTarget);
        }


    }
}
