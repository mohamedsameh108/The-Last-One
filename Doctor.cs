using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doctor : MonoBehaviour {
    public GameObject mango;
    bool inTrigger, flag = false;
    public GameObject text;
    public GameObject end;
    public GameObject player;
    public Animation anim;
    Transform target;
    AudioSource audio;
    public AudioClip clip;
    private void OnTriggerEnter (Collider other) {
        inTrigger = true;
        text.SetActive (true);
    }
    private void OnTriggerExit (Collider other) {
        inTrigger = false;
        text.SetActive (false);
    }
    public void Start () {
        anim = GetComponent<Animation> ();
        target = playerManager.instance.player.transform;
        audio = GetComponent<AudioSource> ();
    }
    public void Update () {
        shot cure = player.GetComponent<shot> ();
        if (inTrigger) {
            if (Input.GetKeyDown ("g") && cure.Cure > 10) {
                cure.Cure -= 10;
                DestroyAllObjects ();
                anim.Play ("wake");
                Destroy (text);
                StartCoroutine (restart ());
            }
        }
        if (flag == true) {
            FaceTarget ();
        }
    }
    void FaceTarget () {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation (new Vector3 (direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    void DestroyAllObjects () {
        Destroy (mango);
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("enemy");
        for (int i = 0; i < gameObjects.Length; i++) {
            Destroy (gameObjects[i]);
        }
    }
    IEnumerator restart () {
        yield return new WaitForSeconds (7);
        flag = true;
        anim.Play ("talk");
        audio.clip = clip;
        audio.Play ();
        yield return new WaitForSeconds (8);
        end.SetActive (true);
        yield return new WaitForSeconds (2);
        Cursor.visible = true;
        Initiate.Fade ("Scenes/credits", Color.black, 0.5f);
    }
}