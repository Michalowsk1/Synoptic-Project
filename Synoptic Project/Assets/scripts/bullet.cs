using UnityEngine;

public class bullet : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 1.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bar" || collision.gameObject.tag == "cave" || collision.gameObject.tag == "heal")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "basicEnemy" || collision.gameObject.tag == "flyingEnemy")
        {
            Destroy(gameObject);
        }
    }
}
