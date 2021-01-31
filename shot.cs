using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shot : MonoBehaviour {
    public float range = 100.0f;
    public Camera cam;
    public int Cure = 100;
    public TextMeshProUGUI cure_shower;
    public GameObject Die;

    void Update () {
        if (Input.GetKey (KeyCode.Mouse0) && Cure > 0) {
            shoot ();
        }
        cure_shower.text = Cure.ToString ();
        if (Cure == 10) {
            Die.SetActive (true);
            StartCoroutine (restart ());
        }
    }
    void shoot () {
        RaycastHit hit;
        if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, range)) {
            Cure--;
            Target target = hit.transform.GetComponent<Target> ();
            if (target != null) {
                target.damage ();
            }
        }
    }
    IEnumerator restart () {
        yield return new WaitForSeconds (2);
        SceneManager.LoadScene (3);
    }
}