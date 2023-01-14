using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    bool dead = false;
    [SerializeField] AudioSource deadSound;


    private void Update(){
        if(transform.position.y <-1f && !dead ){
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision){
        //compara tag criada do objeto 
        if(collision.gameObject.CompareTag("EnemyBody")){
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMov>().enabled = false;
            Die();
        }

    }

    private void Die(){
        //desativamos ao inves de destruir o player para manter o ui de health

        dead = true;
        Invoke(nameof(ReloadLevel), .7f);
        deadSound.Play();
    }

    private void ReloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
