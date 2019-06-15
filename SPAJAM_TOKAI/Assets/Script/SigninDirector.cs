using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class SigninDirector : MonoBehaviour
{
    [SerializeField]
    private Text userName;

    [SerializeField]
    private Text userPass;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Signin()
    {
        //NCMBUserのインスタンス作成 
        NCMBUser user = new NCMBUser();

        //ユーザ名とパスワードの設定
        user.UserName = userName.text;
        user.Password = userPass.text;

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
