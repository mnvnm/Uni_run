using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    float m_speed = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.IsGameBegin())
        {
            return;
        }
        if (transform.position.x <= -20.48f)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        transform.position += Vector3.left * Time.deltaTime * m_speed;
    }
}
