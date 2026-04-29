using UnityEngine;

public class Catch : MonoBehaviour
{
    public AudioClip FruitSound;
    public AudioClip BoomSound;
    public AudioSource AudioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            Fruit fruit = collision.gameObject.GetComponent<Fruit>();
            if (fruit)
            {
                GameManager.Score += fruit.Score;
            }

            AudioSource.PlayOneShot(FruitSound, 0.5f);
            Destroy(collision.gameObject);
            print(GameManager.Score);
        }

        if (collision.gameObject.CompareTag("Bomb"))
        {
            GameManager.playerHP -= 1;
           

            if (GameManager.playerHP <= 0)
            {
                GameManager.gameOver = true;
            }


            AudioSource.PlayOneShot(BoomSound, 0.5f);
            Destroy(collision.gameObject);

        }



    }



}
