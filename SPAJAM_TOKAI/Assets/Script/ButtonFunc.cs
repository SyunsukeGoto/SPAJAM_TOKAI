using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunc : MonoBehaviour
{
    public void PushHome()
    {
        SceneManager.LoadScene("UmbrellaMapScene");
    }

    public void PushMyPage()
    {
        SceneManager.LoadScene("TestMyProfileScene");
    }

    public void PushSignUp()
    {
        SceneManager.LoadScene("RegisterUmbrellaScene");
    }
}
