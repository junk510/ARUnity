using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using UnityEngine.UI;

public class EmailController : MonoBehaviour
{

    static string RandomPW;
    string takeEmail;

    public InputField email;

    public Animator anim;
    public Image background;
   
    
    public static string RandomPassWord;
    public void makeRandomPW()
    {
        int val;
        float temp = Time.deltaTime;
        Random.InitState((int)temp);
        int temptemp;
        val = Random.Range(32658, 36987245);
        RandomPassWord = val.ToString();
        //Debug.Log("성공:"+RandomPassWord);      
    }

   
    public void btnsendEmail()
    {
        //anim.SetBool("ClickLogin", true);
        makeRandomPW();
        Debug.Log("난수 비밀번호 생성:" + RandomPassWord);

        //takeEmail= PHPTEST.ChangePWEmail;
        Debug.Log("여기 이메일 보내는 기능:"+ email.text);
        MailMessage mail = new MailMessage();

        //보내는 사람
        mail.From = new MailAddress("kismet1023@gmail.com");


        //받는 사람
        // mail.To.Add("bora7749@naver.com");
        mail.To.Add(email.text);
        mail.Subject = "HOPSTICK 비밀번호 설정";
        mail.Body = "사용자 님의 비밀번호는"+RandomPassWord+"입니다";

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        
        //보내는 사람 주소 및 비밀번호 확인
        smtpServer.Credentials = new System.Net.NetworkCredential("kismet1023@gmail.com","dkfqkcjsrnr1") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        
        smtpServer.Send(mail);
        Debug.Log("메일이 성공적으로 보내짐");

        
    }
}
