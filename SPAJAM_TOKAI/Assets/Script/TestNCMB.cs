using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class TestNCMB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Signin();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Login();
        }
    }

    public void Login()
    {
        string UserName = "makoto";
        string PassWord = "pass";

        //NCMBUserのインスタンス作成 
        NCMBUser user = new NCMBUser();

        // ユーザー名とパスワードでログイン
        NCMBUser.LogInAsync(UserName, PassWord, (NCMBException e) => {
            if (e != null)
            {
                UnityEngine.Debug.Log("ログインに失敗: " + e.ErrorMessage);
            }
            else
            {
                UnityEngine.Debug.Log("ログインに成功！");
            }
        });

    }

    public void Signin()
    {
        string UserName = "makoto";
        string PassWord = "pass";


        //NCMBUserのインスタンス作成 
        NCMBUser user = new NCMBUser();

        //ユーザ名とパスワードの設定
        user.UserName = UserName;
        user.Password = PassWord;

        //会員登録を行う
        user.SignUpAsync((NCMBException e) => {
            if (e != null)
            {
                UnityEngine.Debug.Log("新規登録に失敗: " + e.ErrorMessage);
            }
            else
            {
                UnityEngine.Debug.Log("新規登録に成功");
            }
        });

    }
}
