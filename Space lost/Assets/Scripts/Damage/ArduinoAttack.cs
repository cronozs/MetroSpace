using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using TMPro;
using UnityEngine;

public class ArduinoAttack : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public GameObject arrow;
    [SerializeField] private float tiempoDeEspera;
    private float tiempoAtaque;
    private bool puedoAtacar;
    public int counter = 0;
    private string[] vec6;
    private float arr;
    private bool gatillo;

    SerialPort serialPort = new SerialPort("COM3", 9600);

    // Start is called before the first frame update
    void Start()
    {
        serialPort.Open();
        serialPort.ReadTimeout = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (serialPort.IsOpen)
        {
            try //utilizamos el bloque try/catch para detectar una posible excepción.
            {
                string value = serialPort.ReadLine(); //leemos una linea del puerto serie y la almacenamos en un string
                //print(value); //printeamos la linea leida para verificar que leemos el dato que manda nuestro Arduino
                vec6 = value.Split(','); //Separamos el String leido valiendonos 
                                                  //de las comas y almacenamos los valores en un array.

                DireccionFlecha();
                tiempoAtaque -= Time.deltaTime;
                gatillo = vec6[1] == "true";
                if (puedoAtacar == true && gatillo && counter < 3)
                {
                    DireccionBala();
                    puedoAtacar = false;
                    tiempoAtaque = tiempoDeEspera;
                    return;
                }

                if (tiempoAtaque <= 0)
                {
                    puedoAtacar = true;
                }

            }

            catch
            {

            }


        }
    }

    void DireccionBala()
    {
        arr = float.Parse(vec6[0]);
        gatillo = vec6[1] == "true";
        Debug.Log(gatillo);
        Debug.Log(vec6[1]);
        if (arr >= 0 && gatillo)
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 90);
            InstanciarBala();
        }
        else if (arr >= -1.5 && arr < 0 && gatillo)
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 135);
            InstanciarBala();
        }
        else if (arr >= -3 && arr < -1.5 && gatillo)
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 180);
            InstanciarBala();
        }
        else if (arr >= -4.5 && arr < -3 && gatillo)
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 225);
            InstanciarBala();
        }
        else if (arr >= -6 && arr < -4.5 && gatillo)
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 270);
            InstanciarBala();
        }
        else if (arr >= -7.5 && arr < -6 && gatillo)
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 315);
            InstanciarBala();
        }
        else if (arr >= -9 && arr < -7.5 && gatillo)
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
            InstanciarBala();
        }
        else if (gatillo)
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 45);
            InstanciarBala();
        }
    }

    void InstanciarBala()
    {
        bullet.transform.position = player.transform.position + new Vector3(0.03f, 1f, 0);
        Instantiate(bullet);
        counter += 1;
    }
    void DireccionFlecha()
    {
        arr = float.Parse(vec6[0]);
        if (arr>=0)
        {
            arrow.transform.position = player.transform.position + new Vector3(0, 1.7f, 0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (arr >= -1.5 && arr < 0)
        {
            arrow.transform.position = player.transform.position + new Vector3(-1, 1.5f, 0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 135);
        }
        else if (arr >= -3 && arr < -1.5)
        {
            arrow.transform.position = player.transform.position + new Vector3(-1.2f, 0, 0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (arr >= -4.5 && arr < -3)
        {
            arrow.transform.position = player.transform.position + new Vector3(-1, -1.5f, 0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 225);
        }
        else if (arr >= -6 && arr < -4.5)
        {
            arrow.transform.position = player.transform.position + new Vector3(0, -1.5f, 0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (arr >= -7.5 && arr < -6)
        {
            arrow.transform.position = player.transform.position + new Vector3(1, -1.5f, 0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 315);
        }
        else if (arr >= -9 && arr < -7.5)
        {
            arrow.transform.position = player.transform.position + new Vector3(1.2f, 0, 0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            arrow.transform.position = player.transform.position + new Vector3(1, 1.5f, 0);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 45);
        }
    }
}
