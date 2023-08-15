using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

public abstract class UIView : MonoBehaviour
{
    protected Canvas _canvas;
    public virtual string Key => GetType().ToString();

    protected void Awake()
    {
        UIManager.RegisterView(this);
        _canvas = GetComponent<Canvas>();
    }
    protected virtual void Initialize()
    {
        _canvas.enabled = false;
    }
    protected virtual void Start()
    {
        Initialize();
    }

    protected virtual void OnDestroy()
    {
        UIManager.RemoveView(this);
    }

    public virtual async void Show(object data = null, Action<bool> isDone = null)
    {
        Show();
        await UniTask.CompletedTask;
    }

    public virtual void Show()
    {
        _canvas.enabled = true;
    }

    public virtual async void Hide(Action<bool> isDone = null)
    {
        _canvas.enabled = false;
        await UniTask.CompletedTask;
    }

    public virtual void SetSortingOrder(int index)
    {
        _canvas.sortingOrder = index;
    }
}
