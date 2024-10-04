using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool wDown;

    Vector3 nextVec;
    Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");

        nextVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += nextVec * speed * (wDown ? 0.3f : 1) * Time.deltaTime;

        anim.SetBool("isRun", nextVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

        transform.LookAt(transform.position + nextVec);
    }
}
