using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerUI : MonoBehaviour
{
    [Header("Dice")]
    public RectTransform diceImage;
    Dice dice;

    [Header("Rules Button")]
    [SerializeField] RectTransform rulesButton;
    RectTransform rulesButtonOriginalTransform;
    float originalLeft;
    public bool isOpen = false;

    [Header("Other")]
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject newRoundPanel;
    [SerializeField] Vector3 targetPosition;
    RectTransform initialRectTransform;
    RectTransform roundTransform;
    Vector2 screenSizeZero;
    public float duration = 1f;

    [Header ("Rhymes")]
    [SerializeField] Vector3 targetRhymesPosition;
    [SerializeField] GameObject bridge;
    [SerializeField] GameObject goose;
    [SerializeField] GameObject dices;
    RectTransform initialGooseRhymeRectTransform;
    RectTransform initialDiceRhymeRectTransform;
    RectTransform initialBridgeRhymeRectTransform;

    TurnManager turnManager;
    GameRules gameRules;

    private void Awake()
    {
        dice = GameObject.FindGameObjectWithTag("Dice").
            GetComponent<Dice>();
        turnManager = GameObject.FindGameObjectWithTag("TurnManager").
            GetComponent<TurnManager>();

        gameRules = GameObject.FindGameObjectWithTag("GameRules").
            GetComponent<GameRules>();

        
        initialRectTransform = startButton.GetComponent<RectTransform>();
        roundTransform = newRoundPanel.GetComponent<RectTransform>();
        initialGooseRhymeRectTransform = goose.GetComponent<RectTransform>();    
        initialDiceRhymeRectTransform = dices.GetComponent<RectTransform>();
        initialBridgeRhymeRectTransform = bridge.GetComponent<RectTransform>();

        startButton.SetActive(true);
        ClearScreenButton();
    }
    private void Start()
    {
        originalLeft = rulesButton.anchoredPosition.x;
        rulesButtonOriginalTransform = rulesButton;
        screenSizeZero = new Vector2(0, 0);
    }

    public void AnimatingDiceImage() //useless
    {
        diceImage.DOScale(new Vector3(0.5f, 0.5f, diceImage.localScale.z), 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
        {
            diceImage.DOScale(Vector3.zero, duration/2)
            .SetEase(Ease.OutQuad);
        });
    }
    public void StartAnimatingRound()
    {
        StartCoroutine(nameof(AnimateRound));
    }
    IEnumerator AnimateRound()
    {
        dice.canRollDice = false;
        newRoundPanel.SetActive(true);       
        roundTransform.DOLocalMove(targetPosition, duration)
            .SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(2);
        roundTransform.DOLocalMove(new Vector3(0, -800, 0), duration)
            .SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(1);
        newRoundPanel.SetActive(false);
        dice.canRollDice = true;
    }
    
    public void CurrentTurnAnimation(RectTransform currentButton) 
    {
        currentButton.DOAnchorPos
            (new Vector2(-40, currentButton.anchoredPosition.y), duration)
        .SetEase(Ease.InBounce);
    }
    public void CurrentTurnAnimationClose(RectTransform currentButton)
    {
        currentButton.DOAnchorPos
            (new Vector2(94.4f, currentButton.anchoredPosition.y), duration)
            .SetEase(Ease.InBounce);
        //-10
    }

    public void RulesButton()
    {
        if (rulesButtonOriginalTransform.anchoredPosition.x == originalLeft)
        {
            isOpen= true;
            rulesButton.DOAnchorPos(new Vector2(-115, rulesButtonOriginalTransform.anchoredPosition.y), duration).SetEase(Ease.InBounce);
        }
        else
        {
            isOpen = false;
            rulesButton.DOAnchorPos(new Vector2(originalLeft, rulesButtonOriginalTransform.anchoredPosition.y), duration).SetEase(Ease.InBounce);
        }  
    }
    #region Rhymes
    public void StartAnimatingBridgeRhymes()
    {
        StartCoroutine(nameof(BridgeRhymes));
    }
    public void StartAnimatingGooseRhymes()
    {
        StartCoroutine(nameof(GooseRhymes));
    }
    public void StartAnimatingDiceRhymes()
    {
        StartCoroutine(nameof(DiceRhymes));
    }
    IEnumerator BridgeRhymes()
    {
        bridge.SetActive(true);
        initialBridgeRhymeRectTransform.DOLocalMove(targetRhymesPosition, duration)
            .SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(3);
        initialBridgeRhymeRectTransform.DOLocalMove(new Vector3(0, 800, 0), duration)
            .SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(1);
        bridge.SetActive(false);
    }
    IEnumerator GooseRhymes()
    {
        goose.SetActive(true);
        initialGooseRhymeRectTransform.DOLocalMove(targetRhymesPosition, duration)
            .SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(3);
        initialGooseRhymeRectTransform.DOLocalMove(new Vector3(0, 800, 0), duration)
            .SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(1);
        goose.SetActive(false);
    }
    IEnumerator DiceRhymes()
    {
        dices.SetActive(true);
        initialDiceRhymeRectTransform.DOLocalMove(targetRhymesPosition, duration)
            .SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(3);
        initialDiceRhymeRectTransform.DOLocalMove(new Vector3(0, 800, 0), duration)
            .SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(1);
        dices.SetActive(false);
    }

    #endregion

    private void ClearScreenButton()
    {
        initialRectTransform.DOSizeDelta(screenSizeZero, 2f);
    }

}
    
