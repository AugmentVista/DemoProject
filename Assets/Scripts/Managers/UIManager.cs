using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class UIManager : MonoBehaviour
{
    [Header("Object Connections")]
    public LevelManager levelManager;

    // References to UI Panels
    [Header("UI Screens")]
    public GameObject mainMenuUI;
    public GameObject gamePlayUI;
    public GameObject gameOverUI;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject creditsMenuUI;
    public GameObject LoadingScreen;

    [Header("Gameplay UI Elements")]
    // Gameplay Specific UI Elements
    public Text LevelCount;

    [Header("Loading Screen UI Elements")]
    public CanvasGroup loadingScreenCanvasGroup;
    public Image loadingBar;
    public TextMeshProUGUI loadingText;
    public float fadeTime = 0.5f;

    public void UpdateLevelCount(int count)
    {
        if (LevelCount != null)
        { LevelCount.text = count.ToString(); }

        if (LevelCount = null)
        { Debug.LogError("LevelCount is not assigned to UIManager in the inspector!"); }
    }


    public void UIMainMenu()
    {
        DisableAllUIPanels();
        mainMenuUI.SetActive(true);
    }

    public void UIGamePlay()
    {
        DisableAllUIPanels();
        gamePlayUI.SetActive(true);
    }

    public void UIGameOver()
    {
        DisableAllUIPanels();
        gameOverUI.SetActive(true);
    }

    public void UIPaused()
    {
        DisableAllUIPanels();
        pauseMenuUI.SetActive(true);
    }

    public void UIOptions()
    {
        DisableAllUIPanels();
        optionsMenuUI.SetActive(true);
    }


    public void UICredits()
    {
        DisableAllUIPanels();
        creditsMenuUI.SetActive(true);
    }

    public void UILoadingScreen(GameObject targetPanel)
    {
        StartCoroutine(LoadingUIFadeIN());
        StartCoroutine(DelayedSwitchUIPanel(fadeTime, targetPanel));
    }

    public void DisableAllUIPanels()
    {
        mainMenuUI.SetActive(false);
        gamePlayUI.SetActive(false);
        gameOverUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        creditsMenuUI.SetActive(false);
    }

    public void EnableAllUIPanels()
    {
        mainMenuUI.SetActive(true);
        gamePlayUI.SetActive(true);
        gameOverUI.SetActive(true);
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(true);
        creditsMenuUI.SetActive(true);
    }

    private IEnumerator LoadingUIFadeOut()
    {
        Debug.Log("Starting Fadeout");

        float timer = 0;

        while (timer < fadeTime)
        {
            loadingScreenCanvasGroup.alpha = Mathf.Lerp(1, 0, timer / fadeTime);
            timer += Time.deltaTime;
            yield return null;
        }

        loadingScreenCanvasGroup.alpha = 0;
        LoadingScreen.SetActive(false);
        loadingBar.fillAmount = 0;

        Debug.Log("Ending Fadeout");
    }

    private IEnumerator LoadingUIFadeIN()
    {
        Debug.Log("Starting Fadein");
        float timer = 0;
        LoadingScreen.SetActive(true);

        while (timer < fadeTime)
        {
            loadingScreenCanvasGroup.alpha = Mathf.Lerp(0, 1, timer / fadeTime);
            timer += Time.deltaTime;
            yield return null;
        }

        loadingScreenCanvasGroup.alpha = 1;

        Debug.Log("Ending Fadein");
        StartCoroutine(LoadingBarProgress());
    }

    private IEnumerator LoadingBarProgress()
    {
        Debug.Log("Starting Progress Bar");
        while (levelManager.scenesToLoad.Count <= 0)
        {
            //waiting for loading to begin
            yield return null;
        }
        while (levelManager.scenesToLoad.Count > 0)
        {
            loadingBar.fillAmount = levelManager.GetLoadingProgress();
            yield return null;
        }
        yield return new WaitForEndOfFrame();
        Debug.Log("Ending Progress Bar");
        StartCoroutine(LoadingUIFadeOut());
    }

    private IEnumerator DelayedSwitchUIPanel(float time, GameObject uiPanel)
    {
        yield return new WaitForSeconds(time);
        DisableAllUIPanels();
        uiPanel.SetActive(true);
    }
}