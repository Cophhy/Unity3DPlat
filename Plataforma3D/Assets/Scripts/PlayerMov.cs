 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    Rigidbody rb;
    public float movSpeed = 5f;
    public float bounce = 9f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform groundCheck; 
    [SerializeField] LayerMask ground;
    public Animator animator;

    [SerializeField] AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        //pegando o componente Rigidbody para fazer o objeto se mover
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //lidando com entradas negativas e positivas
        float horizontalInput = Input.GetAxis("Horizontal");//var local
        float verticalInput = Input.GetAxis("Vertical");
        //bom para joystic para slower mov
        rb.velocity = new Vector3(horizontalInput * movSpeed, rb.velocity.y, verticalInput * movSpeed);
       
       if(verticalInput>0.01){
             animator.SetFloat("verticalInput", verticalInput);
        }

        if(horizontalInput>0.01){
             animator.SetBool("horizontalInput", true);
        }

        if(Input.GetButton("Jump") && IsGrounded()){
            Jump();
        }else{
            animator.SetBool("JumpAnim", false);
        }        
    }

    private void Jump(){
         rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
         jumpSound.Play();
         animator.SetBool("JumpAnim", true);
    }
    
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("EnemyHead")){
            //destroi os parentes do objeto tmb nao so a box d cima
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
        if(collision.gameObject.CompareTag("Trampoline")){
            rb.velocity = new Vector3(rb.velocity.x, bounce, rb.velocity.z);
         jumpSound.Play();
        }
    }

   
    //metodo para saber se o personagem esta tocando o chao
    bool IsGrounded(){
        //criar uma esfera para saber se esta tocando o chao ou se tem algo dentro da area
        //os parametros sao (posicao que quero a esfera, qual o tamanho da esfera, layermask)
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
