using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildMenuOpen : MonoBehaviour
{
    public GameObject buildMenu;

    void OnMouseDown()
    {
        buildMenu.SetActive(true); 
    }

}
