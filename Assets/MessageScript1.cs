using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageScript1 : MonoBehaviour
{
    public Rigidbody Chandrayaan;
    public string velocity;
    public TextMeshProUGUI MessageTMPt;
    public BoxCollider ChandrayaanBox;
    

    // Start is called before the first frame update
    void Start()
    {
        MessageTMPt.text = "Rotating Too Fast!\r\nVelocity Too High!";
        ChandrayaanBox = Chandrayaan.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Math.Abs((int)(Chandrayaan.velocity.y * 5000))>200)
        {
            velocity = "Velocity Too High!";
            MessageTMPt.color = Color.red;
        }
        else if (Math.Abs((int)(Chandrayaan.velocity.y * 5000)) >= 100)
        {
            velocity = "Velocity High!";
            MessageTMPt.color = Color.HSVToRGB(1f, 2f, 0);
        }
        else
        {
            velocity = "Optimum Velocity!";
            MessageTMPt.color = Color.green;

        }
        
        MessageTMPt.text = velocity;
    }
}
