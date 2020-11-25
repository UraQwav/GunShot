using UnityEngine;

public class Figure : MonoBehaviour
{
    public float speed;
    public GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        gameObject.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Destroyed")
        {
            Destroy(gameObject);
            if (gameManager.live < 0)
            {
                gameManager.isCanPlay = false; // останавливаем возможность играть
                gameManager.GameOverMenu.SetActive(true); //выводим сообщение о поражении
                gameManager.maxScoreByDie.text = "Score: " + gameManager.score.text; //записываем максимально кол-во очков
            }
            gameManager.live--;
        }
    }
    
}
