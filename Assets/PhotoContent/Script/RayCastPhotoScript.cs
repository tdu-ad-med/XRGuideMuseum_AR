using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class RayCastPhotoScript : MonoBehaviour
{
    GameObject clickedGameObject = null;

    //[SerializeField] private GameObject placementPrefab;
    [Header("AR System")]
    [SerializeField] private Camera arCamera;
    [SerializeField] private ARRaycastManager raycastManager;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();


    private Vector3 moveTo;

    private bool beRay = false;

    Vector3 mousePos;


    //private Vector3 MoveTo2;

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {

        if (PhotoScript.ObjectMovemode == true)
        {

            if (Input.GetMouseButtonUp(0))
            {

                beRay = false;

            }

            if (Input.GetMouseButtonDown(0))
            {
                RayCheck();
            }

            if (beRay == true)
            {
                MovePoisition();
            }

        }

        if (PhotoScript.EraserMode == true)
        {

            if (Input.GetMouseButtonDown(0))
            {
                RayCheck2();

            }
        }

    }
    private void RayCheck()
    {
        if (Input.touchCount == 1 && PhotoScript.ObjectMovemode == true)
        {
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = arCamera.ScreenPointToRay(Input.mousePosition);
        

            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                if (hit.collider != null)
                {
                    clickedGameObject = hit.collider.gameObject;
                    beRay = true;
                }
            }

        }

    }
    private void MovePoisition()
    {
        if (Input.touchCount == 1 && PhotoScript.ObjectMovemode == true)
        {

            mousePos = Input.mousePosition;
            mousePos.z = 0.5f;//数値が大きいほど遠い
            moveTo = arCamera.ScreenToWorldPoint(mousePos);
            clickedGameObject.transform.position = moveTo;
            //Debug.Log("x"+ clickedGameObject.transform.position.x+"y"+ clickedGameObject.transform.position.y);

        }


    }

    private void RayCheck2()
    {
        if (Input.touchCount == 1 && PhotoScript.EraserMode == true)
        {

            Ray ray2 = new Ray();
            RaycastHit hit2 = new RaycastHit();
            ray2 = arCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray2.origin, ray2.direction, out hit2, Mathf.Infinity))
            {
                if (hit2.collider != null)
                {
                    Destroy(hit2.collider.gameObject);
                    
                }
            }

        }



    }
}
