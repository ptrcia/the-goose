using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LanguageDropdownFont : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TMP_FontAsset japaneseFont;

    private TMP_Dropdown dropdown;

    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(WaitForOptions());
    }

    private IEnumerator WaitForOptions()
    {
        // Espera un frame para que las opciones se generen
        yield return null;

        Transform dropdownList = dropdown.transform.Find("Dropdown List");
        if (dropdownList != null)
        {
            UpdateDropdownFonts(dropdownList);
        }
    }

    private void UpdateDropdownFonts(Transform optionsContainer)
    {
        TMP_Text optionText = optionsContainer.GetChild(0).GetChild(0).GetChild(3).GetComponentInChildren<TMP_Text>();
        optionText.font = japaneseFont;
    }
}
