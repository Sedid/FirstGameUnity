using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ActivationMenu : MonoBehaviour {
	
	public GameObject settings;
	
	public void StartGame ()
	{
        SceneManager.LoadScene("SceneBase");
	}
	public void Settings ()
	{
		settings.SetActive(!settings.activeSelf);
	}
	public void ExitGame ()
	{
		Application.Quit();
	}
}

