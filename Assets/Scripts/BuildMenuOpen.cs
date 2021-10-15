using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildMenuOpen : MonoBehaviour
{
    public GameObject buildMenu;
    private MenuController gameMenu;
    private bool menuIsOpen;

    void Start()
    {
        gameMenu = GameObject.Find("Menu").GetComponent<MenuController>();
    }

    void OnMouseDown()
    {
        menuIsOpen = gameMenu.MenuIsOpen();
        if (menuIsOpen == false)
        {
            buildMenu.SetActive(true);
        } 
    }

}
