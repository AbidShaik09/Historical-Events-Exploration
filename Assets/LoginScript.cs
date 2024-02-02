using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{
    public TMP_InputField usernameField;
    public static string accessToken;
    public TMP_InputField passwordField;
    public GameObject Form;
    public string url = "http://arheewebapi.somee.com/Auth/login";
    public TextMeshProUGUI output;
    void Start()

    {
        if (PlayerPrefs.GetString("accessToken") != null && PlayerPrefs.GetString("accessToken") != "")
        {

            output.text = "Loading...";
            Form.active = false;
            GetData(PlayerPrefs.GetString("accessToken"));
            Debug.Log("Login Successful");
        }
        else
        {
            output.text = "";
            Form.active = true;
            output = GameObject.Find("outputText").GetComponent<TextMeshProUGUI>();
            GameObject.Find("LoginButton").GetComponent<Button>().onClick.AddListener(GetData);

        }

    }



    public async void GetData()
    {
        StartCoroutine(GetAccessToken());

    }
    public async void GetData(string token)
    {
        StartCoroutine(GetDataFromAPI(token));

    }


    IEnumerator GetDataFromAPI(string token)
    {
        string newrl = "http://arheewebapi.somee.com/Auth/Details";
        UnityWebRequest uwr = UnityWebRequest.Get(newrl + "?accessToken=" + UnityWebRequest.EscapeURL(token));
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
        {
            output.text = "Failed" + uwr.downloadHandler.text;

            
            Form.active = true;

        }
        else
        {
            var jsonData = uwr.downloadHandler.text;
            UserData dict = JsonUtility.FromJson<UserData>(jsonData);

            PlayerPrefs.SetString("username", dict.username);
            PlayerPrefs.SetString("email", dict.email);
            PlayerPrefs.SetInt("age", dict.age);
            PlayerPrefs.SetString("gender", dict.gender);
            

            PlayerPrefs.Save();

            Debug.Log("Recieved Data From API Welcome " + PlayerPrefs.GetString("username") + " !");
            SceneManager.LoadScene("Menu");

        }

    }


    

    IEnumerator GetAccessToken()
    {
        string username = usernameField.text;  // Replace with your actual username
        string password = passwordField.text;  // Replace with your actual password

        output.text = "Logging you in...";
        UnityWebRequest uwr = UnityWebRequest.Get(url + "?username=" + username + "&password=" + password);
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            output.text = uwr.downloadHandler.text;
        }
        else
        {
            accessToken = uwr.downloadHandler.text;
            PlayerPrefs.SetString("accessToken",accessToken);
            output.text = "Login Successful\nGathering Your Details..." ;
            StartCoroutine(GetDataFromAPI(accessToken));
        }
    }

    [System.Serializable]
    public class UserData
    {
        public int id;
        public string username;
        public string password;
        public string email;
        public int age;
        public string gender;
    }



    public void ReloadSceneLogin()
    {
        PlayerPrefs.SetString("accessToken","");
        PlayerPrefs.SetString("username","");
        PlayerPrefs.SetString("email", "");
        PlayerPrefs.SetString("age", "");
        PlayerPrefs.SetString("gender", "");
        PlayerPrefs.Save();
        SceneManager.LoadScene("Login");
    }
    public void ReloadSceneRegister()
    {
        PlayerPrefs.SetString("accessToken", "");
        PlayerPrefs.SetString("username", "");
        PlayerPrefs.SetString("email", "");
        PlayerPrefs.SetString("age", "");
        PlayerPrefs.SetString("gender", "");
        PlayerPrefs.Save();
        SceneManager.LoadScene("Register");
    }
}

