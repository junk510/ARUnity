using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class MyGPS : MonoBehaviour
{
    public Text latitude;   // 나의 현재 위치의 위도 텍스트
    public Text longitude;  // 나의 현재 위치의 경도 텍스트
    
    public Text gpsLog;     // GPS 수신 결과를 표시하기 위한 변수

    public float lat;       // 실제 나의 위도 데이터
    public float lon;       // 실제 나의 경도 데이터
    

    float currentTime = 0;  // 수신 체크용 변수

    [Header("testGPS")]

    // 위도, 경도 값 string으로 변환한 값
    public static string lati;
    public static string longi;
    

    void Start()
    {
        // 기기에 위치정보 이용에 관한 허가 여부를 받는다.    

        // 1-1 만일 위치 정보 동의를 받은적이 없으면,
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            //동의를 받는다.
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        // 1-2 그렇지 않고 이미 위치 정보 동의를 받았다면
        else
        {
            //GPS를 사용한다.
            StartCoroutine(MyGPSOn());
        }
    }

    // GPS 사용하기
    IEnumerator MyGPSOn()
    {
        if (!Input.location.isEnabledByUser)
            yield break;
        Input.location.Start(10.0f, 1.0f);

        int maxWait = 40;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1f);
            --maxWait;
        }
        if (Input.location.status == LocationServiceStatus.Initializing)
        {
            gpsLog.text = "응답이 없네요...";
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            gpsLog.text = "수신에 실패했어요...";
            yield break;
        }
    }
    void Update()
    {
        LocationInfo li;
        li = Input.location.lastData;

        lat = li.latitude;
        lon = li.longitude;

        lati = lat.ToString();
        longi= lon.ToString();

        latitude.text = "위도 : " + lati;
        longitude.text = "경도 : " + longi;
        gpsLog.text = "GPS 상태 : " + Input.location.status;
    }

}
