using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class csShowFriendList : MonoBehaviour
{
    public static string usingEmail = "hsy4988@naver.com";
    public InputField friendEmail;
    public string f_nickname;
    public string primary;
    public int f_num = 1;

    public string friendlist;
    public static int friendCount;


    void Start()
    {
        //StartCoroutine(showFriendList());
        //Invoke("showList", 1f);

        
    }

    void Update()
    {
        
    }

    public IEnumerator checkUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", friendEmail.text); // InputField에서 받은 친구 이메일을 php로 보내기
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:800/GetFriendNickname_S.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("네트워크 에러:" + www.error);
            }
            else
            {
                f_nickname = www.downloadHandler.text;  // userinfo에서 가져온 친구 닉네임 f_nickname에 저장
            }

        }
    }




    public IEnumerator saveFriend()
    {
        primary = usingEmail + friendEmail.text;
        WWWForm form = new WWWForm();
        form.AddField("primary", primary);
        form.AddField("email", usingEmail);
        form.AddField("friendemail", friendEmail.text);
        form.AddField("friendnickname", f_nickname + ";");
        form.AddField("num", f_num);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:800/AddFriendList_S.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("네트워크 에러:" + www.error);
            }
            else
            {
                //Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public void valChangeFriendemail()
    {
        StartCoroutine(checkUser()); // userinfo에서 추가할 친구의 nickname만 받아와
    }


    public void btnAddFriend()
    {
        StartCoroutine(saveFriend());
        f_num += f_num;
    }


}
