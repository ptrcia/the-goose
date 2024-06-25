using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LanguageDropdownFontBoard : MonoBehaviour, IPointerClickHandler
{
    private string language;

    [SerializeField] TMP_FontAsset japaneseFont;
    [SerializeField] TMP_FontAsset basicFont;
    private TMP_Dropdown dropdown;

    private Dictionary<string, string> translations = new Dictionary<string, string>
    {
        { "English", "Classic" },
        { "Spanish", "Clásico" },
        { "Japanese", "クラシック" },
    };

    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        language = PlayerPrefs.GetString("LanguageChosen");
        UpdateLabelAndOptions();
    }
    private void Update()
    {
        string newLanguage = PlayerPrefs.GetString("LanguageChosen");
        if (newLanguage != language)
        {
            language = newLanguage;
            UpdateLabelAndOptions();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(WaitForOptions());
    }

    private IEnumerator WaitForOptions()
    {
        yield return null;
        UpdateLabelAndOptions();
    }


    private void UpdateLabelAndOptions()
    {
        if (translations.ContainsKey(language))
        {
            // Label
            TMP_Text dropdownLabel = dropdown.transform.Find("Label").GetComponent<TMP_Text>();
            dropdownLabel.text = translations[language];
            TMP_FontAsset selectedFont = basicFont;
            if (language == "Japanese")
            {
                dropdownLabel.font = japaneseFont;
            }
            else
            {
                dropdownLabel.font = selectedFont;
            }
 
            //Options
            List<TMP_Dropdown.OptionData> newOptions = new List<TMP_Dropdown.OptionData>();
            foreach (var option in dropdown.options)
            {
                string translatedText = translations[language];
                TMP_Dropdown.OptionData newOption = new TMP_Dropdown.OptionData(translatedText);
                newOptions.Add(newOption);
            }
            dropdown.options = newOptions;

            // Refresh
            dropdown.RefreshShownValue();

            
            // Refresh fonts on deployed dropdown
            Transform dropdownList = dropdown.transform.Find("Dropdown List");
            if (dropdownList != null)
            {
                foreach (Transform option in dropdownList)
                {
                    TMP_Text optionText = option.GetComponentInChildren<TMP_Text>();
                    optionText.font = selectedFont;
                }
            }
        }
    }
}
