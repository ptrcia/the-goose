using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelAnimation : MonoBehaviour
{

    [SerializeField] private RectTransform panelTransform;
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float animationDuration = 1f;

    [SerializeField] AudioClip audioBounce;

    private void Start()
    {
        panelTransform.localPosition = initialPosition;
    }

    public void AnimatePanel()
    {
        //DOTween.Init();

        if (!gameObject.activeInHierarchy)
        {
            AudioManager.instance.PlaySound(audioBounce);
        }

        gameObject.SetActive(true);
        if(panelTransform!=null)
        {
            panelTransform.DOLocalMove(targetPosition, animationDuration).SetEase(Ease.OutBounce);
        }
    }
}