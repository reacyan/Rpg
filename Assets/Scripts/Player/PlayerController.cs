using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;

    public float walkSpeed;
    public float runSpeed;
    public Rigidbody2D rb;

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
}
