// Copyright (c) Meta Platforms, Inc. and affiliates.

using Phanto.Audio.Scripts;
using Phanto.Enemies.DebugScripts;
using PhantoUtils;
using UnityEngine;
using Utilities.XR;
using System.Collections.Generic;

public class FurnitureSpawner : MonoBehaviour
{
    [SerializeField] private LeftHandUI leftHandUI;
    [SerializeField] private GameObject[] furniturePrefabs;
    [SerializeField] private GameObject[] furniturePreviewPrefabs;
    [SerializeField] private Sprite[] furnitureSprites;
    [SerializeField] private LayerMask meshLayerMask;

    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;


    [SerializeField] private PhantoRandomOneshotSfxBehavior placeDownSFX;
    [SerializeField] private PhantoRandomOneshotSfxBehavior pickUpSFX;

    private OVRInput.Controller _activeController = OVRInput.Controller.RTouch;

    private List<GameObject> _furnitures = new List<GameObject>();
    private List<GameObject> _furniturePreviews = new List<GameObject>();

    private List<bool> _isPlaceds = new List<bool>();

    private (Vector3 point, Vector3 normal, bool hit) _leftHandHit;
    private (Vector3 point, Vector3 normal, bool hit) _rightHandHit;


    public int GetFurnitureNum()
    {
        return furniturePrefabs.Length;
    }
    public Sprite GetFurnitureSprite(int index)
    {
        return furnitureSprites[index];
    }



    private void Start()
    {
        for(int i = 0;i<furniturePrefabs.Length;i++)
        {
            _furnitures.Add(Instantiate(furniturePrefabs[i], transform));
            _furnitures[i].SetActive(false);

            _furniturePreviews.Add(Instantiate(furniturePreviewPrefabs[i], transform));
            _furniturePreviews[i].SetActive(false);

            _isPlaceds.Add(false);
        }
        _furniturePreviews[leftHandUI.GetFurnitureIndex()].SetActive(true);
    }

    private void Update()
    {
        var togglePlacement = false;
        const OVRInput.Button buttonMask = OVRInput.Button.PrimaryIndexTrigger | OVRInput.Button.PrimaryHandTrigger;

        if (OVRInput.GetDown(buttonMask, OVRInput.Controller.LTouch))
        {
            _activeController = OVRInput.Controller.LTouch;
            togglePlacement = true;
        }
        else if (OVRInput.GetDown(buttonMask, OVRInput.Controller.RTouch))
        {
            _activeController = OVRInput.Controller.RTouch;
            togglePlacement = true;
        }

        var leftRay = new Ray(leftHand.position, leftHand.forward);
        var rightRay = new Ray(rightHand.position, rightHand.forward);

        var leftRaySuccess = Physics.Raycast(leftRay, out var leftHit, 100.0f, meshLayerMask);
        var rightRaySuccess = Physics.Raycast(rightRay, out var rightHit, 100.0f, meshLayerMask);

        _leftHandHit = (leftHit.point, leftHit.normal, leftRaySuccess);
        _rightHandHit = (rightHit.point, rightHit.normal, rightRaySuccess);
        var active = _activeController == OVRInput.Controller.LTouch ? _leftHandHit : _rightHandHit;

        if (togglePlacement && active.hit) TogglePlacement(active.point, active.normal);

        if (!_isPlaceds[leftHandUI.GetFurnitureIndex()] && active.hit)
        {
            // update the position of the preview to match the raycast.
            var furniturePreviewTransform = _furniturePreviews[leftHandUI.GetFurnitureIndex()].transform;

            furniturePreviewTransform.position = active.point;
            furniturePreviewTransform.up = active.normal;
        }
    }

    private void TogglePlacement(Vector3 point, Vector3 normal)
    {
        if (_isPlaceds[leftHandUI.GetFurnitureIndex()])
        {
            _furnitures[leftHandUI.GetFurnitureIndex()].SetActive(false);
            _furniturePreviews[leftHandUI.GetFurnitureIndex()].SetActive(true);
            pickUpSFX.PlaySfxAtPosition(point);

            _isPlaceds[leftHandUI.GetFurnitureIndex()] = false;
        }
        else
        {
            var furnitureTransform = _furnitures[leftHandUI.GetFurnitureIndex()].transform;
            furnitureTransform.position = point;
            furnitureTransform.up = normal;

            _furnitures[leftHandUI.GetFurnitureIndex()].SetActive(true);
            _furniturePreviews[leftHandUI.GetFurnitureIndex()].SetActive(false);
            placeDownSFX.PlaySfxAtPosition(point);

            _isPlaceds[leftHandUI.GetFurnitureIndex()] = true;
        }
    }

}
