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


    static public bool texton2 = true;
    static public bool laungageon2 = true;
    static public bool worksmode2 = false;

    AudioSource audioSource2;

    [Header("ガイドボイス")]
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
    bool gimic2judment = true;
    bool communicatejudment = true;

    //音量調節
    float sound_Book_volume = 0.5f;
    //float sound_moon_volume = 1.0f;

    public Material mat1;//再生ボタン
    public Material mat2;//停止ボタン

    private Coroutine _currentCoroutine;

    [Header("時間計測")]
    static public bool timer_HokusaiMOvieJudgment = false;
    static public bool timer_HokusaiAnotherWorkjudgment = false;
    static public bool timer_HokusaiCommunicationjudgment = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource2 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount <= 0) return;

        var touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            // rayを照射
            var ray = arCamera.ScreenPointToRay(touch.position);


            RaycastHit hit = new RaycastHit();
            clickedGameObject = null;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    clickedGameObject = hit.collider.gameObject;
                }
            }


            if (hit.collider != null && clickedGameObject.tag == "Works")
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
                    LogSystemScript.VoiceLog++;
                    timer_HokusaiAnotherWorkjudgment = true;
                    worksmode2 = true;
                    laungageon2 = true;
                    texton2 = true;
                    return;
                }


            }
            if (hit.collider != null && clickedGameObject.tag == "Workmode")
            {
                GameObject cube5 = GameObject.Find("Worktext_2");
                GameObject cube6 = GameObject.Find("Workmode_2");
                GameObject cube7 = GameObject.Find("WorkMove");
                cube6.GetComponent<Canvas>().enabled = false;
                cube5.GetComponent<Canvas>().enabled = false;
                cube7.GetComponent<Canvas>().enabled = false;
        
                audioSource2.volume = sound_Book_volume;
                audioSource2.PlayOneShot(sound_Book);
                timer_HokusaiAnotherWorkjudgment = false;
                Debug.Log("北斎の他の作品の鑑賞時間" + GohoTimerScript.timer_HokusaiAnotherWork.ToString("f0") + "秒");
                GohoTimerScript.timer_HokusaiAnotherWork = 0;
                worksmode2 = false;

                return;
            }

            if (hit.collider != null && clickedGameObject.tag == "Wave")
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

            if (hit.collider != null && clickedGameObject.tag == "Brother")
            {
                if (gimicJudgment == true)
                {
                    GameObject cube5 = GameObject.Find("Gohotext");
                    cube5.GetComponent<Canvas>().enabled = true;
                    GameObject cube6 = GameObject.Find("letter");
                    cube6.GetComponent<Canvas>().enabled = true;
                    audioSource2.volume = sound_Book_volume;
                    audioSource2.PlayOneShot(sound_Book);
                    GameObject cube7 = GameObject.Find("Gohotext1");
                    if (SystemScript.japan == true)
                    {
                        
                        cube7.GetComponent<Text>().text = "僕は『一茎の草』と『ナデシコ』の素描、そして北斎がすばらしいと思う。これこそ－－かくも単純で、あたかも己れ自身が花であるかのごとく自然のなかに生きるこれらの日本人がわれわれに教えてくれることこそもうほとんど新しい宗教ではあるまいか。\n\nゴッホより";
                    }
                    if(SystemScript.japan == false)
                    {
                        cube7.GetComponent<Text>().text = "I think the drawings of\"OneStemGrass\"and\"Nadeshiko\"and Hokusai are wonderful.This is so simple-isn't it almost a new religion that these Japanese people, who live in nature as if they were flowers themselves, teach us?\n\nVan Goho";
                    }
                    LogSystemScript.WindowLog++;
                    gimicJudgment = false;
                }
            }

            if (hit.collider != null && clickedGameObject.tag == "Voice")
            {
                GameObject cube30 = GameObject.Find("ReplayButon2");
                GameObject cube31 = GameObject.Find("AR_back3");
                GameObject cube32 = GameObject.Find("CommentGroup2");
                GameObject cube33 = GameObject.Find("chattext");
                GameObject cube37 = GameObject.Find("Cloud_image");
                GameObject cube34 = GameObject.Find("CommunicationButton2");
                GameObject cube35 = GameObject.Find("Editor2");
                GameObject cube36 = GameObject.Find("Back_2_2");

                if (communicatejudment == true)
                {
                    cube30.GetComponent<Renderer>().enabled = false;
                    cube31.GetComponent<Renderer>().enabled = false;
                    cube32.GetComponent<Canvas>().enabled = true;
                    cube34.GetComponent<Renderer>().enabled = false;
                    cube35.GetComponent<Renderer>().enabled = true;
                    cube36.GetComponent<Renderer>().enabled = true;
                    LogSystemScript.CommunicationLog++;
                    timer_HokusaiCommunicationjudgment = true;

                    if (InputTextScript.CommentStart == true)
                    {
                        cube37.GetComponent<Image>().enabled = true;
                        cube33.GetComponent<Text>().text = InputTextScript.CommentSave2;
                    }
                    communicatejudment = false;
                    return;
                }


            }
            if (hit.collider != null && clickedGameObject.tag == "Back2")
            {
                GameObject cube30 = GameObject.Find("ReplayButon2");
                GameObject cube31 = GameObject.Find("AR_back3");
                GameObject cube32 = GameObject.Find("CommentGroup2");
                GameObject cube34 = GameObject.Find("CommunicationButton2");
                GameObject cube35 = GameObject.Find("Editor2");
                GameObject cube36 = GameObject.Find("Back_2_2");
                cube30.GetComponent<Renderer>().enabled = true;
                cube31.GetComponent<Renderer>().enabled = true;
                cube32.GetComponent<Canvas>().enabled = false;
                cube34.GetComponent<Renderer>().enabled = true;
                cube35.GetComponent<Renderer>().enabled = false;
                cube36.GetComponent<Renderer>().enabled = false;
                communicatejudment = true;
                timer_HokusaiCommunicationjudgment = false;
                Debug.Log("北斎のコミュニケーションツールを閲覧した時間" + GohoTimerScript.timer_HokusaiCommunication.ToString("f0") + "秒");
                GohoTimerScript.timer_HokusaiCommunication = 0;
            }
            if (hit.collider != null && clickedGameObject.tag == "Editor")
            {
                SceneManager.LoadScene("Communication");
            }


            if (hit.collider != null && clickedGameObject.tag == "Text")
            {
                GameObject cube2 = GameObject.Find("Texter");
                GameObject cube10 = GameObject.Find("ReplayButon2");
                GameObject cube11 = GameObject.Find("AR_back3");
                GameObject cube13 = GameObject.Find("CommunicationButton2");
                GameObject cube21 = GameObject.Find("Animation_1");
                GameObject cube22 = GameObject.Find("Animation_2");
                GameObject cube23 = GameObject.Find("Animation_3");
                GameObject cube24 = GameObject.Find("Animation_4");
                GameObject cube25 = GameObject.Find("Animation_5");
                GameObject cube26 = GameObject.Find("Animation_6");
                GameObject cube27 = GameObject.Find("Animation_Mail");

                if (texton2 == true)
                {
                    if (TextJudment == true)
                    {
                        
                        worksmode2 = false;
                        TextJudment = false;

                    }

                    LogSystemScript.TextLog += 1;
                    cube2.GetComponent<Canvas>().enabled = true;
                    cube10.GetComponent<Renderer>().material = mat2;
                    cube11.GetComponent<Renderer>().enabled = false;
                    cube13.GetComponent<Renderer>().enabled = false;
                    audioSource2.PlayOneShot(sound1_2);
                    timer_HokusaiMOvieJudgment = true;
                    if (_currentCoroutine == null)
                    {
                        _currentCoroutine = StartCoroutine(HokusaiGuide());

                    }
                    LogSystemScript.TextLog += 1;
                    laungageon2 = true;
                    texton2 = false;
        
                    return;
                }
                if (texton2 == false)
                {
                    cube21.GetComponent<Canvas>().enabled = false;
                    cube22.GetComponent<Renderer>().enabled = false;
                    cube23.GetComponent<Canvas>().enabled = false;
                    cube24.GetComponent<Canvas>().enabled = false;
                    cube25.GetComponent<Canvas>().enabled = false;
                    cube26.GetComponent<Canvas>().enabled = false;
                    cube27.GetComponent<Animator>().SetBool("HokusaiMailAnimationStart", false);

                    TextJudment = true;
                    cube2.GetComponent<Canvas>().enabled = false;
                    cube11.GetComponent<Renderer>().enabled = true;
                    cube10.GetComponent<Renderer>().material = mat1;
                    cube13.GetComponent<Renderer>().enabled = true;
                    audioSource2.Stop();
                    timer_HokusaiMOvieJudgment = false;
                    Debug.Log("北斎のガイド鑑賞時間" + GohoTimerScript.timer_HokusaiMovie.ToString("f0") + "秒");
                    GohoTimerScript.timer_HokusaiMovie = 0;


                    if (_currentCoroutine != null)
                    {
                        // 実行中のコルーチンを停止（破棄）
                        StopCoroutine(_currentCoroutine);
                        _currentCoroutine = null;
                    }

                    texton2 = true;
                    return;
                }

            }

            if (hit.collider != null && clickedGameObject.tag == "Back")
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

        }
    }

    IEnumerator HokusaiGuide()
    {
        GameObject cube20 = GameObject.Find("Texter2");
        GameObject cube21 = GameObject.Find("Animation_1");
        GameObject cube22 = GameObject.Find("Animation_2");
        GameObject cube23 = GameObject.Find("Animation_3");
        GameObject cube24 = GameObject.Find("Animation_4");
        GameObject cube25 = GameObject.Find("Animation_5");
        GameObject cube26 = GameObject.Find("Animation_6");
        GameObject cube27 = GameObject.Find("Animation_Mail");

        cube20.GetComponent<Text>().text = "神奈川沖浪裏\n北斎";
        yield return new WaitForSeconds(5);

        cube21.GetComponent<Canvas>().enabled = true;
        cube20.GetComponent<Text>().text = "この作品は、葛飾北斎の代表作品集\n「富嶽三十六景」全４６種類のうちの\n１つです";
        yield return new WaitForSeconds(12);

        cube21.GetComponent<Canvas>().enabled = false;
        cube22.GetComponent<Renderer>().enabled = true;
        cube20.GetComponent<Text>().text = "また、当時流行していたプルシャンブルーを用いており、美しい色合いが、人々の関心を引き起こしました";
        yield return new WaitForSeconds(11);

        cube22.GetComponent<Renderer>().enabled = false;
        cube23.GetComponent<Canvas>().enabled = true;
        cube20.GetComponent<Text>().text = "実際の絵画を見てみましょう\n(実物と見比べましょう)";
        yield return new WaitForSeconds(5);

        cube23.GetComponent<Canvas>().enabled = false;
        cube24.GetComponent<Canvas>().enabled = true;
        cube20.GetComponent<Text>().text = "高く波打つ海と揉まれる船、その奥に静かに佇む富士山に、構成から";
        yield return new WaitForSeconds(7);

        cube25.GetComponent<Canvas>().enabled = true;
        cube20.GetComponent<Text>().text = "動と静、近と遠の鮮明な対比がこの図の主要なテーマとなっております";
        yield return new WaitForSeconds(10);

        cube24.GetComponent<Canvas>().enabled = false;
        cube25.GetComponent<Canvas>().enabled = false;
        cube26.GetComponent<Canvas>().enabled = true;
        cube27.GetComponent<Animator>().SetBool("HokusaiMailAnimationStart", true);
        cube20.GetComponent<Text>().text = "また、画家のゴッホは、弟テオに宛てた手紙でこの画、そして葛飾北斎を\n激賞しました";
        yield return new WaitForSeconds(15);

        cube26.GetComponent<Canvas>().enabled = false;
        cube27.GetComponent<Animator>().SetBool("HokusaiMailAnimationStart", false);


        GameObject cube2 = GameObject.Find("Texter");
        GameObject cube10 = GameObject.Find("ReplayButon2");
        GameObject cube11 = GameObject.Find("AR_back3");
        GameObject cube34 = GameObject.Find("CommunicationButton2");
        TextJudment = true;
        cube2.GetComponent<Canvas>().enabled = false;
        cube11.GetComponent<Renderer>().enabled = true;
        cube10.GetComponent<Renderer>().material = mat1;
        cube34.GetComponent<Renderer>().enabled = true;
        audioSource2.Stop();
        timer_HokusaiMOvieJudgment = false;
        Debug.Log("北斎のガイド鑑賞時間" + GohoTimerScript.timer_HokusaiMovie.ToString("f0") + "秒");
        GohoTimerScript.timer_HokusaiMovie = 0;
        texton2 = true;
        if (_currentCoroutine != null)
        {
            // 実行中のコルーチンを停止（破棄）
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }
        yield break;
    }

}
