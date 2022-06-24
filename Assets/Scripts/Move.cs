using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject deadEffect;

    private Vector3 movement;

    private Rigidbody rb;

    private TimeManager timeManager;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        timeManager = FindObjectOfType<TimeManager>();

    }

    void Update()
    {
        if (!timeManager.gameOver && !timeManager.gameFinished)
        {
            MoveThePlayer();
        }

        if (timeManager.gameOver || timeManager.gameFinished)
        {
            rb.isKinematic = true;
        }

    }

    private void MoveThePlayer()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        movement = new Vector3(x, 0f, z);
        rb.AddForce(movement);
    }

    private void OnDisable() 
    {
        Instantiate(deadEffect,transform.position,transform.rotation);
    }
}
