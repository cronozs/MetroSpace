using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    //public GameObject arrow;
    [SerializeField] private float tiempoDeEspera;
    private float tiempoAtaque;
    private bool puedoAtacar;
    public int counter = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //DireccionFlecha();
        tiempoAtaque -= Time.deltaTime;
        if(puedoAtacar == true && Input.GetKey(KeyCode.Space) && counter < 3)
        {
            DireccionBala();
            puedoAtacar = false;
            tiempoAtaque = tiempoDeEspera;
            return;
        }

        if (tiempoAtaque <= 0)
        {
            puedoAtacar=true;
        }
    }

    void DireccionBala()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {
            bullet.transform.rotation = new Quaternion(0, 0, 1, 0.5f);
            InstanciarBala();
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space))
        {
            bullet.transform.rotation = new Quaternion(0, 0, 1, -0.5f);
            InstanciarBala();
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space))
        {
            bullet.transform.rotation = new Quaternion(0, 0, 1, -2f);
            InstanciarBala();
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space))
        {
            bullet.transform.rotation = new Quaternion(0, 0, 1, 2f);
            InstanciarBala();
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {
            bullet.transform.rotation = new Quaternion(0, 0, 1, 0);
            InstanciarBala();
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space))
        {
            bullet.transform.rotation = new Quaternion(0, 0, 1, 1);
            InstanciarBala();
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space))
        {
            bullet.transform.rotation = new Quaternion(0, 0, 1, -100);
            InstanciarBala();
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            bullet.transform.rotation = new Quaternion(0, 0, 1, -1);
            InstanciarBala();
        }
    }

    void InstanciarBala()
    {
        bullet.transform.position = player.transform.position;
        Instantiate(bullet);
        counter += 1;
    }

    /*void DireccionFlecha()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            arrow.transform.rotation = new Quaternion(0, 0, 1, -0.5f);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            arrow.transform.rotation = new Quaternion(0, 0, 1, -2f);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            arrow.transform.rotation = new Quaternion(0, 0, 1, 2f);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            arrow.transform.rotation = new Quaternion(0, 0, 1, 0.5f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            arrow.transform.rotation = new Quaternion(0, 0, 1, -1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            arrow.transform.rotation = new Quaternion(0, 0, 1, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            arrow.transform.rotation = new Quaternion(0, 0, 1, 1);
        }
        else
        {
            arrow.transform.rotation = new Quaternion(0, 0, 1, -100);
        }
    }*/
}
