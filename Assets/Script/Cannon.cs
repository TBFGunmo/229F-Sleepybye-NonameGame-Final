using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform spawnXStart;
    public Transform spawnXEnd;

    public float heightMax = 7;
    public float heightMin = 3;

    public Transform firePoint;

    private Vector2 targetPoint;

    private Rigidbody2D rb;

    public bool sendActive = false;
    public bool currentActive = false;

    public float angleCal = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //StartCoroutine("Shoot");
    }

    private void Update()
    {
        if (sendActive && !currentActive) 
        {
            currentActive = true;
            StartCoroutine("AutoShoot");
        }
    }

    IEnumerator AutoShoot()
    {
        while (currentActive && !GameManager.gameOver)
        {
            yield return StartCoroutine("RotateAndShoot");

            var delayTime = Random.Range(1f, 3f);
            yield return new WaitForSeconds(delayTime);
        }
    }

    IEnumerator RotateAndShoot()
    {
        getPoint();

        Vector2 dir = targetPoint - (Vector2)firePoint.position;
        float targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        
        float duration = 0.5f;
        float time = 0f;

        float startAngle = transform.eulerAngles.z;

        while (time < duration)
        {
            float angle = Mathf.LerpAngle(startAngle, targetAngle + angleCal, time / duration);
            transform.rotation = Quaternion.Euler(0, 0, angle);

            time += Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0, 0, targetAngle + angleCal);

        Shoot();
    }

    public void getPoint() 
    {
        targetPoint = new Vector2(Random.Range(spawnXStart.position.x, spawnXEnd.position.x), -3);
    }

    public Vector2 CalculateArcVelocity(Vector2 start, Vector2 end, float height)
    {
        float gravity = Mathf.Abs(Physics2D.gravity.y);

        float displacementY = end.y - start.y;
        float displacementX = end.x - start.x;

        float time = Mathf.Sqrt(2 * height / gravity) + Mathf.Sqrt(2 * (displacementY - height) / gravity * -1);

        //float velocityY = Mathf.Sqrt(2 * gravity * height);
        float velocityY = (displacementY / time) + (0.5f * Mathf.Abs(Physics2D.gravity.y) * time);
        float velocityX = displacementX / time;

        //return velocityX + Vector2.up * velocityY;
        return new Vector2(velocityX, velocityY);
    }

    private void Shoot() 
    {
        getPoint();

        var go = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D goRb = go.GetComponent<Rigidbody2D>();

        float height = Random.Range(heightMin, heightMax);

        Vector2 velocity = CalculateArcVelocity(firePoint.position, targetPoint, height);

        goRb.linearVelocity = velocity;
    }


}
