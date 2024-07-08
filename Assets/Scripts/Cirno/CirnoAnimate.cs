using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirnoAnimate : MonoBehaviour
{
    //References
    Animator am;
    CirnoMovement pm;

    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<CirnoMovement>();
    }

    void Update()
    {
        am.SetFloat("Horizontal", pm.moveDir.x);
        am.SetFloat("Vertical", pm.moveDir.y);
    }

}
