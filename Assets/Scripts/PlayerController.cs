using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float m_speed;
    public Text m_count_text;
    public Text m_win_text;

    private int m_count;
    private Rigidbody2D rb2d;

    const int TOTAL_PICKUP_COUNT = 12;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        m_count = 0;
        m_win_text.text = "";
        SetCountText();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * m_speed);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PickUp"))
        {
            collision.gameObject.SetActive(false);
            m_count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        m_count_text.text = "Count: " + m_count.ToString();

        if(m_count >= TOTAL_PICKUP_COUNT)
        {
            m_win_text.text = "She got Thai hair and Florida lips";
        }
    }
}
