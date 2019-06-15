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
        [SerializeField]
        private GameObject _abstractMapObj;
        [SerializeField]
        private GameObject _getNowLotAndLongObj;
        private int _upDateData;

        /// <summary>
        /// 初期化処理
        /// </summary>
        void Start()
        {
            _upDateData = 0;
            _abstractMap = _abstractMapObj.GetComponent<Mapbox.Unity.Map.AbstractMap>();
            _getNowLotAndLong = _getNowLotAndLongObj.GetComponent<GetNowLotAndLong>();
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        void Update()
        {
            _upDateData++;

            if (_upDateData < 60)
            {
                Mapbox.Utils.Vector2d _lotAndLong = Mapbox.Unity.Utilities.Conversions.StringToLatLon(_getNowLotAndLong.Latitude.ToString() + "," + _getNowLotAndLong.Longitude.ToString());
                //_abstractMap.SetCenterLatitudeLongitude(_lotAndLong);
                _abstractMap.UpdateMap(_lotAndLong, 14);
            }

            _upDateData = _upDateData < 60 ? 0 : _upDateData;
        }
    }
}