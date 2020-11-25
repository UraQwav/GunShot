using UnityEngine;

public class DestroyedAnimationGirl : MonoBehaviour
{
    public GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        gameManager.person.GetComponent<Animator>().SetTrigger("miss");
    }
}
