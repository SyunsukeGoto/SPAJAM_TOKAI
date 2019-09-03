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
    public class SwipeMap : MonoBehaviour
    {
        // 変数宣言
        float x_speed = 0;
        float y_speed = 0;
        Vector2 startPos;
        [SerializeField]
        Camera _camera;
        Vector3 _cameraPos;

        int a = 0;
        public bool _goBackFlug
        {
            get;
            set;
        }

        // Use this for initialization
        void Start()
        {
            _goBackFlug = false;
        }

        // Update is called once per frame
        void Update()
        {
            

            // メソッドを呼び出す
            MoveSwipe();



            if(!_goBackFlug)
            {
                _camera.transform.position = new Vector3(0f, 115f, 0f);
            }
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
                this.x_speed = x_swipeLength / 500.0f;
                this.y_speed = y_swipeLength / 500.0f;
            }           
            
            if(_camera.transform.position.z >= 30f)
            {
                _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, 30f);
            }
            else
            if (_camera.transform.position.z <= -130f)
            {
                _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, -130f);
            }

            if (_goBackFlug)
            {
                _camera.transform.Translate(-this.x_speed, -this.y_speed, 0);
            }

            if(_camera.transform.position.x <= -65f)
            {
                _camera.transform.position = new Vector3(-65f, _camera.transform.position.y, _camera.transform.position.z);
            }
            else
            if (_camera.transform.position.x >= 165f)
            {
                _camera.transform.position = new Vector3(165f, _camera.transform.position.y, _camera.transform.position.z);
            }
            else
            {
                _camera.transform.Translate(-this.x_speed, -this.y_speed, 0);
            }
        
            Debug.Log(_camera.transform);
            // 減速させる
            this.x_speed *= 0.98f;
            this.y_speed *= 0.98f;
        }
    }
}
    