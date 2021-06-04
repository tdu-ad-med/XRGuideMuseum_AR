using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JairoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, -180) * Quaternion.Euler(-90, 0, 0) * Input.gyro.attitude * Quaternion.Euler(0, 0, 180);
    }
    public void back()
    {
        if (SceneManager.GetActiveScene().name == "Gohho_World")
        {
            SceneManager.LoadScene("Gohho_Room");
        }
        else
        {
            SceneManager.LoadScene("AR_Main");
        }
    }
}
