using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class UIViewLoadings : UIView
{
    [SerializeField] private RectTransform _logo;
    [SerializeField] private RectTransform _iconLoading;
    [SerializeField] private RectTransform _viewLoading;
  
    protected override void Start()
    {
        base.Start();
        Show(null);
   
    }
    public override void Show(object data = null, Action<bool> isDone = null)
    {
        base.Show(data, isDone);
        ShowLoading();
    }

    public override void Hide(Action<bool> isDone = null)
    {
        base.Hide(isDone);
    }

    private  async void ShowLoading()
    {
        _logo.DOScale(new Vector3(1, 1, 1), 0.1f);
        _iconLoading.DORotate(new Vector3(0,0,-180), 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetRelative().SetEase(Ease.Linear);
        await UniTask.Delay(4500);
        _viewLoading.DOAnchorPosX(2300, 0.3f);

    }
}