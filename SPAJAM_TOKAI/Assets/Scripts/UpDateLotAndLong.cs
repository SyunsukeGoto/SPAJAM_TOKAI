//__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__
/// <file>		UpDateLotAndLong.cs
/// 
/// <brief>		GPS関連のC#ファイル
/// 
/// <date>		2019/6/15
/// 
/// <author>	後藤　駿介
//__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__

// ヘッダファイルの読み込み ================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Goto
{
    public class UpDateLotAndLong : MonoBehaviour
    {
        private Mapbox.Unity.Map.AbstractMap _abstractMap;    /// MapLocationOptionsクラス
        private GetNowLotAndLong _getNowLotAndLong;

        /// <summary>
        /// 初期化処理
        /// </summary>
        void Start()
        {
            _abstractMap = new Mapbox.Unity.Map.AbstractMap();
            _getNowLotAndLong = new GetNowLotAndLong();
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        void Update()
        {
            Mapbox.Utils.Vector2d _lotAndLong = Mapbox.Unity.Utilities.Conversions.StringToLatLon(_getNowLotAndLong.Latitude.ToString() + "," + _getNowLotAndLong.Longitude.ToString());
        }
    }
}