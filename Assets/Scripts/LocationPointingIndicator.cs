using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LocationPointingIndicator : MonoBehaviour
{
    private ARRaycastManager RaycastManager;
    private GameObject PointerImageObject;


    public Vector3 GetIndicatorPosition()
    {
        return transform.position;
    }
    public Quaternion GetIndicatorRotation()
    {
        return transform.rotation;
    }


    private void Start()
    {
        RaycastManager = FindObjectOfType<ARRaycastManager>();
        if(transform.childCount == 0)
        {
            Debug.LogError("LocationPointingIndicator Must be have child");
            return;
        }
        PointerImageObject = transform.GetChild(0).gameObject;
        PointerImageObject.SetActive(false);
    }
    private void Update()
    {
        List<ARRaycastHit> raycastHitList = new List<ARRaycastHit>();
        RaycastManager.Raycast(
            new Vector2(Screen.width / 2, Screen.height / 2),
            raycastHitList, 
            UnityEngine.XR.ARSubsystems.TrackableType.Planes
        );//AR Plane과 충돌 처리(Screen 중앙 -> AR Plane 검출)
        if(raycastHitList.Count > 0)
        {
            if(!PointerImageObject.activeInHierarchy)
            {
                PointerImageObject.SetActive(true);
            }
            transform.position = raycastHitList[0].pose.position;
            transform.rotation = raycastHitList[0].pose.rotation;
        }

    }
}
