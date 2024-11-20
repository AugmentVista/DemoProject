using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    [SerializeField] private string tableReference;

    [SerializeField] private string localizationKey;

    private LocalizedString localizedText;
    public Text text;

    void Start()
    {
        localizedText = new LocalizedString { TableReference = tableReference, TableEntryReference = localizationKey };

        var frenchLocale = LocalizationSettings.AvailableLocales.GetLocale("fr");

        var englishLocale = LocalizationSettings.AvailableLocales.GetLocale("en");

        LocalizationSettings.SelectedLocale = englishLocale;
    }
    private void OnEnable()
    {
        LocalizationSettings.SelectedLocaleChanged += UpdateText;
    }

    private void OnDisable()
    {
        LocalizationSettings.SelectedLocaleChanged -= UpdateText;
    }

    void UpdateText(Locale locale)
    {
        if (text == null) 
        {
            Debug.LogError($"Text object with text {text.text}");
            text = text.GetComponent<Text>(); 
        }
        text.text = localizedText.GetLocalizedString();
    }
}
