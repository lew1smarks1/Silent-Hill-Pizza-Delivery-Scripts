using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaTimer : MonoBehaviour
{
    private bool isOn = false;
    private static PizzaTimer instance;
    private Animator animator;

    public static PizzaTimer GetInstance()
    {
        return instance;
    }

    public void TurnOn()
    {
        isOn = true;
    }

    public bool IsPizzaOn()
    {
        return isOn;
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        instance = this;
        isOn = false;
    }


    private void Update()
    {
        if (isOn)
        {
            animator.SetTrigger("Open");//naming is ambiguous, "Open" meaning "On"
            isOn = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))//turns on the text and x2powerup state
        {
            x2Text.GetInstance().TextOn();
            Score.GetInstance().Times2();
        }

        else//turns off x2 and powerup state
        {
            x2Text.GetInstance().TextOff();
            Score.GetInstance().Times1();
        }

    }

}
