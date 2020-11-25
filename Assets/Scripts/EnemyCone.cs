using System;
using UnityEngine;
public class EnemyCone : MonoBehaviour
{
    public GameObject Cylinder;
    public GameObject Cone;
    private int hp = 2; // кол-во жизней у конуса
    public GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    [System.Obsolete]
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ammo")
        {
            if (hp == 2)
            {
                Cone.SetActive(false);
                Cylinder.SetActive(true);
                hp--;
            }
            else if (hp == 1)
            {
                Cylinder.SetActive(false);
                Cone.SetActive(true);
                hp--;
            }
            else if (hp == 0)
            {
                Cone.SetActive(false);
                Cylinder.SetActive(true);
                hp--;
            }
            else
            {
                GameObject particle = Instantiate(Resources.Load("Particle")) as GameObject;
                particle.transform.position =  transform.position;
                Destroy(particle, 2f);
                Destroy(gameObject);
                gameManager.score.text = (Convert.ToInt32(gameManager.score.text) + 1).ToString();
                gameManager.score.GetComponent<Animation>().Play("TextScale"); // запускаем анимацию у текущего счёта
                gameManager.person.GetComponent<Animator>().SetTrigger("destroy"); // запускаем анимацию у персонажа
            }

        }
    }
}
