using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{//UI ΩÃ±€≈Ê ∏≈¥œ¿˙
    private static UIManager instance;
    private int currentFurnitureIndex = -1;
    private bool toggleSelected = false;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static UIManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }
    
    public bool IsAnyToggleSelected()
    {
        return toggleSelected;
    }
    public void SetAnyToggleSelected(bool isSelected)
    {
        toggleSelected = isSelected;
    }

    public int GetCurrentFurnitureIndex()
    {
        return currentFurnitureIndex;
    }
    public void SetCurrentFurnitureIndex(int value)
    {
        currentFurnitureIndex = value;
    }
}