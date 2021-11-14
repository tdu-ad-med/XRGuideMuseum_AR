using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GohoTimerScript : MonoBehaviour
{
    static public float timer_GohoMovie = 0;
    static public float timer_GohoAnotherWork = 0;
    static public float timer_HokusaiMovie = 0;
    static public float timer_HokusaiAnotherWork = 0;
    static public float timer_GohoCommunication = 0;
    static public float timer_HokusaiCommunication = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RayCastMainScript.timer_GohoMOvieJudgment == true)
        {
            timer_GohoMovie += Time.deltaTime;
        }

        if (RayCastMainScript.timer_GohoAnotherWorkjudgment == true)
        {
            timer_GohoAnotherWork += Time.deltaTime;
        }

        if (RayCastScript2.timer_HokusaiMOvieJudgment == true)
        {
            timer_HokusaiMovie += Time.deltaTime;
        }

        if (RayCastScript2.timer_HokusaiAnotherWorkjudgment == true)
        {
            timer_HokusaiAnotherWork += Time.deltaTime;
        }

        if (RayCastMainScript.timer_GohoCommunicationjudgment == true)
        {
            timer_GohoCommunication += Time.deltaTime;
        }

        if (RayCastScript2.timer_HokusaiCommunicationjudgment == true)
        {
            timer_HokusaiCommunication += Time.deltaTime;
        }

    }
}
