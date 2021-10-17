using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    [SerializeField] private float upForce = 100;
    [SerializeField] private bool isDead;
    [SerializeField] private UnityEvent OnJump, OnDead;
    [SerializeField] private int score;
    [SerializeField] private UnityEvent OnAddPoint;
    [SerializeField] private Text scoreText;

    private Rigidbody2D rigidbody2d;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && Input.GetMouseButtonDown(0))
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 30f);
            Jump();
        }
        if (!isDead && Input.GetMouseButtonUp(0))
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void Dead()
    {
        if(!isDead && OnDead != null)
        {
            OnDead.Invoke();
        }

        isDead = true;
    }

    void Jump()
    {
       if(rigidbody2d)
        {
            rigidbody2d.velocity = Vector2.zero;
            rigidbody2d.AddForce(new Vector2(0, upForce));
        }

       if(OnJump != null)
        {
            OnJump.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.enabled = false;
    }

    public void AddScore(int value)
    {
        score += value;

        if(OnAddPoint != null)
        {
            OnAddPoint.Invoke();
        }

        scoreText.text = score.ToString();
    }
}
