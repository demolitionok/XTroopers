using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuTest : MonoBehaviour
{
    public void BeginGame()
	{
		SceneManager.LoadScene("game");
	}

    public void Return()
	{
        GameObject objParrent = this.transform.parent.gameObject;
		objParrent.SetActive(false);
	}

	public void Settings()
	{
		SceneManager.LoadScene("settings");
	}
}
