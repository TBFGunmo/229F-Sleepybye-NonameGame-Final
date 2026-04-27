using UnityEngine;

public class Catch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            Fruit fruit = collision.gameObject.GetComponent<Fruit>();
            if (fruit)
            {
                GameManager.Score += fruit.Score;
            }
            Destroy(collision.gameObject);
            print(GameManager.Score);
        }
    }



}
