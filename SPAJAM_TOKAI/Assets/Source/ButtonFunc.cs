using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunc : MonoBehaviour
{
    //ホームに行く
    public void HomeScene()
    {
        SceneManager.LoadScene("Home");
    }

    public void MyPageScene()
    {
        SceneManager.LoadScene("MyPage");
    }

    public void FindUmbrellaScene()
    {
        SceneManager.LoadScene("FindUmbrella");
    }

    public void TalkScene()
    {
        SceneManager.LoadScene("Talk");
    }
}
