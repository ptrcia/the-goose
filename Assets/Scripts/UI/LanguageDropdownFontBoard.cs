using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LanguageDropdownFontBoard : MonoBehaviour, IPointerClickHandler
{

   // para el de tipo de tablero tendrás que crear otro script igual, 
   //     pero en lugar de buscar la opción de japonés y cambiar la fuente, 
   //     tendrás que recorrer todas las opciones y traducir cambiando la fuente

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
        // Recorre todas las opciones y cambia la fuente
        foreach (Transform option in optionsContainer)
        {
            TMP_Text optionText = option.GetComponentInChildren<TMP_Text>();

            if (optionText != null)
            {
                optionText.font = japaneseFont;
            }
        }
    }
}
