using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]
    private float time = 4f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,time);
    }

}
