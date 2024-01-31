using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageScript : MonoBehaviour
{
    public Rigidbody Chandrayaan;
    public TextMeshProUGUI MessageTMP;
    public string rotation = "";
    public string velocity = "";

    // Start is called before the first frame update
    void Start()
    {
        MessageTMP.text = "Rotating Too Fast!\r\nVelocity Too High!";
    }

    // Update is called once per frame
    void Update()
    {

        if (Math.Abs((int)(Chandrayaan.angularVelocity.y * 1000)) > 300)
        {
            rotation = "Rotating Too Fast!";
            MessageTMP.color = Color.red;
        }
        else if (Math.Abs((int)(Chandrayaan.angularVelocity.y * 1000)) > 150)
        {
            rotation = "Rotating Fast!";
            MessageTMP.color = Color.HSVToRGB(0.6f, 0, 0);
        }
        else
        {
            rotation = "Perfect Angular Velocity!";
            MessageTMP.color = Color.green;

        }




        /*if ((int)(Chandrayaan.velocity.y * 5000) > 100)
        {
            velocity = "Velocity Too High!";
            MessageTMP.color = Color.red;
        }
        else if ((int)(Chandrayaan.velocity.y * 5000) > 50)
        {
            velocity = "Velocity High!";
            MessageTMP.color = Color.HSVToRGB(0.6f, 0, 0);
        }
        else
        {
            velocity = "Optimum Velocity!";
            MessageTMP.color = Color.green;

        }*/
        
        MessageTMP.text = rotation;
    }
}
