using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet instance;

    private void Start()
    {
        instance = this;
        Invoke("DestroyShooting", 2f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Land")|| collision.gameObject.tag == ("Wall"))
        {
            Destroy(gameObject);
        }
    }
    void DestroyShooting()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Zoombie"))
        {
            SoundManager.Instance.PlayAudio("Explosion");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
