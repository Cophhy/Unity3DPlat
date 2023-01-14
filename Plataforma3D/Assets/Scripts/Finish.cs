using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Player"){
            //terminar esse level e ir para o proximo
            
        }
    }
}
