using UnityEngine;

public class GrowPlant : MonoBehaviour
{
    public float growHeight = 2.0f;
    public float disappearDelay = 15.0f;

    private bool isGrowing = false;
    private float timer = 0.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isGrowing = true;
            timer = 0.0f;
        }
    }

    void Update()
    {
        if (isGrowing)
        {
            transform.localScale += new Vector3(0, 0.1f, 0);
            if (transform.localScale.y >= growHeight)
            {
                isGrowing = false;
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= disappearDelay)
            {
                Destroy(gameObject);
            }
        }
    }
}
