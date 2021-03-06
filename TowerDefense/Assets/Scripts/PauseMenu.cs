﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public GameObject ui;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.P)) {
			Toggle ();
		}
	}

	public void Restart(){
		Toggle ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void Menu(){
		Debug.Log ("Go to menu");
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}

	public void Toggle(){
		ui.SetActive (!ui.activeSelf);

		if (ui.activeSelf) {
			Time.timeScale = 0f;
		} else {
			Time.timeScale = 1f;
		}
	}


}
