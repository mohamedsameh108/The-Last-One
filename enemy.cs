using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour {
    public float lookRadius = 100f;
    Transform target;
    NavMeshAgent agent;
    public GameObject player;
    public GameObject Die;
    void Start () {
        target = playerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent> ();
    }

    void Update () {
        float distance = Vector3.Distance (target.position, transform.position);
        if (distance <= lookRadius) {
            agent.SetDestination (target.position);
        }
        if (distance <= agent.stoppingDistance) {
            Die.SetActive (true);
            StartCoroutine (restart ());
        }
    }
    private void OnDrawGizmosSelected () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, lookRadius);
    }
    IEnumerator restart () {
        yield return new WaitForSeconds (2);
        SceneManager.LoadScene (3);
    }
}