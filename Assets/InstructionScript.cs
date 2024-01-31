using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;

public class InstructionScript : MonoBehaviour
{
    public TextMeshProUGUI InstructionText;
    public AudioClip audioClip;
    public AudioSource audioSource;
    public AudioSource rocketSound;
    public Canvas InstructionCanvas;
    private string[] instructions = new string[] {
        "Welcome to the Chandrayaan-3 mission! You are about to embark on a journey to the moon, where you will help Chandrayaan-3 land safely on the lunar surface.",
        "You will be in charge of controlling the spacecraft's speed and rotation, and you will need to use your skills to make sure that Chandrayaan-3 lands safely.",
        "As you begin your mission, you will find yourself in the cockpit of the spacecraft, with the Earth slowly receding in the distance.",
        "You will need to use the buttons on your screen to control the spacecraft's speed and rotation, and to make sure that it lands safely on the moon.",
        "But be careful! Chandrayaan-3 is a delicate spacecraft, and it can only withstand so much stress. If you rotate it too fast or land with too much velocity, it will crash and your mission will be over.",
        "Are you ready to take on the challenge?"
    };
    private void Start()
    {

        audioSource.clip = audioClip;
        
        Time.timeScale = 0;
        current = 0;
        InstructionText.text = instructions[current];
        rocketSound.Stop();
        
            
    }
    public int current = 0;
    public void NextInstruction()
    {

        audioSource.Play();
        current++;
        if(current >= instructions.Length)
        {
            Time.timeScale= 1;
            rocketSound.Play();
            InstructionCanvas.enabled = false;  

        }
        else
        {
            InstructionText.text = instructions[current];
        }

    }

}
