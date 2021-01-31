using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkit1 : MonoBehaviour {
    bool inTrigger;
    public GameObject kit;
    public GameObject kittext;
    public GameObject player;
    private void OnTriggerEnter (Collider other) {
        inTrigger = true;
        kittext.SetActive (true);
    }
    private void OnTriggerExit (Collider other) {
        inTrigger = false;
        kittext.SetActive (false);
    }
    public void Update () {
        if (inTrigger) {
            if (Input.GetKey ("t")) {
                itemsList item = player.GetComponent<itemsList> ();
                item.items.Add (kit);
                kittext.SetActive (false);
                kit.SetActive (false);
            }
        }
    }
}