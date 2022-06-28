using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour
{
	public void OpenTutorialScene()
	{
		SceneManager.LoadScene("TutorialScene");
	}

	public void StartGame()
	{

	}

	public void OpenOptions()
	{

	}

	public void CloseApplication()
	{
		Application.Quit();
	}
}
