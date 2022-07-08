using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    public float spawnRate = 0.5f; //amount of seconds
    public float minHeight = -0.9f;
    public float maxHeight = 0.9f;

    private void onEnable() // only spawn repeating when its envoked
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    private void onDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn() // clone prefab
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity); // clone our pre made prefabs, Quaternion.identity - no rotation
        // Adjust position of lightsabers depending on range
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight); // up and down using random value
    }

}
