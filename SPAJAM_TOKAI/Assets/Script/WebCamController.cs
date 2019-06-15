using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class WebCamController : MonoBehaviour
{
    [SerializeField, Header("幅")]
    private int width;

    [SerializeField, Header("高さ")]
    private int height;

    [SerializeField, Header("FPS")]
    private int fps;

    [SerializeField, Header("カメラマテリアル")]
    private RawImage material;

    private WebCamTexture[] webcamTexture;

    private int currentNum;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(10);
        webcamTexture = new WebCamTexture[WebCamTexture.devices.Length];
        currentNum = 0;

        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < WebCamTexture.devices.Length; i++)
        {
            webcamTexture[i] = new WebCamTexture(devices[i].name, width, height, fps);
        }
        material.texture = webcamTexture[currentNum];
        webcamTexture[currentNum].Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}