using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform actractPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] float bulletForce;
    private Animator aim;
    private void Start()
    {
        aim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            SoundManager.Instance.PlayAudio("Laser");
            aim.SetBool("Bull", true);
            aim.SetBool("Idle", false);
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, actractPoint.position, actractPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (Input.GetAxis("Horizontal") < 0)
        {
            bulletForce = -8f;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            bulletForce = 8f;
        }
        rb.velocity = new Vector2(bulletForce, 0);

    }
}
