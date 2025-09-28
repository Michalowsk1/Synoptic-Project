using UnityEngine;

public class bullet : MonoBehaviour
{
    string[] destroyObjects = { "bar", "cave", "heal", "basicEnemy", "flyingEnemy", "projectile" };
    void Update()
    {
        Destroy(gameObject, 1.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < destroyObjects.Length; i++)
        {
            if (collision.gameObject.tag == destroyObjects[i])
            {
                Destroy(gameObject);
            }
        }
    }
}
