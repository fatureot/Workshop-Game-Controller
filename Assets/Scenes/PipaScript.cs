using UnityEngine;

public class PipaScript : MonoBehaviour
{
    float nilaiRandom;
    void Start()
    {
        nilaiRandom = Random.Range(-1.18f, 1.18f);
        transform.position = new Vector2(transform.position.x, nilaiRandom);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector2.left * 100, Time.deltaTime * 5);
    }
}
