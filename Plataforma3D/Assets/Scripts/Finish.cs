using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Player"){
            //terminar esse level e ir para o proximo
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
}
