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
    private GameObject Canvas;
    [SerializeField]
    private View[] _views;
    [SerializeField]
    private View _startingView;

    private View _currentView;
    private readonly Stack<View> _history = new Stack<View>();

    private void Awake() => s_instance = this;

    private void Start()
    {
        DontDestroyOnLoad(Canvas);
        
        foreach (var view in _views)
        {
            view.Initialize();
            view.Hide();
        }

        if (_startingView != null)
        {
            ShowView(_startingView);
        }
    }

    public static T GetView<T>() where T : View => s_instance._views.FirstOrDefault(v => v is T) as T;
    
    public static void ShowView<T>(bool remember = true) where T : View
    {
        var view = GetView<T>();
        if (view != null)
            ShowView(view);
        else
            Debug.Log("view was null");
    }
    public static void ShowView(View view, bool remember = true)
    {
        if (s_instance._currentView != null)
        {
            if (remember)
            {
                s_instance._history.Push(s_instance._currentView);
            }
            s_instance._currentView.Hide();
        }
        
        if(view != null)
            view.Show();
        
        s_instance._currentView = view;
    }

    public static void HideCurrentView() => ShowView(null, false);

    public static void ShowLast()
    {
        if(s_instance._history.Count != 0)
            ShowView(s_instance._history.Pop(), false);
    }
}