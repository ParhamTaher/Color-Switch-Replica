using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float jumpForce = 10f;
    public string currentColor;
    public SpriteRenderer sr;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorPurple;
    public Color colorPink;

    private Rigidbody2D rb;

    private void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        SetRandomColor();

    }

    // Update is called once per frame
    void Update () {
		
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {

            rb.velocity = Vector2.up * jumpForce;

        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "ColorChanger")
        {

            SetRandomColor();
            Destroy(collision.gameObject);
            return;

        }

        if (collision.tag != currentColor)
        {

            Debug.Log("Game over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }

    void SetRandomColor()
    {

        int index = Random.Range(0, 4);

        switch (index)
        {

            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Purple";
                sr.color = colorPurple;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;

        }

        
    }
}
