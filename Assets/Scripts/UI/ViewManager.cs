using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    private static ViewManager instance;

    [SerializeField] private View[] _views;
    [SerializeField] private View _startingView;

    private View _currentView;
    private readonly Stack<View> _history = new Stack<View>();

    private void Awake() => instance = this;

    public T GetView<T>() where T : View
    {
        for (int i = 0; i < instance._views.Length; i++)
        {
            if (instance._views[i] is T view)
            {
                return view;
            }
        }

        return null;
    }

    public void ShowView<T>(bool remember = true) where T : View
    {
        for (int i = 0; i < instance._views.Length; i++)
        {
            if (instance._views[i] is T view)
            {
                if (instance._currentView != null)
                {
                    if (remember)
                    {
                        instance._history.Push(view);
                    }
                    instance._currentView.Hide();
                }
                instance._views[i].Show();
                instance._currentView = instance._views[i];
            }
        }
    }
    public void ShowView(View view, bool remember = true)
    {
        if (instance._currentView != null)
        {
            if (remember)
            {
                instance._history.Push(view);
            }
            instance._currentView.Hide();
        }
        view.Show();

        instance._currentView = view;
    }

    public void ShowLast()
    {
        if(instance._history.Count != 0)
            instance.ShowView(instance._history.Pop(), false);
    }
}