using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuideScript2 : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip sound1;//laungage
    public AudioClip sound1_2;//laungage
    public AudioClip sound2;//GUide
    public AudioClip sound3;//Book

    public GameObject Guide;
    public GameObject laungage;

    bool texteron = true;
    bool voiceon = true;

    //UI部分
    public GameObject voiceGuide;
    public GameObject textGuide;
    public GameObject laungages;

    public Text texter;

    //UI表示非表示の判定
    bool laungageon = true;
    bool textmode = true;

    // Start is called before the first frame update
    void Start()
    {
        if (UIScript.VoiceOn == true)
        {
            voiceGuide.SetActive(true);
        }
        if (UIScript.VoiceOn == false)
        {
            voiceGuide.SetActive(false);
        }

        if (UIScript.TextOn == true)
        {
            textGuide.SetActive(true);
        }
        if (UIScript.TextOn == false)
        {
            textGuide.SetActive(false);
        }

        if (UIScript.LaungageOn == true)
        {
            laungages.SetActive(true);
        }
        if (UIScript.LaungageOn == false)
        {
            laungages.SetActive(false);
        }


        audioSource = GetComponent<AudioSource>();

        if (SystemScript.japan == true)
        {
            Japanese();
            audioSource.Stop();
        }

        if (SystemScript.japan == false)
        {
            English();
            audioSource.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Onclick2()
    {
        if (laungageon == true)
        {
            LogSystemScript.LaungageLog += 1;
            laungage.SetActive(true);
            laungages.GetComponent<Image>().color = Color.white;
            laungageon = false;
            return;
        }
        if (laungageon == false)
        {
            laungage.SetActive(false);
            laungages.GetComponent<Image>().color = Color.gray;
            laungageon = true;
            return;
        }
    }
    public void back()
    {
        if (texteron == true)
        {
            Guide.SetActive(false);
            textGuide.GetComponent<Image>().color = Color.gray;
            texteron = false;
            audioSource.volume = 0.5f;
            audioSource.PlayOneShot(sound3);
            textmode = true;
            return;

        }
        if (texteron == false)
        {
            if (SceneManager.GetActiveScene().name == "AR_Sample")
            {
                SceneManager.LoadScene("AR_Sample2");
            }
            else
            {
                SceneManager.LoadScene("AR_Main");
            }
        }
    }

    public void voice()
    {
        LogSystemScript.VoiceLog += 1;
        if (voiceon == true)
        {
            if (SystemScript.japan == false)
            {
                audioSource.volume = 0.5f;
                audioSource.PlayOneShot(sound2);
            }
            if (SystemScript.japan == true)
            {
                audioSource.volume = 1.0f;
                audioSource.PlayOneShot(sound1_2);

            }
            voiceon = false;
            voiceGuide.GetComponent<Image>().color = Color.white;
            return;
        }
        if (voiceon == false)
        {
            audioSource.Stop();
            voiceon = true;
            voiceGuide.GetComponent<Image>().color = Color.gray;
            return;
        }

    }
    public void Texter()
    {

        if (textmode == true)
        {
            LogSystemScript.TextLog += 1;
            Guide.SetActive(true);
            audioSource.volume = 0.5f;
            audioSource.PlayOneShot(sound3);
            textGuide.GetComponent<Image>().color = Color.white;
            texteron = true;
            textmode = false;
            return;
        }
        if (textmode == false)
        {
            Guide.SetActive(false);
            audioSource.volume = 0.5f;
            audioSource.PlayOneShot(sound3);
            textGuide.GetComponent<Image>().color = Color.gray;
            textmode = true;
            return;
        }

    }

    public void Japanese()
    {
        texter.text = "サン＝レミのサン＝ポール療養院にゴッホが入院しているときに、窓から見える村の風景を描いたもの.天と地を接続している糸杉は、一般的に天国と関連して、死の架け橋の象徴とみなされている.また,ゴッホの過去の記憶がコラージュ的に表現されており現実的風景ではない.";
        SystemScript.japan = true;
        laungages.GetComponent<Image>().color = Color.gray;
        laungage.SetActive(false);
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(sound1);
    }

    public void English()
    {
        texter.text = "A picture of the village landscape seen through a window when Van Gogh was admitted to the Saint-Paul sanatorium in Saint-Remy. The cypress that connects heaven and earth is generally associated with heaven and died. It is regarded as a symbol of the bridge, and Van Gogh's past memories are expressed in a collage, which is not a realistic landscape.";
        SystemScript.japan = false;
        laungages.GetComponent<Image>().color = Color.gray;
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(sound1);

        laungage.SetActive(false);
    }
}
