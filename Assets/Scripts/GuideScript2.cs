using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuideScript2 : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {


    }

    
    public void back()
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
