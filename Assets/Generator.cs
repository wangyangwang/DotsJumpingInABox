using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public GameObject sample;
    public int number = 20;
    public float intialForceMult = 10;


    List<GameObject> dots = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < number; i++)
        {
            Vector3 newPosition = sample.transform.position + RandomVec3() * 50;
            var newDot = Instantiate<GameObject>(sample, newPosition, Quaternion.identity, transform);
            newDot.AddComponent<Dot>();

            dots.Add(newDot);
            Rigidbody theRB = newDot.GetComponent<Rigidbody>();
            theRB.AddForce(RandomVec3() * intialForceMult);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Vector3 RandomVec3()
    {
        return new Vector3(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f);
    }
}
