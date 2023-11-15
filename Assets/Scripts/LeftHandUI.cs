using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftHandUI : MonoBehaviour
{
    public FurnitureSpawner furnitureSpawner;
    
    private int furnitureIndex = 0;
    private Image itemImage;
    private int IndexSelectingDelayFrame = 30;//과도하게 index가 스위칭되는 현상해결용 해당 프레임수가 지나야지 다음 인풋 허용
    private int FrameCounter = 0;
    public int GetFurnitureIndex()
    {
        return furnitureIndex;
    }

    private void Start()
    {
        FrameCounter = IndexSelectingDelayFrame;
        Image[] images = GetComponentsInChildren<Image>();
        foreach(var image in images)
        {
            if(image.gameObject.name == "Item")
            {
                itemImage = image;
                break;
            }
        }
    }
    private void Update()
    {
        FrameCounter--;
        Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);//left stick
        if(thumbstick.x < 0 && FrameCounter < 0)
        {//left stick input process
            furnitureIndex--;
            if (furnitureIndex == -1)
                furnitureIndex = (furnitureSpawner.GetFurnitureNum()-1);
            FrameCounter = IndexSelectingDelayFrame;
        }
        else if(thumbstick.x > 0 && FrameCounter < 0)
        {//right stick input process
            furnitureIndex = (furnitureIndex + 1) % furnitureSpawner.GetFurnitureNum();
            FrameCounter = IndexSelectingDelayFrame;
        }
        UpdateItemImage();
    }
    private void UpdateItemImage()
    {
        itemImage.sprite = furnitureSpawner.GetFurnitureSprite(furnitureIndex);
    }
}
