using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProfileHandlerScript : MonoBehaviour
{
    public TextMeshProUGUI username;
    public TextMeshProUGUI email;
    public TextMeshProUGUI age;
    public TextMeshProUGUI gender;
    private void Start()

    {
        username.text+=": "+ PlayerPrefs.GetString("username");
        email.text += ": " + PlayerPrefs.GetString("email");
        age.text += ": " + PlayerPrefs.GetInt("age");
        gender.text += ": " + PlayerPrefs.GetString("gender");

    }

    public void BackBtton()
    {
        SceneManager.LoadScene("Menu");
    }


    
}
