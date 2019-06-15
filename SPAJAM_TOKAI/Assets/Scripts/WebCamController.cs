using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private WebCamTexture[] webcamTexture;

    string _result = null;

    private int currentNum;

    void Start()
    {
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
        if (webcamTexture[currentNum] != null)
        {
            _result = QRCodeHelper.Read(webcamTexture[currentNum]);
            Debug.LogFormat("result : " + _result);
        }
    }
}
