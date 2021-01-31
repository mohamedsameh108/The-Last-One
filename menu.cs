using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {
    public GameObject panel;
    public void game () {
        SceneManager.LoadScene (1);
        Cursor.visible = false;
    }
    public void credits () {
        SceneManager.LoadScene (2);
    }
    public void exit () {
        Application.Quit ();
    }
    public void mainMenu () {
        SceneManager.LoadScene (0);
    }
    public void Resume () {
        Cursor.visible = false;
        Time.timeScale = 1;
        panel.SetActive (false);
    }
}