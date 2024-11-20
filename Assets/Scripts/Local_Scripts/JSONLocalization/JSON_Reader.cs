using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Language 
{
    public string lang;
    public string title;
    public string play;
    public string quit;
    public string options;
    public string credits;
}

public class LanguageData
{ 
    public Language[] languages;
}

public class JSON_Reader : MonoBehaviour
{
    public TextAsset jsonFile;
    [SerializeField] private string currentLanguage = "en";
    private LanguageData languageData;

    public Text titleText;
    public Text playText;
    public Text quitText;
    public Text optionsText;
    public Text creditsText;


    private void Start()
    {
        languageData = JsonUtility.FromJson<LanguageData>(jsonFile.text);
        SetLanguage();
    }

    public void SetLanguage()
    {
        if (currentLanguage == "en")
        { 
        currentLanguage = "fr";
            string newLanguage = currentLanguage;
            foreach (Language lang in languageData.languages)
            {
                if (lang.lang.ToLower() == newLanguage.ToLower())
                {
                    titleText.text = lang.title;
                    playText.text = lang.play;
                    quitText.text = lang.quit;
                    optionsText.text = lang.options;
                    creditsText.text = lang.credits;
                    return;
                }
            }
        }
        if (currentLanguage == "fr")
        {
            currentLanguage = "en";
            string newLanguage = currentLanguage;
            foreach (Language lang in languageData.languages)
            {
                if (lang.lang.ToLower() == newLanguage.ToLower())
                {
                    titleText.text = lang.title;
                    playText.text = lang.play;
                    quitText.text = lang.quit;
                    optionsText.text = lang.options;
                    creditsText.text = lang.credits;
                    return;
                }
            }
        }
        
    }
}
