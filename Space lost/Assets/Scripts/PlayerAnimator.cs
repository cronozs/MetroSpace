using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnimationId                 //Definimos un enumerado
{
    Idle = 0,
    Run = 1,
}
public class PlayerAnimator : MonoBehaviour
{
    Animator animator;                              //Variable tipo Animator
    private void Awake()
    {
        animator = GetComponent<Animator>();        //Instanciamiento  variable "animator"
    }

    public void Play(AnimationId animationId)       //Método para ejecutar la animación solicitada enviada dentro de
    {
        animator.Play(animationId.ToString());      //Ejecuta la animacion gurdada en "animationID"
    }
}
