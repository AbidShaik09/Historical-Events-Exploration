using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class VelocityTMPText : MonoBehaviour
    {
        public Rigidbody Chandrayaan;
        public TextMeshProUGUI velocityTMP;
        // Start is called before the first frame update
        void Start()
        {
            velocityTMP.text = "Velocity: ";
        }

        // Update is called once per frame
        void Update()
        {
            velocityTMP.text = "Velocity: "+(int)(Chandrayaan.velocity.y * 5000) + " Km/h";
        
        }
    }
}
