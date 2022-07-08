using UnityEngine;

public class Lightsabers : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    private void Start()
    {
        // convert screen space to world space
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f; // push one unit further to make sure it goes fully off the screen
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftEdge) // get rid of lightsaber once their off the screen
        {
            Destroy(gameObject);
        }
    }
}
