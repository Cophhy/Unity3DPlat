using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
        //compara tag criada do objeto 
        if(collision.gameObject.CompareTag("EnemyBody")){
            Die();
        }

    }

    private void Die(){
        //desativamos ao inves de destruir o player para manter o ui de health
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMov>().enabled = false;

        Invoke(nameof(ReloadLevel), .7f);
    }

    private void ReloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
