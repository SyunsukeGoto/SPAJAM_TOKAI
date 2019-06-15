using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadTestQRCode : MonoBehaviour
{
    string _result = null;
    WebCamTexture _webCam;
    bool _isInit;

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
        Debug.Log(_webCam.width +" : "+ _webCam.height);
    }

    void Update()
    {
        if (_webCam != null)
        {
            _result = QRCodeHelper.Read(_webCam);
            Debug.LogFormat("result : " + _result);
        }
        CheckDebugMode();
    }

    void OnGUI()
    {
        isDebug = GUILayout.Toggle(isDebug, "DEBUGモード", GUILayout.Height(50f));
        GUILayout.Label(_result, GUILayout.Width(300f), GUILayout.Height(200f));
    }

    #region Debug

    public bool isDebug;
    bool _isDebugMode;

    void CheckDebugMode()
    {
        if (_isDebugMode != isDebug)
        {
            _isDebugMode = isDebug;
            if (_isDebugMode)
                ShowDebugView();
            else
                HideDebugView();
        }
    }

    /// <summary>
    /// 画面右上にWebCamを表示させる
    /// </summary>
    void ShowDebugView()
    {
        var debugCanvasObj = new GameObject("DebugQR");
        var debugRawObj = new GameObject("Raw");
        debugRawObj.transform.SetParent(debugCanvasObj.transform, false);
        var rawImage = debugRawObj.AddComponent<RawImage>();
        var c = debugCanvasObj.AddComponent<Canvas>();
        c.renderMode = RenderMode.ScreenSpaceOverlay;
        rawImage.texture = _webCam;
        float w = 200f;
        float h = w * Screen.width / Screen.height;
        rawImage.rectTransform.sizeDelta = new Vector2(w, h);
        rawImage.rectTransform.anchorMax = new Vector2(1f, 1f);
        rawImage.rectTransform.anchorMin = new Vector2(1f, 1f);
        rawImage.rectTransform.anchoredPosition = new Vector2(-w * 0.5f, -h * 0.5f);
    }

    void HideDebugView()
    {
        Destroy(GameObject.Find("DebugQR"));
    }

    #endregion
}