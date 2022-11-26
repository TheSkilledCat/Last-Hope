using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ncrip : MonoBehaviour
{
    public float ps;
    private Rigidbody2D rb;
    private Vector2 pd;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float dX = Input.GetAxisRaw("Horizental");
        pd = new Vector2(0, dX).normalized;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, pd.x * ps);
    }
}
