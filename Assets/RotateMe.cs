using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour {

    [SerializeField] public Transform aroundWho;
    [SerializeField] public float angleSpeed;

    Vector3 offset = new Vector3 ();
    Vector3 initialPosition;

    void Start () {
        initialPosition = transform.position;
    }

    void Update () {
        if (aroundWho == null) return;
        transform.RotateAround (aroundWho.position, Vector3.up, angleSpeed * Time.deltaTime);
        transform.LookAt (aroundWho);

        //   angle += 1f * Time.deltaTime;
    }
}