using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class SystemScript : MonoBehaviour
{
    [Header("UI部分の切り替え")]
    public GameObject UI;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject UI5;
    public GameObject Edit;
    public GameObject Secretbutton;

    [Header("日本語英語それぞれ切り替える際のテキスト")]
    public Text marker;
    public Text title;
    public Text Artist;
    public Text book;
    public Text title_2;
    public Text Artist_2;

    [Header("ボタン")]
    public GameObject Button;//「この世界に行く」のボタン
    public GameObject btn;//設定画面の、英語のボタン部分
    public GameObject btn2;//設定画面の、日本語のボタン部分
    [Header("フェード専用のホワイトボード")]
    public GameObject WhiteBoard;

    
    AudioSource audioSource;
    [Header("SE")]
    public AudioClip sound1;//ARを読み込んで、移動する際の音
    public AudioClip sound2;//設定画面の選ぶマウスクリック音
    public AudioClip sound3;//設定の決定ボタン


    //判定ツール
    static public bool japan = false;
    static public bool ARStart = false;
    static public bool ARStart_2 = false;
    bool Final = false;



    // Start is called before the first frame update
    void Start()
    {
        ARStart = false;
        audioSource = GetComponent<AudioSource>();
        if (japan == false)
        {
            English();
            audioSource.Stop();
        }
        if (japan == true)
        {
            Japanese();
            audioSource.Stop();
        }



        //btnj = btn.GetComponent<Button>();
        //btnj2 = btn2.GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Final == false)
        {

            if (FlagScript.flag == false)
            {
                UI.SetActive(false);
                UI2.SetActive(true);
                Secretbutton.SetActive(false);
            }
            if (FlagScript.flag == true)
            {
                UI.SetActive(true);
                UI2.SetActive(false);
                Secretbutton.SetActive(true);
            }

            if (FlagScript_2.flag_2 == false)
            {
                UI.SetActive(false);
                UI5.SetActive(true);
                Secretbutton.SetActive(false);
            }
            if (FlagScript_2.flag_2 == true)
            {
                UI.SetActive(true);
                UI5.SetActive(false);
                Secretbutton.SetActive(true);
            }
        }

        if (Final == true)
        {
            UI3.SetActive(false);
            UI.SetActive(false);
            UI2.SetActive(false);
            UI5.SetActive(false);
            Secretbutton.SetActive(false);
        }
    }
    public void Onclick2()//設定画面を開くボタン
    {
        UI3.SetActive(true);
    }

    public void Japanese()
    {
        marker.text = "マーカーを読み取ってください";
        title.text = "星月夜";
        Artist.text = "ヴァン・ゴッホ";
        title_2.text = "神奈川沖浪裏";
        Artist_2.text = "葛飾北斎";
        book.text = "この世界に行く";
        japan = true;
        audioSource.PlayOneShot(sound2);
        btn.GetComponent<Button>().interactable = false;
        btn2.GetComponent<Button>().interactable = true;

    }

    public void English()
    {
        marker.text = "Please project the painting";
        title.text = "The starry night";
        Artist.text = "Vincent Willem van Gogh";
        title_2.text = "The Great Wave off Kanagawa";
        Artist_2.text = "Katsushika Hokusai";
        book.text = "See the world";
        japan = false;
        audioSource.PlayOneShot(sound2);
        btn.GetComponent<Button>().interactable = true;
        btn2.GetComponent<Button>().interactable = false;


    }

    public void back()
    {
        if (SceneManager.GetActiveScene().name == "AR_Main")
        {
            SceneManager.LoadScene("AR_Main");
        }
        else if (SceneManager.GetActiveScene().name == "AR_Main2")
        {
            SceneManager.LoadScene("AR_Main2");
        }
        FlagScript.flag = true;
        FlagScript_2.flag_2 = true;
    }

    public void Onclick()//この世界にいく、をクリックした時のイベント
    {
        Edit.SetActive(false);
        Final = true;
        audioSource.PlayOneShot(sound1);
        
        if (UIScript.AROn == false)
        {
            WhiteBoard.SetActive(true);

        }
        if (UIScript.AROn == true && FlagScript.flag == false)
        {
            ARStart = true; 
        }
        if (UIScript.AROn == true && FlagScript_2.flag_2 == false)
        {
            ARStart_2 = true;
        }
        Destroy(Button.gameObject);
        


    }

    public void determine()
    {
        audioSource.PlayOneShot(sound3);
        UI3.SetActive(false);
    }

    public void MoveScene()
    {
        if (SceneManager.GetActiveScene().name == "AR_Main")
        {
            SceneManager.LoadScene("AR_Main2");
        }
        else if(SceneManager.GetActiveScene().name == "AR_Main2")
        {
            SceneManager.LoadScene("AR_Main");
        }
    }

}
