using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;
using ZXing;
using ZXing.QrCode;
using UnityEngine.SceneManagement;

public class RegisterUmbrella : MonoBehaviour
{
    [SerializeField]
    private Text nameText;

    [SerializeField]
    private Text addressText;

    [SerializeField]
    private GameObject image;

    [SerializeField]
    private Button button;

    [SerializeField]
    private Text buttonText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Register()
    {
        // クラスのNCMBObjectを作成
        NCMBObject testClass = new NCMBObject("Umbrella");

        // オブジェクトに値を設定
        testClass["IsBorrow"] = false;
        testClass["LenderID"] = NCMBUser.CurrentUser.ObjectId;

        // データストアへの登録
        testClass.SaveAsync();

        StartCoroutine(GetID(testClass, NCMBUser.CurrentUser));
    }

    IEnumerator GetID(NCMBObject a, NCMBUser user)
    {
        while (a.ObjectId == null)
        {
            yield return new WaitForSeconds(0.1f);
        }
        
        //成功時の処理
        user["LendUmbrellaID"] = a.ObjectId;
        Debug.Log(a.ObjectId);
        user.SaveAsync();

        Texture2D qr = CreateQR(a.ObjectId, 256, 256);
        image.GetComponent<Image>().sprite = Sprite.Create(qr, new Rect(0, 0, qr.width, qr.height), Vector2.zero);
        image.SetActive(true);

        buttonText.text = "閉じる";
        button.onClick.AddListener(Back);
    }

    Texture2D CreateQR(string inputString, int width, int height)
    {
        var texture = new Texture2D(width, height);
        var qrCodeColors = Write(inputString, width, height);
        texture.SetPixels32(qrCodeColors);
        texture.Apply();

        return texture;
    }

    Color32[] Write(string content, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };

        return writer.Write(content);
    }

    public void Back()
    {
        SceneManager.LoadScene("UmbrellaMapScene");
    }
}
