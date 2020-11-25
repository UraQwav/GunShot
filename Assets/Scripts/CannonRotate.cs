using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotate : MonoBehaviour
{
    #region game_tap_zone
    private Rect leftPart = new Rect(0, 0, Screen.width / 3, Screen.height);
    private Rect CenterPart = new Rect(Screen.width / 3, 0, Screen.width / 3, Screen.height);
    private Rect rightPart = new Rect(2*Screen.width / 3, 0, Screen.width / 3, Screen.height);
    #endregion

    private string enemyTag=""; // строка хранящая в себе тег врага

    #region gameObjects
    public GameObject cannon; // пушка
    public GameObject leftRoad; //левая, правая и центральная дорожка соответсвенно
    public GameObject centerRoad;
    public GameObject rightRoad;
    #endregion

    public float reloadSpeed; // время перезарядки
    public float rotateSpeedInTrigger = 2f; // скорость поворота пушки если фигура зашла в тригеер автонаведения
    public float rotateSpeed = 7f; // скорость поворота пушки
    private bool CanShot = true; 
    private bool inTrigger = false; // позволяет проверить находиться ли фигура в тригере автонаведения
    public GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        // получаем время перезорядки для пушки
        reloadSpeed = gameObject.name.Contains("Left") ? gameManager.leftCannonReloadSpeed : gameManager.rightCannonReloadSpeed; 
    }
    void Update()
    {
        if (gameManager.isCanPlay) // проверяем запущена ли игра
        {
            if (Input.GetMouseButton(0)) // touch works too
            {
                if (leftPart.Contains(Input.mousePosition))
                {
                    if (CanShot) // проверяем возможность выстрела
                    {
                        enemyTag = "EnemyCube";
                        StartCoroutine(Shot());
                    }
                    if (!inTrigger) // проверяем есть ли фигура в тригере автонаведения
                    {
                        Vector3 newDir = Vector3.RotateTowards(cannon.transform.forward, (leftRoad.transform.position - cannon.transform.position), 1f, 0.0F);
                        cannon.transform.rotation = Quaternion.Slerp(cannon.transform.rotation, Quaternion.LookRotation(newDir), Time.deltaTime * rotateSpeed);
                    }
                    inTrigger = false;
                }
                if (rightPart.Contains(Input.mousePosition))
                {
                    if (CanShot)
                    {
                        enemyTag = "EnemySphere";
                        StartCoroutine(Shot());
                    }
                    if (!inTrigger)
                    {
                        Vector3 newDir = Vector3.RotateTowards(cannon.transform.forward, (rightRoad.transform.position - cannon.transform.position), 1f, 0.0F);
                        cannon.transform.rotation = Quaternion.Slerp(cannon.transform.rotation, Quaternion.LookRotation(newDir), Time.deltaTime * rotateSpeed);
                    }
                    inTrigger = false;
                }
                if (CenterPart.Contains(Input.mousePosition))
                {
                    if (CanShot)
                    {
                        enemyTag = "EnemyCone";
                        StartCoroutine(Shot());
                    }
                    if (!inTrigger)
                    {
                        Vector3 newDir = Vector3.RotateTowards(cannon.transform.forward, (centerRoad.transform.position - cannon.transform.position), 1f, 0.0F);
                        cannon.transform.rotation = Quaternion.Slerp(cannon.transform.rotation, Quaternion.LookRotation(newDir), Time.deltaTime * rotateSpeed);
                    }
                    inTrigger = false;
                }
            }
            else
            {
                enemyTag = "";
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == enemyTag)
        {
            Vector3 newDir = Vector3.RotateTowards(cannon.transform.forward, (other.transform.position - cannon.transform.position), 1f, 0.0F);
            cannon.transform.rotation = Quaternion.Slerp(cannon.transform.rotation, Quaternion.LookRotation(newDir), Time.deltaTime * rotateSpeedInTrigger);
            inTrigger = true;
            // наводим пушку в сторону фигурыб и следим за ней пока та в тригере
        }
    }
    IEnumerator Shot()
    {
        GameObject ammo = Instantiate(Resources.Load("Ammo")) as GameObject; // загружаем снаряд из ресурсов
        ammo.transform.position = cannon.transform.position;
        ammo.transform.rotation = cannon.transform.rotation;
        CanShot = false;
        yield return new WaitForSeconds(reloadSpeed);
        CanShot = true;
    }
}
