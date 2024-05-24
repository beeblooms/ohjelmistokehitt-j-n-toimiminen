using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed = 8f;
    private bool isFacingRight = true;
    public bool grounded;
    float moveLimiter = 0.7f;

    public Animator anim;
    public Rigidbody2D rig;

    public GameObject Bullet;
    public Transform FirePoint;
    public float fireRate = 0.2f;
    public GameObject gun;

    public Text WINtext;

    bool onCooldown = false;

    public enum PlayerState
    {
        Idle,
        Walking,
    }

    public PlayerState curState;


    [SerializeField] private Rigidbody2D rb;

    void Move()
    {
        float dir = Input.GetAxis("Horizontal");

        if (dir > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (dir < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        rig.velocity = new Vector2(dir * runSpeed, rig.velocity.y);
    }

    public float runSpeed = 20.0f;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(-4.41866f, 5.092006f, 1);
        } else
        {
            this.transform.localScale = new Vector3(4.41866f, 5.092006f, 1);
        }

        if (onCooldown == false && Input.GetKeyDown(KeyCode.Mouse0)&&gun.activeInHierarchy)
        {
            Fire();
        }

    }

    void Fire()
    {
        onCooldown = true;
        Instantiate(Bullet, FirePoint.position, FirePoint.rotation);

        Invoke("ResetCD", fireRate);
    }

    void ResetCD()
    {
        onCooldown = false;
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }



        rig.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "WIN")
        {
            WINtext.gameObject.SetActive(true);
            Time.timeScale = 0;
        }


        if (collision.GetComponent<levelchanger>())
        {
            GameManager.instance.addPOints(1);

            LevelManager.instance.changeLevel(collision.GetComponent<levelchanger>().levelToChangeto);
        }

        if (collision.GetComponent<TextController>())
        {
            collision.GetComponent<TextController>().ShowText();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PickUpGun>())
        {
            if (Input.GetKey(KeyCode.E))
            {
                other.gameObject.SetActive(false);

                gun.SetActive(true);
            }
        }

    }



}
