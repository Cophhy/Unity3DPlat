using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    Rigidbody rb;
    public float movSpeed = 5f;
    [SerializeField] float jumpForce = 5f;

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
        
        if(Input.GetButton("Jump")){
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

    }
}
