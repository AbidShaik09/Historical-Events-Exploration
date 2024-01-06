using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AngularVelocityTMP : MonoBehaviour
{
    public Rigidbody Chandrayaan;
    public TextMeshProUGUI angularVelocityTMP;
    // Start is called before the first frame update
    void Start()
    {
        angularVelocityTMP.text = "Angular Velocity";
    }

    // Update is called once per frame
    void Update()
    {
        angularVelocityTMP.text = "Angular Velocity: "+ ((int)(Chandrayaan.angularVelocity.y * 1000)) +" RPM";
    }
}
