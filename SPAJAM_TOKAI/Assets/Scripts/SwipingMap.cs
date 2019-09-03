
//__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__
/// <file>		SwipeMap.cs
/// 
/// <brief>		GPS関連のC#ファイル
/// 
/// <date>		2019/6/16
/// 
/// <author>	後藤　駿介
//__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__

// ヘッダファイルの読み込み ================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Goto
{
    public class SwipingMap : MonoBehaviour
    {
        private Mapbox.Unity.Map.AbstractMap _abstractMap;    /// MapLocationOptionsクラス
        private GetNowLotAndLong _getNowLotAndLong;
        [SerializeField]
        private GameObject _abstractMapObj;
        [SerializeField]
        private GameObject _getNowLotAndLongObj;
        private Vector2 _nowLotAndLong;

        // 変数宣言
        float x_speed = 0;
        float y_speed = 0;
        Vector2 startPos;
        
        public bool _goBackFlug
        {
            get;
            set;
        }

        // Use this for initialization
        void Start()
        {
            _goBackFlug = false;
            _abstractMap = _abstractMapObj.GetComponent<Mapbox.Unity.Map.AbstractMap>();
            _getNowLotAndLong = _getNowLotAndLongObj.GetComponent<GetNowLotAndLong>();
            _nowLotAndLong = new Vector2(_getNowLotAndLong.Latitude, _getNowLotAndLong.Longitude);
        }

        // Update is called once per frame
        void Update()
        {
            
            // メソッドを呼び出す
            MoveSwipe();
            
        }

        // スワイプして上下左右に動かす
        void MoveSwipe()
        {
            // マウスが左クリックされたとき
            if (Input.GetMouseButtonDown(0))
            {
                // マウスをクリックした座標
                this.startPos = Input.mousePosition;
                _goBackFlug = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                // マウスを離した座標
                Vector2 endPos = Input.mousePosition;

                float x_swipeLength = endPos.x - this.startPos.x;
                float y_swipeLength = endPos.y - this.startPos.y;

                // スワイプの長さを速度に変換する
                this.x_speed = x_swipeLength / 100000.0f;
                this.y_speed = y_swipeLength / 100000.0f;
            }

            _nowLotAndLong += new Vector2(x_speed, y_speed);
            Mapbox.Utils.Vector2d _lotAndLong = Mapbox.Unity.Utilities.Conversions.StringToLatLon(_nowLotAndLong.x.ToString() + "," + _nowLotAndLong.y.ToString());
            //_abstractMap.SetCenterLatitudeLongitude(_lotAndLong);
            _abstractMap.UpdateMap(_lotAndLong, 14);

            // 減速させる
            this.x_speed *= 0.98f;
            this.y_speed *= 0.98f;
        }
    }
}
