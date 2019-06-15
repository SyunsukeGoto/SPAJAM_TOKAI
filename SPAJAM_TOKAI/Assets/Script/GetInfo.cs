using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;
using System.Linq;

public class GetInfo : MonoBehaviour
{
    // 取得したデータ表示用のテキストへの参照保存用
    private Text _outputText;

    // NCMBを利用するためのクラス
    private NCMBQuery<NCMBObject> _query;

    // データを最大何個取得するか
    private const int MAX = 1;

    void Start()
    {
        _outputText = GetComponent<Text>();

        // テキストの取得を開始する
        LoadText();
    }

    void LoadText()
    {
        _query = new NCMBQuery<NCMBObject>("TestClass");

        // 保存されているデータ件数を取得
        _query.CountAsync((int count, NCMBException e) => {
            if (e != null)
            {
                //件数取得失敗時の処理
                Debug.Log("件数の取得に失敗しました");
            }
            else
            {
                //ラクガキを取得
                GetTextData(count);
            }
        });
    }

    //テキストをMAX個ランダムに実際に取得する
    void GetTextData(int dataNum)
    {
        // ランダムな番号をmax個作る
        var ary = Enumerable.Range(1, dataNum).OrderBy(n => System.Guid.NewGuid()).Take(MAX).ToArray();

        // 取得するidのリストを作成
        List<int> request = new List<int>();
        // データベースに保存されている文章の数がMAXに満たない場合
        if (dataNum < MAX)
        {
            for (int i = 0; i < dataNum; i++)
            {
                request.Add(ary[i]);
            }
        }
        else // テキストが十分にある場合
        {
            for (int i = 0; i < MAX; i++)
            {
                request.Add(ary[i]);
            }
        }

        //リストを元にRakugakiClassからデータを取得する
        _query.WhereContainedIn("id", request);

        //データを検索し取得
        _query.FindAsync((List<NCMBObject> objectList, NCMBException e) => {
            //取得失敗
            if (e != null)
            {
                //エラーコード表示
                Debug.Log("データの取得に失敗しました");
                return;
            }
            //取得した全データのmessageを表示
            foreach (NCMBObject ncbObject in objectList)
            {
                var text = ncbObject["message"].ToString();
                ShowText(text);
            }

        });

    }

    // テキストを表示する
    void ShowText(string text)
    {
        _outputText.text += text;
    }
}
