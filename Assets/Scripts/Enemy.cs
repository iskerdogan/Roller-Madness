using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject deadEffect;

    [SerializeField]
    private float enemySpeed;

    private Transform target;
    private float distance;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target!=null)
        {
            transform.LookAt(target);
            distance = Vector3.Distance(transform.position, target.position);
            if (distance > 1f)
            {
                transform.position += transform.forward * enemySpeed * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            TimeManager timeManager = FindObjectOfType<TimeManager>();
            timeManager.gameOver = true;
        }    
    }

    private void OnDisable() 
    {
        Instantiate(deadEffect,transform.position,transform.rotation);
    }
}
