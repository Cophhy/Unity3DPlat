using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    Rigidbody rb;
    public float movSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform groundCheck; 
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        //pegando o componente Rigidbody para fazer o objeto se mover
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //lidando com entradas negativas e positivas
        float horizontalInput = Input.GetAxis("Horizontal");//var local
        float verticalInput = Input.GetAxis("Vertical");
        //bom para joystic para slower mov
        rb.velocity = new Vector3(horizontalInput * movSpeed, rb.velocity.y, verticalInput * movSpeed);
        
        if(Input.GetButton("Jump") && IsGrounded()){
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    //metodo para saber se o personagem esta tocando o chao
    bool IsGrounded(){
        //criar uma esfera para saber se esta tocando o chao ou se tem algo dentro da area
        //os parametros sao (posicao que quero a esfera, qual o tamanho da esfera, layermask)
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
