using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectForwards : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    public float m_Speed = 5.0f;
    public float m_UpSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
    }

    // Update is called once per frame
    void FixedUpdate()
    {
//Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
        m_Rigidbody.velocity = transform.forward * m_Speed;
        //m_Rigidbody.AddForce(transform.up * m_UpSpeed);

    }
}
