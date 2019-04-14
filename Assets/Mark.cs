using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour {

    Material mat;
    // Start is called before the first frame update
    void Start () {

        mat = GetComponent<Renderer> ().material;

        StartCoroutine (SelfDestroy ());
    }

    IEnumerator SelfDestroy () {

        while (mat.color.a > 0) {
            var color = mat.color;
            color.a -= 0.001f;
            mat.color = color;
            yield return new WaitForEndOfFrame ();
        }

        Destroy (gameObject);
    }
}