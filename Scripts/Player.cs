using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -9.8f; // gravity of real life
    public float strength = 5f; // strength/difficulty by game

    private SpriteRenderer spriteRenderer; //defines sprite 

    public Sprite[] sprites; // sprite array
    private int spriteIndex;

    private void Awake() // only called once - initial frame
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); // Invoke calls another function, repeating calls it over and over again, cycles every 0.15 seconds
        
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }


    private void Update ()
    {
        //Input: 

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;

        }

        if (Input.touchCount > 0) //mobile, number of fingers on screen
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) // inital touch
            {
                direction = Vector3.up * strength;
            }

        }


        //apply gravity every frame
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime; // frame dependant - makes consistent

    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex]; // get sprite at index

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "obs")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "Scoring") 
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

}
