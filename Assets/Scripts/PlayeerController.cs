using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class PlayeerController : MonoBehaviour
{

    private bool jumpLeft;
    private bool jumpRight;
    public float jumpForce;
    Rigidbody2D rb;
    Animator animator;


    //Aniamsyonun bitimesini bekle
    private bool canJump = false;

    public bool isDie = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    private void Start()
    {
        this.gameObject.transform.DOMoveY(2.08f, 2f);
        StartCoroutine(WaitStartAnimation());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("left"))
        {
            jumpRight = true;
            jumpLeft = false;
        }
        if (collision.gameObject.CompareTag("right"))
        {
            jumpRight = false;
            jumpLeft = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obsticle"))
        {
            Debug.Log("temas var");
            animator.SetTrigger("IsDie");
            isDie = true;

        }
    }
    private void FixedUpdate()
    {

        if (canJump)
        {
            if (Input.GetMouseButton(0))
            {
                //cANVAS nesneelerine týklanmýyorsa
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if (jumpRight)
                    {
                        rb.velocity = new Vector2(jumpForce, rb.velocity.y);
                        transform.rotation = Quaternion.Euler(0f, 180f, -90f);
                        animator.SetBool("IsJump", true);
                        StartCoroutine(WaitAnimation());
                    }
                    if (jumpLeft)
                    {
                        rb.velocity = new Vector2(-jumpForce, rb.velocity.y);
                        transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                        animator.SetBool("IsJump", true);
                        StartCoroutine(WaitAnimation());

                    }
                }

            }
        }
    }
    IEnumerator WaitAnimation()
    {
        yield return new WaitForSeconds(0.6f);
        animator.SetBool("IsJump", false);
    }
    IEnumerator WaitStartAnimation()
    {
        yield return new WaitForSeconds(2f);
        canJump = true;
    }
}
