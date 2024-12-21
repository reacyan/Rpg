using UnityEngine;

public class Entity : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;

    protected Rigidbody2D rb;
    public Vector3 EntityDirection;


    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        EntityDirection = new Vector3(0, 0, 0);
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    public virtual void SetVelocity(float _xVelocity, float _yVelocity) //设置移动
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }

    public void SetZeroVelocity() //设置零向量
    {
        rb.velocity = Vector2.zero;
    }
}
