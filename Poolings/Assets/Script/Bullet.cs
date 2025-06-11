using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float activeTime;

    public bool Active = false;

    public Objectpooling pool;

    private void Awake()
    {
        pool = FindObjectOfType<Objectpooling>();
    }

    private void Start()
    {
        activeTime = 0;
        speed = 20f;
    }

    private void OnEnable()
    {
        Active = true;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (Active)
        {
            activeTime += Time.deltaTime;
        }

        if (activeTime >= 3)
        {
            gameObject.SetActive(false);
        }

    }

    private void OnDisable()
    {
        Active = false;
        activeTime = 0;

        if (pool != null)
        {
            pool.Enqueue(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Gun"))
        {
            gameObject.SetActive(false);
        }
    }
}
