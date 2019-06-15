using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private Text text;

    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
        text = text.GetComponent<Text>();
    }

    public void InputText()
    {
        text.text = inputField.text;
    }
}