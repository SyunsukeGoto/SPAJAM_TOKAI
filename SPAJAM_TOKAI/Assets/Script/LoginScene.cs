using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;
using UnityEngine.SceneManagement;

public class LoginScene : MonoBehaviour
{
    [SerializeField]
    private Text userName;

    [SerializeField]
    private Text userPass;

    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        //NCMBUserのインスタンス作成 
        NCMBUser user = new NCMBUser();

        // ユーザー名とパスワードでログイン
        NCMBUser.LogInAsync(userName.text, userPass.text, (NCMBException e) => {
            if (e != null)
            {
                UnityEngine.Debug.Log("ログインに失敗: " + e.ErrorMessage);
                canvas.SetActive(true);
                text.text = e.ErrorMessage;
            }
            else
            {
                UnityEngine.Debug.Log("ログインに成功！");
                SceneManager.LoadScene("UserProfileScene");
            }
        });
    }

    public void Error()
    {
        canvas.SetActive(false);
    }
}
