using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    public float jumpForce;
    public Transform groundPoint;
    private bool isOnGround;
    public LayerMask whatIsGround;
    public Animator anim;
    public BulletController shotToFire;
    public Transform shotPoint;
    public float dashSpeed, dashTime;
    public SpriteRenderer theSR, afterImage;
    public float afterImageLifetime, timeBetweenAfterImages;
    public GameObject standing, crawl;
    public float waitToCrawl;
    private float crawlCounter;
    public Animator crawlAnim;
    private PlayerAbilityTracker abilities;

    public float waitAfterDashing;
    private float dashRechargeCounter;
    private float dashCounter;
    private bool canDoubleJump;
    private float afterImageCounter;
    public Color afterImageColor;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        abilities = GetComponent<PlayerAbilityTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dashRechargeCounter > 0)
        {
            dashRechargeCounter -= Time.deltaTime;
        }
        else
        {
            if (Input.GetButtonDown("Fire2")&&standing.activeSelf && abilities.canDash)
            {
                dashCounter = dashTime;
                ShowAfterImage();
            }

        }

        if (dashCounter > 0)
        {
            dashCounter = dashCounter - Time.deltaTime;

            theRB.velocity = new Vector2(dashSpeed * transform.localScale.x, theRB.velocity.y);

            afterImageCounter -= Time.deltaTime;

            if (afterImageCounter <= 0)
            {
                ShowAfterImage();
            }

            dashRechargeCounter = waitAfterDashing;
        }
        else
        {
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

            if (theRB.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (theRB.velocity.x > 0)
            {
                transform.localScale = Vector3.one;
            }
        }

        

        isOnGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);

        if (Input.GetButtonDown("Jump") && moveSpeed!=0 && (isOnGround || (canDoubleJump && abilities.canDoubleJump)))
        {
            if (isOnGround)
            {
                canDoubleJump = true;
            }
            else
            {
                canDoubleJump = false;
            }

            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (Input.GetButtonDown("Fire1") && moveSpeed!=0)
        {
            
            anim.SetTrigger("shotFired");
        
        }

        //crawl mode
        if (!crawl.activeSelf)
        {
            if (Input.GetAxisRaw("Vertical")<-0.9f && abilities.canCrawl && moveSpeed!=0)
            {
                crawlCounter -= Time.deltaTime;
                if (crawlCounter <= 0)
                {
                    crawl.SetActive(true);
                    standing.SetActive(false);
                }
            }
            else
            {
                crawlCounter = waitToCrawl;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") > 0.9f)
            {
                crawlCounter -= Time.deltaTime;
                if (crawlCounter <= 0)
                {
                    crawl.SetActive(false);
                    standing.SetActive(true);
                }
            }
            else
            {
                crawlCounter = waitToCrawl;
            }
        }

        if (standing.activeSelf)
        {
            anim.SetBool("isOnGround", isOnGround);
            anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
        }
        if (crawl.activeSelf)
        {
            crawlAnim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
        }
        
    }

    public void ShowAfterImage()
    {
        SpriteRenderer image = Instantiate(afterImage, new Vector2(transform.position.x+ 0.58f, transform.position.y+ 1.06f), transform.rotation);
        image.sprite = theSR.sprite;
        if (transform.localScale.x > 0)
        {
            image.transform.localScale = new Vector3(3.052713f, 3.052713f, 3.052713f);
        } else if (transform.localScale.x < 0)
        {
            image.transform.localScale = new Vector3(-3.052713f, 3.052713f, 3.052713f);
        }
        
        image.color = afterImageColor;

        Destroy(image.gameObject, afterImageLifetime);
        afterImageCounter = timeBetweenAfterImages;
    }

    public void shooting()
    {
        Instantiate(shotToFire, shotPoint.position, shotPoint.rotation).moveDir = new Vector2(transform.localScale.x, 0f);
    }
}
