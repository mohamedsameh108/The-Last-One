using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemsList : MonoBehaviour {
    public RawImage medkit1s;
    public RawImage medkit2s;
    public RawImage microscopes;
    public RawImage capsuless;
    public RawImage syringes;
    public Texture newSprite;
    public Texture curSprite;
    public List<GameObject> items = new List<GameObject> ();
    public GameObject panel;
    public GameObject medkit1;
    public GameObject medkit2;
    public GameObject microscope;
    public GameObject capsules;
    public GameObject syringe;
    public void Update () {
        if (Input.GetKey (KeyCode.Escape)) {
            Cursor.visible = true;
            Time.timeScale = 0;
            panel.SetActive (true);
            if (items.Contains (medkit1)) {
                medkit1s.texture = newSprite;
            } else {
                medkit1s.texture = curSprite;
            }
            if (items.Contains (medkit2)) {
                medkit2s.texture = newSprite;
            } else {
                medkit2s.texture = curSprite;
            }
            if (items.Contains (microscope)) {
                microscopes.texture = newSprite;
            } else {
                microscopes.texture = curSprite;
            }
            if (items.Contains (capsules)) {
                capsuless.texture = newSprite;
            } else {
                capsuless.texture = curSprite;
            }
            if (items.Contains (syringe)) {
                syringes.texture = newSprite;
            } else {
                syringes.texture = curSprite;
            }
        }
    }
}