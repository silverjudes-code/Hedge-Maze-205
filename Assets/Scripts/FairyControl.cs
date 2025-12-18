using UnityEngine;

public class FairyControl : MonoBehaviour
{
    Animator anim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Move", 0f);
        anim.SetFloat("MoveR", 0f);
        anim.SetFloat("MoveL", 0f);
        anim.SetFloat("MoveBack", 0f);

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetFloat("Move", 1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("MoveR", 1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetFloat("MoveL", 1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetFloat("MoveBack", 1f);
        }
            if (Input.GetKey(KeyCode.F))
        {
            anim.SetFloat("Death", 1f);
        }
    }
}
