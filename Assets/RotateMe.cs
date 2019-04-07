using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour
{

    public Transform aroundWho;
    public float angleSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(aroundWho.position, Vector3.up, angleSpeed);
        transform.LookAt(aroundWho);
     //   angle += 1f * Time.deltaTime;
    }
}
