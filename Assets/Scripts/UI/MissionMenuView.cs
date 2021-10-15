using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MissionMenuView : View
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button backButton;
    
    public override void Initialize()
    {
        startButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Scenes/game");
        });
        backButton.onClick.AddListener(ViewManager.ShowLast);
    }
}
