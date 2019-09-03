using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Goto;

public class ButtonFunc : MonoBehaviour
{
    UpDateLotAndLong _returnPos;

    void Start()
    {
        _returnPos = GameObject.Find("LotAndLongManager").GetComponent<UpDateLotAndLong>();
    }
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

    public void PushBorrow()
    {
        SceneManager.LoadScene("BorrowScene");
    }

    public void PushReturn()
    {
        _returnPos.UpDateDate();
    }
}
