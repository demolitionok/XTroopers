using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : View
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button settingsButton;
    [SerializeField]
    private Button exitButton;
    
    public override void Initialize()
    {
        startButton.onClick.AddListener(ViewManager.HideCurrentView);
        settingsButton.onClick.AddListener(() =>
        {
            ViewManager.ShowView<SettingsView>();
        });
        exitButton.onClick.AddListener(Application.Quit);
    }
}
