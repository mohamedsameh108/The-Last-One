using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public float RotationSensitivity = 35.0f;
    public float minAngle = -90.0f;
    public float maxAngle = 90.0f;
    //Rotation Value
    float yRotate = 0.0f;
    float xRotate = 0.0f;
    void Start () {
    }
    // Update is called once per frame
    void Update () {

        yRotate += Input.GetAxis("Mouse X") * RotationSensitivity * Time.deltaTime;
        xRotate -= Input.GetAxis("Mouse Y") * RotationSensitivity * Time.deltaTime;
        xRotate = Mathf.Clamp (xRotate, minAngle, maxAngle);
        transform.eulerAngles = new Vector3 (xRotate, yRotate, 0.0f);

    }
}