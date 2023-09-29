using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Rigidbody2D rb;
    [SerializeField] private float jumbFroce;
    [SerializeField] private float speed;
    public int point = 0;
    public GameObject door;
    public GameObject gameOverPanel;
    public GameObject addZoombie;
    public GameObject winPanel;
    public GameObject Gold;
    public int scene;
    public Text scoreText;
    private Animator aim;
    private bool jumb;
    private bool isLadder;
    private bool isClimbing;
    private float inputvertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        instance = this;
        aim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        float inputhorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputhorizontal * speed, rb.velocity.y);
        Vector3 charactesScale = transform.localScale;
        if (inputhorizontal < 0)
        {
            charactesScale.x = -1;
            //aim.SetBool("Walk", true);
        }
        if (inputhorizontal > 0)
        {
            charactesScale.x = 1;
            //aim.SetBool("Walk", true);
        }
        transform.localScale = charactesScale;
        if (Input.GetMouseButtonDown(1)&& jumb)
        {
            rb.AddForce(Vector2.up * jumbFroce, ForceMode2D.Impulse);
        }
        aim.SetBool("Bull", false);
        aim.SetBool("Idle", true);
        inputvertical = Input.GetAxisRaw("Vertical");
        if (isLadder && Mathf.Abs(inputvertical) > 0f)
        {
            isClimbing = true;
        }

    }
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, inputvertical * speed);
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Point")
        {
            SoundManager.Instance.PlayAudio("Point");
            point++;
            target.gameObject.SetActive(false);
            scoreText.text = "" + point;
            if (point >= 24)
            {
                door.SetActive(true);
            }
        }
        if ((target.tag == "Shoot")|| (target.tag == "Fire"))
        {
            SoundManager.Instance.PlayAudio("Die");
            Destroy(gameObject);
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
        if ((target.tag == "Door"))
        {
            LoadScene();
        }
        if ((target.tag == "Map"))
        {
            Gold.SetActive(true);
            Destroy(target.gameObject);
        }
        if ((target.tag == "AddZoombie"))
        {
            addZoombie.SetActive(true);
        }
        if ((target.tag == "Gold"))
        {
            winPanel.SetActive(true);
            Destroy(target.gameObject);
            Time.timeScale = 0;
        }
        if (target.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }

    }
    void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }
    private void OnCollisionEnter2D(Collision2D canJumb)
    {
        if (canJumb.gameObject.tag == "Land")
        {
            jumb = true;
        }
    }
    private void OnCollisionExit2D(Collision2D canJumb)
    {
        if (canJumb.gameObject.tag == "Land")
        {
            jumb = false;
        }
    }

}
