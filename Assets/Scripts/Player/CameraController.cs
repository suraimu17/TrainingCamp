using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController playercontroller;
    [SerializeField] private float startPosY;
    [SerializeField] private float endPosY;

    private Transform playertransform;

    // Update is called once per frame
    private void Update()
    {
        playertransform = playercontroller.transform;

        if (playertransform == null||playertransform.position.y<=startPosY||playertransform.position.y>=endPosY)
        {
            return;
        }

        transform.position = new Vector3(transform.position.x, playertransform.position.y, transform.position.z);
    }
}
