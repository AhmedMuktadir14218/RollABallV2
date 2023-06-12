using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; /// Player GameObject position

    private Vector3 offset; /// Store offset values

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; /// Calculate offset values
    }

    /// LateUpdate also works like Update 
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}