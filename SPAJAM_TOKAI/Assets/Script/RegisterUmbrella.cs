using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class RegisterUmbrella : MonoBehaviour
{
    [SerializeField]
    private Text nameText;

    [SerializeField]
    private Text addressText;

    [SerializeField]
    private Text telText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Register()
    {
        // クラスのNCMBObjectを作成
        NCMBObject testClass = new NCMBObject("Umbrella");

        // オブジェクトに値を設定
        testClass["IsBorrow"] = false;
        testClass["LenderID"] = NCMBUser.CurrentUser.ObjectId;

        // データストアへの登録
        testClass.SaveAsync();

        StartCoroutine(GetID(testClass, NCMBUser.CurrentUser));
    }

    IEnumerator GetID(NCMBObject a, NCMBUser user)
    {
        while (a.ObjectId == null)
        {
            yield return new WaitForSeconds(0.1f);
        }
        
        //成功時の処理
        user["LendUmbrellaID"] = a.ObjectId;
        Debug.Log(a.ObjectId);
        user.SaveAsync();
    }
}
