using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public event System.Action OnPlayerDeath;
    float screenHalfWidthInWorldUnits;
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float velocity = speed * h;
        //gameObject.transform.position = new Vector2(transform.position.x + (h * speed), (transform.position.y + (v * speed)));
        transform.Translate(Vector2.right * velocity*Time.deltaTime);
        if(transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        if(transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag =="Falling Block")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
