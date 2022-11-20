using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour, ICombat
{
    [SerializeField] private float speed;                  //"SerializeField" significa que desde el inspector podemos  manipular o ver su valor.
    [SerializeField] private Vector2 movementDirection;     //"SerializeField" significa que desde el inspector podemos  manipular o ver su valor.
    private Rigidbody2D rigidbody2D_;
    private bool jumpPressed = false;
    [SerializeField] private float jumpForce;               //Agregamos una variable flotante para agrear furza al salto
    public bool canDoubleJump;
    [SerializeField] private float doubleJumpForce;         //Agregamos una variable flotante para agrear furza al DobleSalto
    [SerializeField] LayerChecker_1 footA;                  //Instanciamento a la Clase "LayerChecker_1" = footA
    [SerializeField] LayerChecker_1 footB;
    public bool canCheckGround;
    private bool playerIsOnGround;
    [SerializeField] PlayerAnimator anim;
    [SerializeField] public int health = 10;

    public TMP_Text Contador;
    public TMP_Text refaxText;
    public int refax = 0;


    // Start is called before the first frame update
    void Start()
    {
        Contador.text = "Salud:  " + health.ToString();
        refaxText.text = "X" + refax.ToString();
        canCheckGround = true;                              //inicializamos la variable "canCheckGround" como verdadera
        rigidbody2D_ = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleIsGrounding();
        HandleControls();
        HandleMovement();
        HandleFlip();
        HandleJump();
    }

    void HandleIsGrounding()
    {
        if (!canCheckGround) return;   //Si NO esta tocando el piso NO se ejecuta nada de este método
                                       //(esta variable se apaga en la corrutina)



        playerIsOnGround = footA.isTouching || footB.isTouching;  //Falta comentar..........

    }

    void HandleControls()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        jumpPressed = Input.GetButtonDown("Jump");

    }
    void HandleMovement()
    {
        rigidbody2D_.velocity = new Vector2(movementDirection.x * speed, rigidbody2D_.velocity.y);

        if (playerIsOnGround)
        {

            if (Mathf.Abs(rigidbody2D_.velocity.x) > 0)                         //comprobamos si se esta moviendo en el eje "X"
            {
                anim.Play(AnimationId.Run);
            }
            else
            {
                anim.Play(AnimationId.Idle);
            }
        }
    }
    void HandleFlip()
    {
        if (rigidbody2D_.velocity.magnitude > 0)                //Sólo si el personaje se está moviendo ejecuta estas lineas...
        {
            if (rigidbody2D_.velocity.x >= 0)                           //si la velocidad en "x" es mayor que cero ejecuta la siguiente linea....
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);            //No rotes
            }
            else                                                                            //de otro modo ejecuta las siguientes lineas.....
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);              //rota en "y" 180º
            }
        }
    }

    void HandleJump()           //Método para agregarle fuerza la RigidBody del Hero
    {

        if (canDoubleJump && jumpPressed && !playerIsOnGround)  //"!playerIsOnGround" esta variable nos indica que NO esta tocando el piso
        {
            this.rigidbody2D_.AddForce(Vector2.up * doubleJumpForce, ForceMode2D.Impulse);//agrega impulso de fuerza instantánea hacia arriba al doble salto           
            canDoubleJump = false;                                                        //apagamos la variable "canDoubleJump“ para que no brinque infinitamente
        }
        if (jumpPressed && playerIsOnGround)

        {
            this.rigidbody2D_.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //animatorController.Play(AnimationId.Idle);

            StartCoroutine(HandleJumpAnimation());
            canDoubleJump = true;                                                   //prendemos la variable "canDoubleJump" para que brinque
                                                                                    //de nuevo si apretamos la barra espaciadora 

        }
    }

    IEnumerator HandleJumpAnimation()                       //Corrutina que ejecuta dos "clips" desfasados en tiempo 0.4f unidades de tiempo
    {
        canCheckGround = false;
        playerIsOnGround = false;
        yield return new WaitForSeconds(0.1f);                  //Ejecutar el Clip "Brinco" durante 0.1f uniades de tiempo
        anim.Play(AnimationId.PreJump);   //Ejecuta el clip "PrepararBrinco"
        yield return new WaitForSeconds(0.2f);                  //Ejecutar el Clip "PrepararBrinco" durante 0.2f uniades de tiempo
        anim.Play(AnimationId.Jump);           //Ejecuta el clip "Brinco"
        //yield return new WaitForSeconds(1);                     //Ejecutar el Clip "Brinco" durante 1f uniades de tiempo
        canCheckGround = true;
    }

    public void TakeDamage(int damagePoints)
    {
        health -= damagePoints;
        Contador.text = "Salud:  " + health.ToString();
        if (health == 0)
        {
            Destroy(gameObject);
        }

    }
}
