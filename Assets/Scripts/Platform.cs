using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsGameBegin())
            transform.position = new Vector2(transform.position.x - (4 * Time.deltaTime), transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deadzone"))
        {
            GameManager.Instance.gameUI.platform.RemovePlatform(gameObject);
            Destroy(this.gameObject);
        }
    }
}
