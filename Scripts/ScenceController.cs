using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenceController : MonoBehaviour
{
    //    static public int SceneName;
    const int SCENE_LOGIN = 1;
    static public string SceneName;

    public static void Scenemanager(int SceneNum)
    {
      
        if(SceneNum == SCENE_LOGIN)
        {
            SceneName = "LOGIN";
        }
        else if(SceneNum ==2)
        {
            SceneName = "FINDPW";
        }
        else if (SceneNum == 3)
        {
            SceneName = "REGISTER";
        }
        else if (SceneNum == 4)
        {
            SceneName = "SELECTION";
        }
        else if (SceneNum == 5)
        {
            SceneName = "SINGLE";
        }
        else if (SceneNum == 6)
        {
            SceneName = "MULTIPLE";
        }
        else if (SceneNum == 7)
        {
            SceneName = "INVITE";
        }
        else if (SceneNum == 8)
        {
            SceneName = "ROOMINFO";
        }
        else if (SceneNum == 9)
        {
            SceneName = "MYPAGE";
        }
        else if (SceneNum == 10)
        {
            SceneName = "CHECKEDPW";
        }
        else if (SceneNum == 11)
        {
            SceneName = "UPDATEINFO";
        }
        else if (SceneNum == 12)
        {
            SceneName = "FRIENDLIST";
        }
        SceneManager.LoadScene(SceneName);
    }

    public void ExitProgram()
    {
        Application.Quit();
      
    }
}
