using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FurnitureLocator : MonoBehaviour
{
    public GameObject[] Furnitures;//배치할 가구 Prefab 배열
    private LocationPointingIndicator LocationIndicator;

    private void Start()
    {
        LocationIndicator = FindObjectOfType<LocationPointingIndicator>();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {//터치 발생 시 
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {//터치 시작할때
                if(touch.position.y > 200)
                {
                    TouchEvent();
                    UIManager.Instance.SetAnyToggleSelected(false);
                }
            }
        }
    }
    private void TouchEvent()
    {
        if(!UIManager.Instance.IsAnyToggleSelected())
        {//모든 토글이 꺼져잇다면 아무것도 하지 않는다
            return;
        }
        Vector3 furniturePosition = LocationIndicator.GetIndicatorPosition();
        Quaternion furnitureRotation = LocationIndicator.GetIndicatorRotation();
        GameObject furniture = Instantiate(
            Furnitures[UIManager.Instance.GetCurrentFurnitureIndex()],
            furniturePosition, 
            furnitureRotation
        );//배치하기
        furniture.AddComponent<ARAnchor>();
    }

}
