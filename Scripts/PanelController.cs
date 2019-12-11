using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [Header("Login")]
    public GameObject LoginUI;
    public GameObject RegisterUI;
    public GameObject FindPWUI;

    public GameObject SelectionUI;
    public GameObject MyPageUI;
    public GameObject CheckedPWUI;
    public GameObject UpdateInfoUI;

    public void btnLogin()
    {
        LoginUI.SetActive(true);
        FindPWUI.SetActive(false);
        RegisterUI.SetActive(false);
    }

    public void btnRegister()
    {

        RegisterUI.SetActive(true);
        LoginUI.SetActive(false);
        FindPWUI.SetActive(false);
        
    }

    public void btnFindPW()
    {
        LoginUI.SetActive(false);
        FindPWUI.SetActive(true);
    }

    public void btnSelection()
    {
        SelectionUI.SetActive(true);
        MyPageUI.SetActive(false);
    }

    public void btnMyPage()
    {
        SelectionUI.SetActive(false);
        MyPageUI.SetActive(true);
    }

    public void btnCheckedPW()
    {
        CheckedPWUI.SetActive(true);
        MyPageUI.SetActive(false);
    }
}
