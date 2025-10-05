using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    float time = 0;
    float timer = 1;
    public GameObject pipa;
    void Update()
    {
        if(time<=0)
        {
            Instantiate(pipa, transform.position, Quaternion.identity);
            time = timer;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
