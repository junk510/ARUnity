using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoSaveTEST : MonoBehaviour
{
    [Header("MEMOLIST 내용")]
    //public InputField memoNum;
    public InputField Colour;
    public InputField Size;
    public InputField memoType;
    public InputField corX;
    public InputField corY;
    public InputField corZ;
    public InputField lati;
    public InputField longit;
    public InputField alti;
    public InputField memoName;

    public Text resultText;

    public string result;

    string memolist = "memolist";

    string MEMOTYPE = "personal";

    int memonum =0;
    int updatenum = 0;

    //public void FixedUpdate()
    //{
    //    MemoUpdate();
    //}



    //public void btnSaveMemoTest()
    //{
        
    //    memonum = 0;
    //    updatenum++;
    //    StartCoroutine(Entity.SaveMemo("http://14.52.43.228:801/MemoSave.php", "Uniquenum", "UserEmail", "Memonum", "Colour", "Size", "memoType",
    //    "corX", "corY", "corZ", "lati", "longit", "alti", "memoName", csUIL.testEmail+memonum.ToString(),csUIL.testEmail,updatenum.ToString(),Colour.text,Size.text,memoType.text,
    //    corX.text,corY.text,corZ.text,lati.text,longit.text,alti.text,memoName.text));
    //}

    //public void MemoUpdate()
    //{
    //    memonum++;
    //    StartCoroutine(Entity.SaveMemo("http://14.52.43.228:801/MemoSave.php", "Uniquenum", "UserEmail", "Memonum", "Colour", "Size", "memoType",
    //         "corX", "corY", "corZ", "lati", "longit", "alti", "memoName",csUIL.testEmail+updatenum+memonum.ToString(),csUIL.testEmail, updatenum.ToString(), Colour.text, Size.text, memoType.text,
    //    corX.text, corY.text, corZ.text, lati.text, longit.text, alti.text, memoName.text));

    //}

    public void LoadMemoList()
    {
        StartCoroutine(Entity.SELECT(memolist, 1, "http://14.52.43.228:801/SelectMemo.php", "email", "memoType", csUIL.testEmail, MEMOTYPE));
        result = Entity.conditionOfResult;

        resultText.text = result.ToString();
    }


}
