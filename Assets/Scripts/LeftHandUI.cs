using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftHandUI : MonoBehaviour
{
    public FurnitureSpawner furnitureSpawner;
    
    private int furnitureIndex = 0;
    private Image itemImage;

    public int GetFurnitureIndex()
    {
        return furnitureIndex;
    }

    private void Start()
    {
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
        if(OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
        {
            Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);//left stick
            if(thumbstick.x < 0)
            {//left stick input process
                furnitureIndex = (furnitureIndex - 1) % furnitureSpawner.GetFurnitureNum();
            }
            else if(thumbstick.x > 0)
            {//right stick input process
                furnitureIndex = (furnitureIndex + 1) % furnitureSpawner.GetFurnitureNum();
            }
        }
        UpdateItemImage();
    }
    private void UpdateItemImage()
    {
        itemImage.sprite = furnitureSpawner.GetFurnitureSprite(furnitureIndex);
    }
}
