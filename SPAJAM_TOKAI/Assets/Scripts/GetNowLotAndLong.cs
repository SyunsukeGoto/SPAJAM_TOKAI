//__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__
/// <file>		GetNowLotAndLong.cs
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
    public class GetNowLotAndLong : MonoBehaviour
    {
        [SerializeField]
        private const float _intervalSeconds = 1.0f;                        /// 経緯度取得間隔(秒)
        private LocationServiceStatus _locationServiceStatus;               /// ロケーションサービスのステータス
        
        /// <summary>
        /// 経度
        /// </summary>
        public float Longitude
        {
            get;
            private set;
        }

        /// <summary>
        /// 経度
        /// </summary>
        public float Latitude
        {
            get;
            private set;
        }

        /// <summary>
        /// 緯度経度情報が取得可能を取得
        /// </summary>
        /// <returns>true or false</returns>
        public bool CanGetLonLat()
        {
            return Input.location.isEnabledByUser;
        }

        /// <summary>
        /// 経緯度取得処理
        /// </summary>
        /// <returns>一定期間毎に非同期実行するための戻り値</returns>
        private IEnumerator Start()
        {
            while (true)
            {
                _locationServiceStatus = Input.location.status;
                if (Input.location.isEnabledByUser)
                {
                    switch (_locationServiceStatus)
                    {
                        case LocationServiceStatus.Stopped:
                            Input.location.Start();
                            break;
                        case LocationServiceStatus.Running:
                            Longitude = Input.location.lastData.longitude;
                            Latitude = Input.location.lastData.latitude;
                            break;
                        default:
                            break;
                    }
                }

                yield return new WaitForSeconds(_intervalSeconds);
            }
        }
    }
}
