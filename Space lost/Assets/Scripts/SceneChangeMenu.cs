using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeMenu : MonoBehaviour
{
    public int indice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Dentro");
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(indice);
        }
    }

    public void Cambio()
    {
        SceneManager.LoadScene(indice);
    }
}
