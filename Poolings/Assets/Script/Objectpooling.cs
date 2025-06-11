using System.Collections.Generic;
using UnityEngine;

public class Objectpolling : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int initialSize = 20;
    public float bulletSpeed = 10f;

    private Queue<GameObject> pool = new Queue<GameObject>();
    public void Enqueue(GameObject obj) => pool.Enqueue(obj);

    private void Awake()
    {
        for (int i = 0; i < initialSize; i++)
        {
            var b = Instantiate(bulletPrefab, transform);
            b.SetActive(false);
            pool.Enqueue(b);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetBullet(gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    public GameObject GetBullet(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            var extra = Instantiate(bulletPrefab, transform);
            extra.SetActive(false);
            pool.Enqueue(extra);
        }

        var bullet = pool.Dequeue();
        bullet.transform.SetPositionAndRotation(position, rotation);
        bullet.SetActive(true); 
        return bullet;
    }
}
