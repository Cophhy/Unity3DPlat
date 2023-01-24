using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints; //array de gameobjects 
    int currentWaypointIndex = 0 ;
    [SerializeField] float speed = 1f;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //checar qual waypoint temos que usar 
        //checa quao longe estamos do current waypoint 
        //se tocamos trocamos para o proximo
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f){
            currentWaypointIndex++;
            animator.SetBool("Back", false);
            if(currentWaypointIndex >= waypoints.Length){
                //checar se esta no ultimo waypoint
                currentWaypointIndex = 0;
                animator.SetBool("Back", true);

            }
        }
        //posicao do opbjeto que possui o script
        //Move Towards calcula uma nova posicao 
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
        
    }
}
