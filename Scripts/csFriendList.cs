using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class csFriendList : MonoBehaviour
{
    public static string usingEmail = "hsy4988@naver.com";

    public string friendlist;
    public static int friendCount;

    void Start()
    {
        StartCoroutine(showFriendList());
        Invoke("showList", 1f);
    }

    void Update()
    {
        
    }

    public IEnumerator showFriendList()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", usingEmail);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:800/FriendList_S.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("네트워크 에러:" + www.error);
            }
            else
            {
                friendlist = www.downloadHandler.text;
            }
        }
    }

    public void showList()
    {
        string[] split_text = friendlist.Split(';');
        friendCount = split_text.Length - 1;

        for (int i = 0; i < split_text.Length - 1; i++)
        {
            GameObject.Find("GridWithOurElementsOrOptions").transform.
                Find("btnFriend" + i.ToString()).gameObject.SetActive(true);

        }

        for (int i = 0; i < split_text.Length - 1; i++)
        {
            GameObject.Find("btnFriend" + i).
                GetComponentInChildren<Text>().text = split_text[i];
        }
    }
}
