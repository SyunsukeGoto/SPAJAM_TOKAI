using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberDisplay : MonoBehaviour
{
    [SerializeField, Header("式を表示するテキスト")]
    private Text mFormulaText;

    [SerializeField, Header("答えを表示するテキスト")]
    private Text mAnswerText;

    // ストリングビルダー
    private System.Text.StringBuilder mSB;

    // Start is called before the first frame update
    void Start()
    {
        mSB = new System.Text.StringBuilder();
    }

    // Update is called once per frame
    void Update()
    {
        string[] arr = mFormulaText.text.Split('＋', 'ー', '×', '÷');

        int ans = 0;

        for(int i = 0; i < arr.Length; i++)
        {
            ans += int.Parse(arr[i]);
        }

        mAnswerText.text = ans.ToString();
    }

    public void Zero()
    {
        mSB.Append("0");
        mFormulaText.text = mSB.ToString();
    }

    public void One()
    {
        mSB.Append("1");
        mFormulaText.text = mSB.ToString();
    }

    public void Two()
    {
        mSB.Append("2");
        mFormulaText.text = mSB.ToString();
    }

    public void Three()
    {
        mSB.Append("3");
        mFormulaText.text = mSB.ToString();
    }

    public void Four()
    {
        mSB.Append("4");
        mFormulaText.text = mSB.ToString();
    }

    public void Five()
    {
        mSB.Append("5");
        mFormulaText.text = mSB.ToString();
    }

    public void Six()
    {
        mSB.Append("6");
        mFormulaText.text = mSB.ToString();
    }

    public void Seven()
    {
        mSB.Append("7");
        mFormulaText.text = mSB.ToString();
    }

    public void Eight()
    {
        mSB.Append("8");
        mFormulaText.text = mSB.ToString();
    }

    public void Nine()
    {
        mSB.Append("9");
        mFormulaText.text = mSB.ToString();
    }

    public void Delete()
    {
        mSB = mSB.Remove(mSB.Length - 1, 1);
        mFormulaText.text = mSB.ToString();
    }

    public void Add()
    {
        mSB.Append("＋");
        mFormulaText.text = mSB.ToString();
    }

    public void Min()
    {
        mSB.Append("－");
        mFormulaText.text = mSB.ToString();
    }

    public void Mul()
    {
        mSB.Append("×");
        mFormulaText.text = mSB.ToString();
    }

    public void Div()
    {
        mSB.Append("÷");
        mFormulaText.text = mSB.ToString();
    }
}
