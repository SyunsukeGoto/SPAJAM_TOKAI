using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadTestQRCode : MonoBehaviour
{
    private string _result = null;

    [SerializeField]
    private Material _material;
    
    private WebCamTexture _webCam;

    public Material Material { get => _material; set => _material = value; }

    IEnumerator Start()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam) == false)
        {
            Debug.LogFormat("no camera.");
            yield break;
        }
        Debug.LogFormat("camera ok.");
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices == null || devices.Length == 0)
            yield break;
        _webCam = new WebCamTexture(devices[0].name, Screen.width, Screen.height, 12);
        _webCam.Play();
    }

    void Update()
    {
        _material.mainTexture = _webCam;
        if (_webCam != null)
        {
            _result = QRCodeHelper.Read(_webCam);
            Debug.LogFormat("result : " + _result);
        }
    }

}