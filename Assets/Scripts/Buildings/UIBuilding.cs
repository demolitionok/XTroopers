using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIBuilding : MonoBehaviour
{
    [SerializeField]
    private View viewToShow;
    
    public void OnMouseDown()
    {
        ViewManager.ShowView(viewToShow);
    }
}
