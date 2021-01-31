using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lab : MonoBehaviour {
    bool inTrigger;
    public GameObject text;
    public GameObject text1;
    public GameObject canvas;
    public GameObject player;
    private void OnTriggerEnter (Collider other) {
        inTrigger = true;
        canvas.SetActive (true);
    }
    private void OnTriggerExit (Collider other) {
        inTrigger = false;
        text.SetActive (false);
        text1.SetActive (false);
        canvas.SetActive (false);
    }
    public void Update () {
        if (inTrigger) {
            itemsList item = player.GetComponent<itemsList> ();
            if (item.items.Count < 5) {
                text.SetActive (true);
            } else if (item.items.Count == 5) {
                text1.SetActive (true);
            }
            if (item.items.Count == 5 && Input.GetKey ("o")) {
                text1.SetActive (false);
                Cursor.visible = false;
                Initiate.Fade ("DreamForestTree/DemoScene", Color.black, 0.5f);
            }
        }
    }
}