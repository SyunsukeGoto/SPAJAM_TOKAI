using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class Test : MonoBehaviour
{
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private Text text;
    [SerializeField]
    private Text nameText;

    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
        text = text.GetComponent<Text>();
        nameText.text = NCMBUser.CurrentUser.UserName;

        inputField.text = NCMBUser.CurrentUser["ProfileText"].ToString();
    }

    public void InputText()
    {
        text.text = inputField.text;
    }

    public void Send()
    {
        NCMBUser.CurrentUser["ProfileText"] = inputField.text;
        NCMBUser.CurrentUser.SaveAsync();
    }
}