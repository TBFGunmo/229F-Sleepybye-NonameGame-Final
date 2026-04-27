using UnityEngine;

public class OutOffBound : MonoBehaviour
{
    public Transform sapwnPosition;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Fruit")) 
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.playerHP -= 1;

            if (GameManager.playerHP <= 0)
            {
                GameManager.gameOver = true;
            }

            collision.gameObject.transform.position = sapwnPosition.position;
        }

    }

}
