using System.Collections;
using UnityEngine;

public class PlayerController : Entity
{
    PlayerInput input;

    //public Vector3 inputDirection => new Vector3(input.currentAxes.x, input.currentAxes.y, 0);  //获取输入向量

    protected override void Awake()
    {
        base.Awake();

        input = GetComponent<PlayerInput>();

        //EntityDirection = new Vector3(input.currentAxes.x, input.currentAxes.y, 0);
    }

    protected override void Start()
    {
        input.EnablePlayerControllerInput();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
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

    IEnumerator FadeTree(Collider2D other) //隐藏树
    {
        float alpha = 1;

        while (alpha > 0.6f)
        {
            alpha -= Time.deltaTime;
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha); //降低透明度
            yield return null;
        }

    }

    IEnumerator ShowTree(Collider2D other) //显示树
    {
        float alpha = 0.6f;

        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha); //提高透明度
            yield return null;
        }
    }

    Vector3 VectorChange(Vector3 targetVector)
    {
        float angle = Vector3.Angle(targetVector, EntityDirection);

        float epsilon = 0.1f;

        if (angle < epsilon)
        {
            return EntityDirection;
        }
        else
        {
            return targetVector;
        }
    }
}
