using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credit : MonoBehaviour {
    public void samehFB () {
        Application.OpenURL ("https://www.facebook.com/m7mds2me7/");
    }
    public void samehIN () {
        Application.OpenURL ("https://www.linkedin.com/in/mohamedsameh18/");
    }
    public void gabrFB () {
        Application.OpenURL ("https://www.facebook.com/ahmed.gabr.9250595/");
    }
    public void gabrIN () {
        Application.OpenURL ("https://www.linkedin.com/in/axment-gabr-92426b1b1/");
    }
    public void back () {
        SceneManager.LoadScene (0);
    }
}