using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    GameObject player;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Santa");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;

    }
}
