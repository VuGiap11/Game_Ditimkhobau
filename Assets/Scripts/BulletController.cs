using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speedBullet;
    [SerializeField] private float timeDestroy;
    [SerializeField] private float directionX;
    [SerializeField] private float directionY;
    private Vector3 direction; //hướng di chuyển

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", timeDestroy);
        direction = new Vector3(directionX, directionY, 0).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        Movẹ();
    }
    void Movẹ()
    {
        transform.Translate(direction * speedBullet * Time.deltaTime);
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
