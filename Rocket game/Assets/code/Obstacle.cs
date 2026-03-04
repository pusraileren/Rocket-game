using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f;
    static float speedIncrease = 0.1f;

    void Start()
    {
        speed += Time.timeSinceLevelLoad * speedIncrease;
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}