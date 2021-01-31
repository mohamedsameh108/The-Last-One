using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour {
    public CharacterController playerControl;
    public Camera rotat;
    public float playerSpeed = 0.2f;
    public float playerSprint = 0.4f;
    public float playerDuck = 0.1f;
    public float playerJumpForce = 1f;
    public float playerGravity = -0.5f;
    public float playerJumpTimer = 0.07f;
    public bool playerJumping = false;

    //Current state of some of the stats defined above.
    private float actPlayerGravity;
    private float actPlayerSpeed;

    private bool groundCheckOn = true;

    private Vector3 playerMotionVector;

    private void ApplyGravity () {
        playerControl.Move (new Vector3 (0, actPlayerGravity, 0));
    }

    private void GetInput () {
        //Get input from WASD keys.
        playerMotionVector = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
        playerMotionVector = rotat.transform.TransformDirection (playerMotionVector);

        //LeftCtrl to sprint. LeftShift to crouch.
        if (Input.GetAxis ("Sprint") != 0) {
            actPlayerSpeed = playerSprint;
        }
        if (Input.GetAxis ("Duck") != 0) {
            actPlayerSpeed = playerDuck;
        }
        if (Input.GetAxis ("Sprint") == 0 && Input.GetAxis ("Duck") == 0) {
            actPlayerSpeed = playerSpeed;
        }
    }

    private void Movement () {
        playerControl.Move (playerMotionVector * actPlayerSpeed);

        if (Input.GetAxis ("Jump") != 0 && playerJumping == false) {
            StartCoroutine ("JumpMove");
        }
    }

    private IEnumerator JumpMove () {
        //This is probably more complicated than it needs to be... But I didn't know how else to make it jump in a smooth arc.
        groundCheckOn = false;
        playerJumping = true;
        actPlayerGravity = playerJumpForce;
        yield return new WaitForSeconds (playerJumpTimer);
        actPlayerGravity = playerJumpForce / 2;
        yield return new WaitForSeconds (playerJumpTimer);
        actPlayerGravity = 0;
        yield return new WaitForSeconds (playerJumpTimer);
        actPlayerGravity = playerGravity / 2;
        yield return new WaitForSeconds (playerJumpTimer);
        actPlayerGravity = playerGravity;
        groundCheckOn = true;
    }

    private IEnumerator GroundCheck () {
        //I need a variable to check if I can check if I can jump. Lol.
        if (groundCheckOn == true) {
            if (playerControl.isGrounded) {
                yield return new WaitForSeconds (playerJumpTimer * 2);
                playerJumping = false;
                yield break;
            }
            if (!playerControl.isGrounded) {
                playerJumping = true;
                yield break;
            }
        }
    }

    private void Start () {
        actPlayerGravity = playerGravity;
        actPlayerSpeed = playerSpeed;
    }

    private void Update () {
        ApplyGravity ();
        GetInput ();
        StartCoroutine ("GroundCheck");
        Movement ();
    }
}