using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FurnitureLocator : MonoBehaviour
{
    public GameObject[] Furnitures;//��ġ�� ���� Prefab �迭
    private int CurrentFurnitureIndex = 0;//��ġ�� ������ Index
    private LocationPointingIndicator LocationIndicator;

    private void Start()
    {
        LocationIndicator = FindObjectOfType<LocationPointingIndicator>();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {//��ġ �߻� �� 
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {//��ġ �����Ҷ�
                TouchEvent();
            }
        }
    }
    private void TouchEvent()
    {
        Vector3 furniturePosition = LocationIndicator.GetIndicatorPosition();
        Quaternion furnitureRotation = LocationIndicator.GetIndicatorRotation();
        GameObject furniture = Instantiate(Furnitures[CurrentFurnitureIndex], furniturePosition, furnitureRotation);//��ġ�ϱ�
        furniture.AddComponent<ARAnchor>();
    }

}
