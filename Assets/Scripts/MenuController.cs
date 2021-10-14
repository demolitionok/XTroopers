using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	private bool menuOpen = true;
	private int heroCount;
	[SerializeField] private bool isBase = true;
	[SerializeField] private GameObject MainMenu;
	[SerializeField] private GameObject Hud;
	[SerializeField] private GameObject MissionMenu;
	[SerializeField] private GameObject StoreMenu;
	[SerializeField] private GameObject UnitMenu;
	[SerializeField] private GameObject ClinicMenu;

	void Start()
	{
		if(isBase)
		{
			Hud.SetActive(false);
			MainMenu.SetActive(true);
			MissionMenu.SetActive(false);
			StoreMenu.SetActive(false);
			UnitMenu.SetActive(false);
			ClinicMenu.SetActive(false);
		}
	}

	public void OpenMenu()
	{
		if (menuOpen == false)
		{
			menuOpen = true;
			Hud.SetActive(false);
			MainMenu.SetActive(true);
			MissionMenu.SetActive(false);
			StoreMenu.SetActive(false);
			UnitMenu.SetActive(false);
			ClinicMenu.SetActive(false);
		}
	}

	public void CloseMenu()
	{
		if (menuOpen == true)
		{
			menuOpen = false;
			Hud.SetActive(true);
			MainMenu.SetActive(false);
			MissionMenu.SetActive(false);
			StoreMenu.SetActive(false);
			UnitMenu.SetActive(false);
			ClinicMenu.SetActive(false);
		}
	}

	public bool MenuIsOpen()
	{
		return menuOpen;
	}

    public void BeginGame()
	{
		SceneManager.LoadScene("game");
	}

    public void Return()
	{
        GameObject objParrent = this.transform.parent.gameObject;
		objParrent.SetActive(false);
	}

	public void ReturnToBase()
	{
        SceneManager.LoadScene("home-base");
	}

	public void Exit()
	{
		Application.Quit();
	}
}
