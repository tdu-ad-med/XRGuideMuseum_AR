using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ARGuideSystemScript : MonoBehaviour
{

    public GameObject laungages;
    public GameObject voiceGuide;
    public GameObject textGuide;
    public GameObject laungageGuide;

    AudioSource audioSource2;
    public AudioClip sound1;
    public AudioClip sound1_2;

    bool voiceon = true;
    bool texton = true;


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

        audioSource2 = GetComponent<AudioSource>();

        if(SystemScript.japan == true)
        {
            Japansese();
        }
        if (SystemScript.japan == false)
        {
            English();
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Texter()
    {
        LogSystemScript.TextLog++;
        
        GameObject cube2 = GameObject.Find("Texter");
        if (texton == true)
        {
            cube2.GetComponent<Canvas>().enabled = true;
            texton = false;
            return;
        }
        if(texton == false)
        {
            cube2.GetComponent<Canvas>().enabled = false;
            texton = true;
            return;
        }

    }

    public void Voice()
    {
        LogSystemScript.VoiceLog += 1;
        if (voiceon == true)
        {
            if (SystemScript.japan == false)
            {
                audioSource2.volume = 0.5f;
                audioSource2.PlayOneShot(sound1);
                voiceon = false;
                voiceGuide.GetComponent<Image>().color = Color.white;
                return;
            }
            if (SystemScript.japan == true)
            {
                audioSource2.volume = 1.0f;
                audioSource2.PlayOneShot(sound1_2);
                voiceon = false;
                voiceGuide.GetComponent<Image>().color = Color.white;
                return;
            }
        }
        if (voiceon == false)
        {
            audioSource2.Stop();
            voiceon = true;
            voiceGuide.GetComponent<Image>().color = Color.gray;
            return;
        }
    }

    public void Laungage()
    {
        LogSystemScript.LaungageLog  += 1;
        laungages.GetComponent<Image>().color = Color.white;
        laungageGuide.SetActive(true);
    }

    public void Japansese()
    {
        GameObject cube = GameObject.Find("Text");
        cube.GetComponent<Text>().text = "サン＝レミのサン＝ポール療養院にゴッホが入院しているときに、窓から見える村の風景を描いたもの.天と地を接続している糸杉は、一般的に天国と関連して、死の架け橋の象徴とみなされている.また,ゴッホの過去の記憶がコラージュ的に表現されており現実的風景ではない.";
        SystemScript.japan = true;
        laungages.GetComponent<Image>().color = Color.gray;
        laungageGuide.SetActive(false);
        
    }

    public void English()
    {
        GameObject cube = GameObject.Find("Text");
        cube.GetComponent<Text>().text = "A picture of the village landscape seen through a window when Van Gogh was admitted to the Saint-Paul sanatorium in Saint-Remy. The cypress that connects heaven and earth is generally associated with heaven and died. It is regarded as a symbol of the bridge, and Van Gogh's past memories are expressed in a collage, which is not a realistic landscape.";
        SystemScript.japan = false;
        laungages.GetComponent<Image>().color = Color.gray;
        laungageGuide.SetActive(false);

    }

    public void Return()
    {
        SceneManager.LoadScene("AR_Main");
    }

}
