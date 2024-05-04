using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed;
    public Player player;
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (!player.isDead)
        {
            if (transform.position.x < -12f)
            {
                if (transform.tag == "obstacle")
                    gameObject.SetActive(false);
                transform.position = new Vector3(12f, transform.position.y, 0f);
            }
            else
            {
                if (transform.tag == "Background" || transform.tag == "obstacle")
                {
                    if (player.h > 0.1f)
                        speed = 6f;
                    else if (player.h < -0.1f)
                        speed = 4f;
                    else
                        speed = 5f;
                }
                transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
            }
        }
    }
}
