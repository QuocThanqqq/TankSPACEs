using System.Collections.Generic;
using UnityEngine;

public static class UIManager 
{
    private static Dictionary<string, UIView> _viewCollection = new();

    public static void RegisterView(UIView view)
    {
        _viewCollection.Add(view.Key, view);
    }

    public static void RemoveView(UIView view)
    {
        _viewCollection.Remove(view.Key);
    }

    public static T GetView<T>() where T : UIView
    {
        string viewKey = typeof(T).ToString();

        if (!_viewCollection.ContainsKey(viewKey))
        {
            Debug.LogError("No view found!");
            return null;
        }

        return _viewCollection[viewKey] as T;
    }
}
