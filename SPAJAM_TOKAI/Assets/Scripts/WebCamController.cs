using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class WebCamController : MonoBehaviour
{
    [SerializeField, Header("幅")]
    private int width;

    [SerializeField, Header("高さ")]
    private int height;

    [SerializeField, Header("FPS")]
    private int fps;

    [SerializeField, Header("カメラマテリアル")]
    private Material material;

    [SerializeField]
    private GameObject canvas;

    private WebCamTexture[] webcamTexture;

    string _result = null;

    private int currentNum;

    public enum Mode
    {
        QR,      // QRコードを読み取る
        Brrow,   // 借りる
    }

    private Mode mode;

    private string id;

    void Start()
    {
        mode = Mode.QR;

        webcamTexture = new WebCamTexture[WebCamTexture.devices.Length];
        currentNum = 0;

        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < WebCamTexture.devices.Length; i++)
        {
            webcamTexture[i] = new WebCamTexture(devices[i].name, width, height, fps);
        }
        material.mainTexture = webcamTexture[currentNum];
        webcamTexture[currentNum].Play();
    }

    // Update is called once per frame
    void Update()
    {
        switch(mode)
        {
            case Mode.QR:
                if (webcamTexture[currentNum] != null)
                {
                    _result = QRCodeHelper.Read(webcamTexture[currentNum]);
                    Debug.LogFormat("result : " + _result);

                    if (_result != "error")
                    {
                        id = _result;
                        canvas.SetActive(false);
                        mode = Mode.Brrow;
                    }
                }
                break;
            case Mode.Brrow:

                break;
        }
       
    }
}
