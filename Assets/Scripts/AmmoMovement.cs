using UnityEngine;

public class AmmoMovement : MonoBehaviour
{
    public float ammoSpeed = 1f; // скорость ядра
    void Update()
    {
        gameObject.transform.Translate(0, 0, ammoSpeed);
    }
    void Start()
    {
        Destroy(gameObject, 5f);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "EnemyCube" || collider.tag == "EnemySphere" || collider.tag == "EnemyCone")
        {
            Destroy(gameObject);
        }
    }
}
