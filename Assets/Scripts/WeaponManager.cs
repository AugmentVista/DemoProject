using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] CameraManager camManager;
    [SerializeField] Camera playerCam;

    [SerializeField] LayerMask cubeFilter;
    [SerializeField] LayerMask sphereFilter;

    private Renderer currentCubeRenderer;
    private Renderer currentSphereRenderer;

    public List<Color> colorList;

    public int colorAmount = 10;

    private float rgbAmount = 0.05f;

    void Start()
    {
        colorAmount = 20;
        playerCam = camManager.playerCamera;
        colorList = new List<Color>();
        AddColors();
        Debug.Log(colorList.Count);

        StartCoroutine(Timer());
    }

    public void AddColors()
    {
        for (int j = 0; j < colorAmount; j++)
        {
            colorList.Add(new Color(0.1f + rgbAmount, 0.1f, 0.1f));
            colorList.Add(new Color(0.1f, 0.1f + rgbAmount, 0.1f));
            colorList.Add(new Color(0.1f, 0.1f, 0.1f + rgbAmount));
            rgbAmount += 0.1f;
        }
    }

    private IEnumerator Timer()
    {
        while (true) // Infinite loop
        {
            DetectCube();
            DetectSphere();
            yield return new WaitForSeconds(0.5f);

        }
    }

    private void DetectCube()
    {
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, 50, cubeFilter))
        {
            Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * hit.distance, Color.yellow);

            if (hit.collider.TryGetComponent(out Renderer cubeRenderer))
            {
                currentCubeRenderer = cubeRenderer;

                if (colorList.Count > 0)
                {
                    currentCubeRenderer.material.color = colorList[Random.Range(0, colorList.Count)];
                }
                else
                {
                    currentCubeRenderer.material.color = Color.red; 
                }
            }
        }
        else if (currentCubeRenderer != null)
        {
            currentCubeRenderer.material.color = Color.red; // Reset to red
            currentCubeRenderer = null; // Clear the reference
        }
    }

    private void DetectSphere()
    {
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, 50, sphereFilter))
        {
            Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * hit.distance, Color.blue);

            if (hit.collider.TryGetComponent(out Renderer sphereRenderer))
            {
                currentSphereRenderer = sphereRenderer;

                if (colorList.Count > 0)
                {
                    currentSphereRenderer.material.color = colorList[Random.Range(0, colorList.Count)];
                }
                else
                {
                    currentSphereRenderer.material.color = Color.red; 
                }
            }
        }
        else if (currentSphereRenderer != null)
        {
            currentSphereRenderer.material.color = Color.red; // Reset to red
            currentSphereRenderer = null; // Clear the reference
        }
    }
}
