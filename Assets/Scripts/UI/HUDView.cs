using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDView : View
{
    [SerializeField]
    private Button menuButton;
    
    public override void Init()
    {
        menuButton.onClick.AddListener(() =>
        {
            ViewManager.ShowView<MainMenuView>();
        });
    }
}
