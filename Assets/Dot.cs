using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour {
    Vector2[] noiseIndexes = new Vector2[3];

    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] GameObject mark;

    // Start is called before the first frame update
    void Start () {
        for (int i = 0; i < 3; i++) {
            noiseIndexes[i] = new Vector2 (Random.value, Random.value);
        }
        rb = GetComponent<Rigidbody> ();
        audioSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update () {

    }

    private void FixedUpdate () {
        Vector3 forceToAddPerlin = new Vector3 (Mathf.PerlinNoise (noiseIndexes[0].x, noiseIndexes[0].y) - 0.5f,
            Mathf.PerlinNoise (noiseIndexes[1].x, noiseIndexes[1].y) - 0.5f,
            Mathf.PerlinNoise (noiseIndexes[2].x, noiseIndexes[2].y) - 0.5f
        );

        Vector3 forceToAddSin = new Vector3 (Mathf.Sin (noiseIndexes[0].x), Mathf.Sin (noiseIndexes[1].x), Mathf.Cos (noiseIndexes[2].x));

        rb.AddForce (forceToAddPerlin * 2);

        for (int i = 0; i < 3; i++) {
            noiseIndexes[i] += new Vector2 (0.001f, 0.001f);
        }
    }

    void OnCollisionEnter (Collision collision) {
        if (collision.collider.gameObject.layer == 9) {
            //Debug.Log ("wall");
            audioSource.Play ();
            var rotation = collision.collider.gameObject.transform.rotation;
            var newMark = GameObject.Instantiate (mark, collision.contacts[0].point, rotation);
            newMark.AddComponent<Mark> ();
        }

    }

}