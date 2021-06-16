using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class RayCastScript2 : MonoBehaviour
{
    
    GameObject clickedGameObject;

    bool voiceon = true;

    static public bool texton2 = true;
    static public bool laungageon2 = true;
    static public bool worksmode2 = false;

    AudioSource audioSource2;
    [Header("英語ガイドボイス")]
    public AudioClip sound1;//English
    [Header("日本語ガイドボイス")]
    public AudioClip sound1_2;//japanese
    [Header("SE")]
    public AudioClip sound_Book;
    public AudioClip sound_Wave;


    //[SerializeField] private GameObject placementPrefab;
    [Header("AR System")]
    [SerializeField] private Camera arCamera;
    [SerializeField] private ARRaycastManager raycastManager;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    //ログ用のbool関数,一回判定するbool関数
    bool gimicJudgment = true;
    bool TextJudment = true;
    bool VoiceJudment = true;
    bool laungageJudment = true;
    bool gimic2judment = true;
    //AR起動したとき、日本語版と英語版が設定から反映するときに、一回処理する
    int count = 0;
    //音量調節
    float sound_japanese_volume = 1.0f;
    float sound_English_volume = 0.5f;
    float sound_Book_volume = 0.5f;
    //float sound_moon_volume = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        audioSource2 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemScript.ARStart_2 == true)
        {
            if (count == 0)
            {
                GameObject cube7 = GameObject.Find("WaveAnimation");
                cube7.GetComponent<ParticleSystem>().Stop();
                GameObject cube8 = GameObject.Find("WaveAnimation2");
                cube8.GetComponent<ParticleSystem>().Stop();
                GameObject cube9 = GameObject.Find("Splash");
                cube9.GetComponent<ParticleSystem>().Stop();
                GameObject cube10 = GameObject.Find("Splash2");
                cube10.GetComponent<ParticleSystem>().Stop();

                if (SystemScript.japan == true)
                {
                    Japanese();
                }
                if (SystemScript.japan == false)
                {
                    English();
                }
                count = 1;
            }
        }
        var touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            // rayを照射
            var ray = arCamera.ScreenPointToRay(touch.position);


            RaycastHit hit = new RaycastHit();
            clickedGameObject = null;
            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;

            }
            /*
            if (clickedGameObject.tag == "Moon")
            {
                if (gimicJudgment == true)
                {
                    clickedGameObject.GetComponent<Animator>().SetBool("MoonOn", true);
                    LogSystemScript.GimicLog += 1;
                    audioSource2.volume = sound_moon_volume;
                    audioSource2.PlayOneShot(sound_Moon);
                    gimicJudgment = false;
                }

            }*/

            if (clickedGameObject.tag == "Works")
            {
                if (worksmode2 == false)
                {
                    GameObject cube5 = GameObject.Find("Worktext_2");
                    GameObject cube6 = GameObject.Find("Workmode_2");
                    GameObject cube7 = GameObject.Find("WorkMove");
                    cube6.GetComponent<Canvas>().enabled = true;
                    cube5.GetComponent<Canvas>().enabled = true;
                    cube7.GetComponent<Canvas>().enabled = true;
                    audioSource2.volume = sound_Book_volume;
                    audioSource2.PlayOneShot(sound_Book);
                    LogSystemScript.GimicLog++;
                    worksmode2 = true;
                    return;
                }


            }
            if (clickedGameObject.tag == "Workmode")
            {
                GameObject cube5 = GameObject.Find("Worktext_2");
                GameObject cube6 = GameObject.Find("Workmode_2");
                GameObject cube7 = GameObject.Find("WorkMove");
                cube6.GetComponent<Canvas>().enabled = false;
                cube5.GetComponent<Canvas>().enabled = false;
                cube7.GetComponent<Canvas>().enabled = false;
        
                audioSource2.volume = sound_Book_volume;
                audioSource2.PlayOneShot(sound_Book);
                worksmode2 = false;
                return;
            }

            if (clickedGameObject.tag == "Wave")
            {
                gimic2judment = true;
                if (gimic2judment == true)
                {
                    GameObject cube5 = GameObject.Find("BGM");
                    AudioSource audioSource = cube5.GetComponent<AudioSource>();

                    GameObject cube7 = GameObject.Find("WaveAnimation");
                    GameObject cube8 = GameObject.Find("WaveAnimation2");
                    GameObject cube9 = GameObject.Find("Splash");
                    GameObject cube10 = GameObject.Find("Splash2");
                    cube7.GetComponent<ParticleSystem>().Play();
                    cube8.GetComponent<ParticleSystem>().Play();
                    cube9.GetComponent<ParticleSystem>().Play();
                    cube10.GetComponent<ParticleSystem>().Play();
                    audioSource.clip = sound_Wave;
                    audioSource.Play();
                    LogSystemScript.GimicLog++;
                    gimic2judment = false;
                    return;
                }
            }

            if (clickedGameObject.tag == "Brother")
            {
                if (gimicJudgment == true)
                {
                    GameObject cube5 = GameObject.Find("Gohotext");
                    cube5.GetComponent<Canvas>().enabled = true;
                    GameObject cube6 = GameObject.Find("letter");
                    cube5.GetComponent<Canvas>().enabled = true;
                    audioSource2.volume = sound_Book_volume;
                    audioSource2.PlayOneShot(sound_Book);
                    gimicJudgment = false;
                }
            }
            if (clickedGameObject.tag == "Voice")
            {
                if (voiceon == true)
                {
                    if (VoiceJudment == true)
                    {
                        LogSystemScript.VoiceLog += 1;
                        VoiceJudment = false;
                    }


                    if (SystemScript.japan == false)
                    {
                        audioSource2.volume = sound_English_volume;
                        audioSource2.PlayOneShot(sound1);
                        voiceon = false;
                        GameObject.Find("Voiceicon").GetComponent<Renderer>().material.color = Color.white;
                        return;
                    }
                    if (SystemScript.japan == true)
                    {
                        audioSource2.volume = sound_japanese_volume;
                        audioSource2.PlayOneShot(sound1_2);
                        voiceon = false;
                        GameObject.Find("Voiceicon").GetComponent<Renderer>().material.color = Color.white;
                        return;
                    }
                }
                if (voiceon == false)
                {
                    VoiceJudment = true;
                    audioSource2.Stop();
                    voiceon = true;
                    GameObject.Find("Voiceicon").GetComponent<Renderer>().material.color = Color.gray;
                    return;
                }


            }

            if (clickedGameObject.tag == "Text")
            {
                GameObject cube2 = GameObject.Find("Texter");
                GameObject cube3 = GameObject.Find("Navi");
                GameObject cube4 = GameObject.Find("Navi_1");
                if (texton2 == true)
                {
                    if (TextJudment == true)
                    {
                        audioSource2.volume = sound_Book_volume;
                        audioSource2.PlayOneShot(sound_Book);
                        LogSystemScript.TextLog += 1;
                        worksmode2 = false;
                        TextJudment = false;

                    }
                    cube3.GetComponent<Canvas>().enabled = true;
                    cube2.GetComponent<Canvas>().enabled = true;
                    cube4.GetComponent<Canvas>().enabled = false;
                    TouchTextScript.count = 0;
                    GameObject.Find("Texton").GetComponent<Renderer>().material.color = Color.white;
                    texton2 = false;

                    return;
                }
                if (texton2 == false)
                {
                    TextJudment = true;
                    cube2.GetComponent<Canvas>().enabled = false;
                    cube3.GetComponent<Canvas>().enabled = false;
                    cube4.GetComponent<Canvas>().enabled = true;
                    GameObject.Find("Texton").GetComponent<Renderer>().material.color = Color.gray;
                    texton2 = true;
                    audioSource2.volume = sound_Book_volume;
                    audioSource2.PlayOneShot(sound_Book);
                    return;
                }

            }


            if (clickedGameObject.tag == "laungage")
            {
                if (laungageJudment == true)
                {
                    LogSystemScript.LaungageLog += 1;
                    laungageJudment = false;
                }
                GameObject cube3 = GameObject.Find("JapaneseMode");
                GameObject cube4 = GameObject.Find("EnglishMode");
                if (laungageon2 == true)
                {
                    GameObject.Find("laungageon").GetComponent<Renderer>().material.color = Color.white;

                    
                    cube3.GetComponent<Canvas>().enabled = true;
                    cube4.GetComponent<Canvas>().enabled = true;
                    laungageon2 = false;
                    return;


                }

                if (laungageon2 == false)
                {
                    laungageJudment = true;
                    GameObject.Find("laungageon").GetComponent<Renderer>().material.color = Color.gray;
                    cube3.GetComponent<Canvas>().enabled = false;
                    cube4.GetComponent<Canvas>().enabled = false;
                    laungageon2 = true;
                    return;


                }
            }

            if (clickedGameObject.tag == "Back")
            {
                if (SceneManager.GetActiveScene().name == "AR_Main")
                {
                    SceneManager.LoadScene("AR_Main");
                }
                else if (SceneManager.GetActiveScene().name == "AR_Main2")
                {
                    SceneManager.LoadScene("AR_Main2");
                }
            }

            /*
            if (clickedGameObject.tag == "Wave")
            {

                if (gimic2judment == true)
                {
                    GameObject cube7 = GameObject.Find("particle_1");
                    GameObject cube8 = GameObject.Find("particle_2");
                    cube7.GetComponent<ParticleSystem>().Play();
                    cube8.GetComponent<ParticleSystem>().Play();
                    LogSystemScript.GimicLog++;
                    gimic2judment = false;

                }
            }*/


        }
    }


    public void Japanese()
    {
        GameObject cube7 = GameObject.Find("Worktext2");
        GameObject cube8 = GameObject.Find("Workmode2");
        if (MaterialChangeScript.i == 0)
        {
            cube7.GetComponent<Text>().text = "凱風快晴";
        }
        if (MaterialChangeScript.i == 1)
        {
            cube7.GetComponent<Text>().text = "山下白雨";
        }
        if (MaterialChangeScript.i == 2)
        {
            cube7.GetComponent<Text>().text = "尾州不二見原";
        }
        cube8.GetComponent<Text>().text = "戻る";

        GameObject cube5 = GameObject.Find("GuideText");
        GameObject cube6 = GameObject.Find("Gohotext1");

        cube5.GetComponent<Text>().text = "葛飾北斎の代表作品集『富嶽三十六景』、全46種類のうちの1つである。当時流行していたプルシャンブルーを用いており、美しい色合いが人々の関心を引き起こした。高く波打つ海と揉まれる舟、その奥に静かに佇む富士山に構成から、動と静、近と遠の鮮明な対比がこの図の主要なテーマとなっております。また、画家・ゴッホは弟テオに宛てた手紙でこの画を激賞しました。";
        cube6.GetComponent<Text>().text = "僕は『一茎の草』と『ナデシコ』の素描、そして北斎がすばらしいと思う。これこそ－－かくも単純で、あたかも己れ自身が花であるかのごとく自然のなかに生きるこれらの日本人がわれわれに教えてくれることこそもうほとんど新しい宗教ではあるまいか。\n\nゴッホより";
    }
    public void English()
    {
        GameObject cube7 = GameObject.Find("Worktext2");
        GameObject cube8 = GameObject.Find("Workmode2");

        if (MaterialChangeScript.i == 0)
        {
            cube7.GetComponent<Text>().text = "Fine Wind, Clear Morning";
        }
        if (MaterialChangeScript.i == 1)
        {
            cube7.GetComponent<Text>().text = "Thunderstorm Beneath the Summit";
        }
        if (MaterialChangeScript.i == 2)
        {
            cube7.GetComponent<Text>().text = "Bishu Fujimigara";
        }
        cube8.GetComponent<Text>().text = "back";

        GameObject cube5 = GameObject.Find("GuideText");
        GameObject cube6 = GameObject.Find("Gohotext1");

        cube5.GetComponent<Text>().text = "This is one of 46 types of Katsushika Hokusai's representative work collection\"Thirty - six Views of Mt.Fuji\"Using the Pursian blue that was popular at the time, the beautiful shades attracted people's attention.  The main theme of this figure is the vivid contrast between movement and stillness, and near and far, from the composition of the high rippling sea, the boat being rubbed, and Mt. Fuji quietly standing behind it. In addition, the painter Van Gogh praised this painting in a letter to his younger brother Theo.";
        cube6.GetComponent<Text>().text = "I think the drawings of\"OneStemGrass\"and\"Nadeshiko\"and Hokusai are wonderful.This is so simple-isn't it almost a new religion that these Japanese people, who live in nature as if they were flowers themselves, teach us?\n\nVan Goho";
    }
}
