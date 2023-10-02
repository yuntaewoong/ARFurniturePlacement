using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LocationPointingIndicator : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private GameObject pointerImageObject;

    private void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        if(transform.childCount == 0)
        {
            Debug.LogError("LocationPointingIndicator Must be have child");
            return;
        }
        pointerImageObject = transform.GetChild(0).gameObject;
        pointerImageObject.SetActive(false);
    }
    private void Update()
    {
        List<ARRaycastHit> raycastHitList = new List<ARRaycastHit>();
        raycastManager.Raycast(
            new Vector2(Screen.width / 2, Screen.height / 2),
            raycastHitList, 
            UnityEngine.XR.ARSubsystems.TrackableType.Planes
        );//AR Plane과 충돌 처리
        if(raycastHitList.Count > 0)
        {
            if(!pointerImageObject.activeInHierarchy)
            {
                pointerImageObject.SetActive(true);
            }
            transform.position = raycastHitList[0].pose.position;
            transform.rotation = raycastHitList[0].pose.rotation;
        }

    }
}
