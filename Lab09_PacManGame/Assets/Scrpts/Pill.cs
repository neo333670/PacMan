using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.Invoke("DetstoryItself", 5f);
    }

    void DetstoryItself() {
        GameObject.Destroy(this.gameObject);
    }
}
