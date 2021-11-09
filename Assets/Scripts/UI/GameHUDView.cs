using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHUDView : View
{
    [SerializeField]
    private Button menuButton;
    
    public override void Init()
    {
        menuButton.onClick.AddListener(() =>
        {
            ViewManager.ShowView<MissionMenuView>();
            SceneManager.LoadScene("Scenes/home-base");
        });
    }
}
