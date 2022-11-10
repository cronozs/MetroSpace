using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bala;
    [SerializeField] float vel;
    public AttackController coun;
    // Start is called before the first frame update
    void Start()
    {
        coun = FindObjectOfType<AttackController>();
        Debug.Log(coun.counter);
    }

    // Update is called once per frame
    void Update()
    {
        bala.transform.Translate(0, vel * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        coun.counter -= 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
