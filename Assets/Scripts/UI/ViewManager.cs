using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    private static ViewManager s_instance;

    [SerializeField]
    private View[] _views;
    [SerializeField]
    private View _startingView;

    private View _currentView;
    private readonly Stack<View> _history = new Stack<View>();

    private void Awake() => s_instance = this;

    public T GetView<T>() where T : View => s_instance._views.FirstOrDefault(v => v is T) as T;

    public void ShowView<T>(bool remember = true) where T : View
    {
        var view = GetView<T>();
        if (view != null)
            ShowView(view);
        else
            Debug.Log("view was null");
    }
    public void ShowView(View view, bool remember = true)
    {
        if (s_instance._currentView != null)
        {
            if (remember)
            {
                s_instance._history.Push(view);
            }
            s_instance._currentView.Hide();
        }
        view.Show();

        s_instance._currentView = view;
    }

    public void ShowLast()
    {
        if(s_instance._history.Count != 0)
            s_instance.ShowView(s_instance._history.Pop(), false);
    }
}