using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    [SerializeField]
    private Image _waveFrontImage;

    [SerializeField]
    private Image _waveBackImage;

    private float _red, _green, _blue, _alfa;

    private float fadeSpeed = 0.005f;

    [SerializeField]
    private bool isFadeIn = false;

    const int MOVE_SPEED_X = 10;
    const int MOVE_SPEED_Y = 20;

    private int _moveCountY = -2160;
    private int _moveFrontCountX = 540;
    private int _moveBackCountX = -540;

    void Start()
    {
        _red = _waveFrontImage.color.r;
        _green = _waveFrontImage.color.g;
        _blue = _waveFrontImage.color.b;
        _alfa = _waveFrontImage.color.a;

        _red = _waveBackImage.color.r;
        _green = _waveBackImage.color.g;
        _blue = _waveBackImage.color.b;
        _alfa = _waveBackImage.color.a;
    }

    void Update()
    {
        // ==================================
        // Waveのアニメーション
        // ==================================
        _waveFrontImage.rectTransform.anchoredPosition = new Vector2(_moveFrontCountX, _moveCountY);
        _waveBackImage.rectTransform.anchoredPosition = new Vector2(_moveBackCountX, _moveCountY);

        _moveFrontCountX -= MOVE_SPEED_X;
        _moveBackCountX += MOVE_SPEED_X;
        _moveCountY += MOVE_SPEED_Y;
        // ==================================
        // Waveのフェード
        // ==================================
        if (isFadeIn)
        {
            StartFadeIn();
        }
    }

    void StartFadeIn()
    {
        _alfa -= fadeSpeed;
        SetAlpha();
        if (_alfa <= 0)
        {           
            isFadeIn = false;
            _waveFrontImage.enabled = false;
            _waveBackImage.enabled = false;
        }
    }

    void SetAlpha()
    {
        _waveFrontImage.color = new Color(_red, _green, _blue, _alfa);
        _waveBackImage.color = new Color(_red, _green, _blue, _alfa);
    }
}
