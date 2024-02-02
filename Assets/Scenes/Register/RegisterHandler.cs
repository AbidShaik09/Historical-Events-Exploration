using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using static LoginScript;

public class RegisterHandler : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public TMP_InputField email;
    public TMP_InputField age;
    public TMP_InputField gender;
    public TextMeshProUGUI output;


    public void Back()
    {
        SceneManager.LoadScene("Login");
    }
    public async void Register()
    {
        UserDetails user= new UserDetails();
        user.id = 0;
        user.username=username.text;
        user.password=password.text;
        user.email=email.text;
        user.age= Int32.Parse( age.text);
        user.gender=gender.text;
        StartCoroutine(RegisterUser(user));
        
    }

     
    IEnumerator RegisterUser(UserDetails user)
    {
        string url = "http://arheewebapi.somee.com/Auth/Register";
        var jsonData = JsonUtility.ToJson(user);

        UnityWebRequest uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.Success)
        {

            Debug.Log("User Registered");

            Debug.Log("Results: "+ uwr.result);
            output.text = "Successfully Registered\n Please login";
        }
        else
        {



            Debug.Log(uwr.result);
            Debug.Log(jsonData);
            output.text = (uwr.downloadHandler.text);
        }
    }
    private class UserDetails
    {
        public int id;
        public string username;
        public string password;
        public string email;
        public int age;
        public string gender;
    }

}
