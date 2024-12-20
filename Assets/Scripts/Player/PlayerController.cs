using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;
    Color defaultColor;

    public float walkSpeed;
    public float runSpeed;
    protected Rigidbody2D rb;


    public Vector3 inputDirection => new Vector3(input.currentAxes.x, input.currentAxes.y, 0);

    private void Awake()
    {
        input = GetComponent<PlayerInput>();

        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        input.EnablePlayerControllerInput();
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }

    public void SetZeroVelocity()
    {
        rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            defaultColor = other.gameObject.GetComponent<SpriteRenderer>().color;
            StartCoroutine(FadeTree(other));
            //other.gameObject.GetComponent<SpriteRenderer>().color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            //other.gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
            StartCoroutine(ShowTree(other));
        }
    }

    IEnumerator FadeTree(Collider2D other)
    {
        float alpha = 1;

        while (alpha > 0.6f)
        {
            alpha -= Time.deltaTime;
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
            yield return null;
        }

    }

    IEnumerator ShowTree(Collider2D other)
    {
        float alpha = 0.6f;

        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }
}
