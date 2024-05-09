using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject specificRule;
    GameManagerUI gameManagerUI;
    AudioSource audioSource;
    [SerializeField] AudioClip audioClipClick;

    private void Awake()
    {
        gameManagerUI = GameObject.FindGameObjectWithTag("GameManagerUI")
            .GetComponent<GameManagerUI>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audioSource.clip = audioClipClick;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameManagerUI.isOpen == true)
        {
            audioSource.Play();
            specificRule.SetActive(true);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        
        if (gameManagerUI.isOpen == true)
        {
            audioSource.Play();
            specificRule.SetActive(false);
        }
    }
}
