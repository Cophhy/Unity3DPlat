using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPlataform : MonoBehaviour
{
    //verificar a colisao do player com a plataforma 
    private void OnCollisionEnter(Collision collision){
        //comparador com o nome do objeto 
        if(collision.gameObject.name == "Player"){
            //se true queremos que o player seja child da plataforma 
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision){
            if(collision.gameObject.name == "Player"){
            //se true queremos que o player seja child da plataforma 
            collision.gameObject.transform.SetParent(null);
        }
    }
}
