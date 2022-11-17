using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public GameObject arrow;
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
        DireccionFlecha();
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
            bullet.transform.rotation = Quaternion.Euler(0, 0, 225);
            InstanciarBala();
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space))
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 315);
            InstanciarBala();
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space))
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 45);
            InstanciarBala();
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space))
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 135);
            InstanciarBala();
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 270);
            InstanciarBala();
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space))
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 180);
            InstanciarBala();
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space))
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 90);
            InstanciarBala();
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
            InstanciarBala();
        }
    }

    void InstanciarBala()
    {
        bullet.transform.position = player.transform.position + new Vector3(0.03f,1f,0);
        Instantiate(bullet);
        counter += 1;
    }

    void DireccionFlecha()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            arrow.transform.position = player.transform.position + new Vector3(-1f,-1.5f,0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 225);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            arrow.transform.position = player.transform.position + new Vector3(1f, -1.5f, 0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 315);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            arrow.transform.position = player.transform.position + new Vector3(1f, 1.5f, 0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            arrow.transform.position = player.transform.position + new Vector3(-1f, 1.5f, 0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 135);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            arrow.transform.position = player.transform.position + new Vector3(0, -1.5f, 0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            arrow.transform.position = player.transform.position + new Vector3(-1.2f, 0, 0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            arrow.transform.position = player.transform.position + new Vector3(0, 1.7f, 0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            arrow.transform.position = player.transform.position + new Vector3(1.2f, 0, 0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
