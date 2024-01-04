using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChandrayanRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody Chandrayan;
    public Vector3 rot = new Vector3(0.0f, 1.0f, 0.0f);
    void Start()
    {
        Chandrayan = GetComponent<Rigidbody>();
        
        Chandrayan.AddTorque(rot);

        Chandrayan.angularVelocity = rot;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
