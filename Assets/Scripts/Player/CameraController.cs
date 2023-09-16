using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController playercontroller;
    private Transform playertransform;
    // Start is called before the first frame update
    void Start()
    {
        playertransform = playercontroller.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if(playertransform == null)
        {
            return;
        }

        transform.position = new Vector3(transform.position.x, playertransform.position.y, transform.position.z);
    }
}
