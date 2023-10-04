using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FurnitureLocator : MonoBehaviour
{
    public GameObject[] Furnitures;//��ġ�� ���� Prefab �迭
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
        {//��� ����� �����մٸ� �ƹ��͵� ���� �ʴ´�
            return;
        }
        Vector3 furniturePosition = LocationIndicator.GetIndicatorPosition();
        Quaternion furnitureRotation = LocationIndicator.GetIndicatorRotation();
        GameObject furniture = Instantiate(
            Furnitures[UIManager.Instance.GetCurrentFurnitureIndex()],
            furniturePosition, 
            furnitureRotation
        );//��ġ�ϱ�
        furniture.AddComponent<ARAnchor>();
    }

}
