using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreView : View
{
    [SerializeField]
    private Button backButton;
    
    public override void Init()
    {
        backButton.onClick.AddListener(ViewManager.ShowLast);
    }
}
