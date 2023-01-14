using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]float speedX;
    [SerializeField]float speedY;
    [SerializeField]float speedZ;



    // Update is called once per frame
    void Update()
    {
        //rotacao 360 com a velocidade dada
        transform.Rotate(360 * speedX * Time.deltaTime,360 * speedY * Time.deltaTime,360 * speedZ * Time.deltaTime);
    }
}
