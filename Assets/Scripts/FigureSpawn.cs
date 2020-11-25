using System.Collections;
using UnityEngine;

public class FigureSpawn: MonoBehaviour
{
    public GameObject figure;
    GameManager gameManager;
    private bool isSpawn = true; // позволяет определить вышло ли время с момента последнего спама фигуры
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawn)
            StartCoroutine(RespawnFigureCarutine());
    }
    IEnumerator RespawnFigureCarutine()
    {
        if (gameManager.isCanPlay) // проверяем запущена ли игра
        {
            Instantiate(figure, gameObject.transform.position, gameObject.transform.rotation);
            isSpawn = false;

            // проверяем какая фигура будет сейчас добовляться на сцену для того чтобы назначить время ожидания 
            // до следуещего добавления фигуры
            if (figure.name.Contains("Cube"))
            {
                yield return new WaitForSeconds(gameManager.timeToSpawnCube);
            }
            else if (figure.name.Contains("Sphere"))
            {
                yield return new WaitForSeconds(gameManager.timeToSpawnSphere);
            }
            else
            {
                yield return new WaitForSeconds(gameManager.timeToSpawnCone);
            }
            isSpawn = true;
        }
    }
}
