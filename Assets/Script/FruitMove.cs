using UnityEngine;

public class FruitMove : MonoBehaviour
{
    public float speed = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
