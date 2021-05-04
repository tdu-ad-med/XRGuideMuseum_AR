using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class SystemScript : MonoBehaviour
{
    //public GameObject RootObject;
    public GameObject UI;
    public GameObject UI2;
    public GameObject UI3;

    public Text marker;
    public Text title;
    public Text Artist;
    public Text book;

    public GameObject Button;
    public GameObject WhiteBoard;

    AudioSource audioSource;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    static public bool japan = false;

    public GameObject laungages;

    public GameObject btn;
    Button btnj;

    public GameObject btn2;
    Button btnj2;

    bool Final = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
            }
            if (FlagScript.flag == true)
            {
                UI.SetActive(true);
                UI2.SetActive(false);
            }
        }

        if (Final == true)
        {
            UI3.SetActive(false);
            UI.SetActive(false);
            UI2.SetActive(false);
        }
    }
    public void Onclick2()
    {
        UI3.SetActive(true);
    }

    public void Japanese()
    {
        marker.text = "マーカーを読み取ってください";
        title.text = "星月夜";
        Artist.text = "ヴァン・ゴッホ";
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
        book.text = "See the world";
        japan = false;
        audioSource.PlayOneShot(sound2);
        btn.GetComponent<Button>().interactable = true;
        btn2.GetComponent<Button>().interactable = false;


    }

    public void back()
    {
        SceneManager.LoadScene("AR_Main");
        FlagScript.flag = true;
    }

    public void Onclick()
    {
        Final = true;
        audioSource.PlayOneShot(sound1);
        WhiteBoard.SetActive(true);
        
        laungages.SetActive(false);
        Destroy(Button.gameObject);
       
    }

    public void determine()
    {
        audioSource.PlayOneShot(sound3);
        UI3.SetActive(false);
    }

}
