using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class csLoginUI : MonoBehaviour
{

    public Image background;

    public float selectedTime = 1.0f; //프로그래스바가 다 채워지는 시간
    public float passedTime = 0.0f;  //응시한 후로부터 지난 시간
    public int time;

    private void Start()
    {
        StartCoroutine(LoginEffect());  
    }


    IEnumerator LoginEffect()
    {
        
        yield return new WaitForSeconds(3f);
        passedTime += Time.deltaTime;
        for (float i = 0.0f; i < 1; i = i + 0.01f)
        {
            yield return new WaitForSeconds(0.5f);
            background.fillAmount = 0.9f;
        }
    }


}
