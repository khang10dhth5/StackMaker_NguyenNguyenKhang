using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow :Singleton<CameraFollow>
{
    public Transform target;
    public Vector3 offset;
    public float moveSpeed=10;
    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, moveSpeed * Time.deltaTime);
            transform.LookAt(target);

        }
    }
}
