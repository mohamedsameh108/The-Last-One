using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour {
    public GameObject panel;
    public GameObject b1;
    public GameObject b2;

    void Update () {
        if (Input.GetKey (KeyCode.Escape)) {
            Cursor.visible = true;
            Time.timeScale = 0;
            panel.SetActive (true);
            b1.SetActive (true);
            b2.SetActive (true);
        }
    }
    public void mainMenu () {
        SceneManager.LoadScene (0);
    }
    public void Resume () {
        Time.timeScale = 1;
        Cursor.visible = false;
        panel.SetActive (false);
        b1.SetActive (false);
        b2.SetActive (false);
    }
}