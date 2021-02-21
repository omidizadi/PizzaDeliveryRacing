using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [Header("Toast Message")] [SerializeField]
    private CanvasGroup toastCanvasGroup;

    [SerializeField] private RectTransform toast;
    [SerializeField] private Text toastMessage;

    [Header("Cash")] [SerializeField] private Text cashAmount;

    private GameManager gameManager;

    private Sequence sequence;

    private void Start()
    {
        gameManager = DependencyResolver.ResolveGameManager();
        gameManager.OnDestinationReached +=
            () => ShowToast("Congrats! You delivered pizza successfully! Now head to the next pizza!", 2f);
        gameManager.OnPizzaPicked += () =>
            ShowToast("You picked the pizza! Go to the destination to earn cash!", 2f);
        gameManager.OnCashReceived += SetCashAmount;
    }

    private void ShowToast(string message, float duration)
    {
        sequence?.Kill();
        sequence = DOTween.Sequence();
        toastMessage.text = message;
        sequence.Insert(0, toast.DOAnchorPosY(-150, duration).SetEase(Ease.OutBack));
        sequence.Insert(0, toastCanvasGroup.DOFade(1f, duration).SetEase(Ease.Linear));
        sequence.Insert(duration + 0.5f, toastCanvasGroup.DOFade(0, duration).SetEase(Ease.Linear));
        sequence.Insert(duration + 0.5f, toast.DOAnchorPosY(150, duration).SetEase(Ease.OutBack));
    }

    private void SetCashAmount()
    {
        cashAmount.text = gameManager.Cash.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}