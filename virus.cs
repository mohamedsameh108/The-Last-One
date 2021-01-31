using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virus : MonoBehaviour {
    public GameObject virusMango;
    void Start () {
        StartCoroutine (add ());
    }

    IEnumerator add () {
        for (int i = 0; i < 88; i++) {
            yield return new WaitForSeconds (10);
            addVirus ();
        }
    }
    public void addVirus () {
        GameObject duplicate = Instantiate (virusMango);
        duplicate.SetActive (true);
    }
}