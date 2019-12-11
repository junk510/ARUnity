using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class csVideo : MonoBehaviour
{
    RawImage Image;
    public VideoPlayer vidio;
    void Awake()
    {
        Image = GetComponent<RawImage>();
        vidio = gameObject.AddComponent<VideoPlayer>();
        
        vidio.playOnAwake = true;
   
        //PlayVideo();
    }
    //public void PlayVideo()
    //{
    //    StartCoroutine(playVideo());
    //}
    //IEnumerator playVideo()
    //{
    //    vidio.source = VideoSource.Url;
    //    vidio.url = "file://C:\Users\st\Desktop\1_Bitcamp\2_Character\HOPSTICKLOGO0010-0119.avi";

    //    vidio.audioOutputMode = VideoAudioOutputMode.AudioSource;

    //    vidio.EnableAudioTrack(0, true);
    //    vidio.SetTargetAudioSource(0, audio);
    //    vidio.Prepare();
    //    WaitForSeconds waitTime = new WaitForSeconds(1.0f);
    //    while (!vidio.isPrepared)
    //    {
    //        Debug.Log("동영상 준비중...");
    //        yield return waitTime;
    //    }
    //    Debug.Log("동영상이 준비가 끝났습니다.");
    //    Image.texture = vidio.texture;
    //    vidio.Play();
    //    audio.Play();
    //    Debug.Log("동영상이 재생됩니다.");
    //    while (vidio.isPlaying)
    //    {
    //        Debug.Log("동영상 재생 시간 : " + Mathf.FloorToInt((float)vidio.time));
    //        yield return null;
    //    }
    //    Debug.Log("영상이 끝났습니다.");
    //}
}

