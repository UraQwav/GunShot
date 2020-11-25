using System;
using UnityEngine;
public class EnemyCube : MonoBehaviour
{
    private Animation anim;
    private int hp = 2; // кол-во жизней у куба
    public GameManager gameManager;
    void Start()
    {
        anim = GetComponent<Animation>();
        gameManager = FindObjectOfType<GameManager>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ammo")
        {
            anim.Play("CubeScale"); // проигрываеманимацию увеличения куба 
            if(hp < 0)
            {
                GameObject particle = Instantiate(Resources.Load("Particle")) as GameObject;
                particle.transform.position = transform.position;
                Destroy(particle, 2f);
                Destroy(gameObject);
                gameManager.score.text = (Convert.ToInt32(gameManager.score.text) + 1).ToString();
                gameManager.score.GetComponent<Animation>().Play("TextScale"); // запускаем анимацию у текущего счёта
                gameManager.person.GetComponent<Animator>().SetTrigger("destroy"); // запускаем анимацию у персонажа
            }
            hp--;
        }
    }
}
