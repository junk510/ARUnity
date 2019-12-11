using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class csUIL : MonoBehaviour
{
    [Header("쿼리 사용 타입")]
    string password;
    string nickname;
    string FINDPW;
    string MYPAGE;
    string userinfo = "userinfo";
    string FriendList;
    string MemoList ="memolist";

    [Header("현재 사용자의 이메일 값을 저장하는 변수")]
    public static string testEmail;
    public static string usingEmail; //바꿀 변수
    public string teste;

    [Header("LOGIN")] //1
    public InputField inputEmail;
    public InputField inputPassword;

    [Header("FINDPW")] //2
    public InputField inputFindPWEmail;

    [Header("REGISTER")] //3
    public InputField inputRegiEmail;
    public InputField inputRegiPassword;
    public InputField inputNickName;

    [Header("Password 확인 기능")]
    static string tempEmail;
    public InputField inputCheckedPassword;

    [Header("CHECKEDPW")]
    public InputField inputCheckedPW;

    [Header("UPDATE 업데이트 기능")]
    public InputField inputchagnePW;
    public InputField inputchangeNickName;

    [Header("TEST")]
    public GameObject ErrorCanvas;
    public Text ErrorText;
    
    public static string ChangePWEmail;

    [Header("Exit")]
    public GameObject EXIT;
    public GameObject LOGOUT;
    public GameObject Draw;


    public GameObject LoginUI;
    public GameObject RegisterUI;
    public GameObject FindPWUI;

    public GameObject SavePanel;
    public Toggle swithPublic;
    public Toggle swithPrivate;

    public static int MemoType;
    


    bool saveOpenPanel;
    bool openPanel;
    int countTouchPanelbtn = 0;
    private void Start()
    {
        //StartCoroutine(Entity.GetServer());   //서버연결
        StartCoroutine(Entity.CountMemoNum("http://14.52.43.228:801/MemoCount.php", "email", "test3"));

    }

    public void btnNickTest()
    {
        StartCoroutine(Entity.NickNameTEST("http://14.52.43.228:801/GetFriendNickName.php", "loginUser", "test3"));
    }

    //로그인
    public void btnLogin()
    {
        StartCoroutine(Entity.SELECT(userinfo, 1, "http://14.52.43.228:801/LoginHopstick.php", "loginUser", "loginPass",
        inputEmail.text, inputPassword.text));
        teste = inputEmail.text;
        testEmail = inputEmail.text;
        inputEmail.text = null;
        inputPassword.text = null;
    }

    public void btnNewMember()
    {
        StartCoroutine(Entity.INSERT(userinfo, 1, "http://14.52.43.228:801/RegisterUserHopstick.php", "loginUser", "loginPass", "RegiNick",
      inputRegiEmail.text, inputRegiPassword.text, inputNickName.text));
      inputRegiEmail.text = null; inputRegiPassword.text = null; inputNickName.text = null;
    }

    public void btnCheckedPW()
    {
        StartCoroutine(Entity.SELECT(userinfo, 2, "http://14.52.43.228:801/CheckedPWHopstick.php", "CheckedEmail", "CheckedPass",
        testEmail,inputCheckedPW.text));

        Debug.Log("아이디 들어옴:" + testEmail.ToString());
        inputCheckedPW.text = null;
    }

    //비밀번호 업로드 --UPDATEINFO에서
    public void btnConfirmPWUpdate()
    {
        StartCoroutine(Entity.UPDATE(1, password, "http://14.52.43.228:801/updatePass.php",
        "CheckedEmail", "updatePass", testEmail, inputchagnePW.text));
        inputchagnePW.text = null;
    }

    //닉네임 업로드 -- UPDATEINFO에서
    public void btnConfirmNickNameUpdate()
    {
        StartCoroutine(Entity.UPDATE(3, nickname, "http://14.52.43.228:801/updateNickName.php",
        "CheckedEmail", "updateNickName", testEmail, inputchangeNickName.text));
        inputchangeNickName.text = null;
    }

    //비밀번호 업로드 -- FINDPW
    public void btnSendEmail()
    {
        StartCoroutine(Entity.UPDATE(2, password, "http://14.52.43.228:801/updatePass.php",
       "CheckedEmail", "updatePass", inputFindPWEmail.text, EmailController.RandomPassWord));
        inputFindPWEmail.text = null;
    }

    public void btnSceneController(int sceneNum)
    {
      ScenceController.Scenemanager(sceneNum);
    }

    public void btnOpenExit()
    {
      EXIT.SetActive(true);
    }

    public void btnCloseExit()
    {
      EXIT.SetActive(false);
    }
    public void btnLogoutOpen()
    {
        LOGOUT.SetActive(true);
    }
    public void btnLogoutClose()
    {
        LOGOUT.SetActive(false);
    }

     public void btnOpenDrawPanel()
    {
       Draw.SetActive(true);
       Drawing.checkedPanel = false;
    }

    public void btnOpenSavePanel()
    {
        SavePanel.SetActive(true);
        saveOpenPanel = true;
    }

    public void btnCloseSavePanel()
    {
        SavePanel.SetActive(false);
    }

    public void OnChangeValue()
    {
        if(swithPrivate.isOn == true)
        {
            Debug.Log("PRIVATE:" + 1);
            MemoType = 1;
        }
        if(swithPublic.isOn == true)
        {
            Debug.Log("PUBLIC:"+0);
            MemoType = 0;
        }
    }

    public void TestLine()
    {
        StartCoroutine(Entity.memoLoad("http://14.52.43.228:801/PublicMemoLoad.php", "email", "test3"));
    }

}


