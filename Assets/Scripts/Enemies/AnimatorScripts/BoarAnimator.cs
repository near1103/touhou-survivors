using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarAnimator : MonoBehaviour
{
    //References
    Animator am;
    EnemyMovement pm;
    SpriteRenderer sr;

    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<EnemyMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        SpriteDirectionChecker();
    }

    void SpriteDirectionChecker()
    {
        if (pm.lastHorizontalVector < 0)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }
}
