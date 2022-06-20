using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaController: MonoBehaviour
{
    public int maxHealth = 10;
    public float speed = 3.0f;
    public float jumpPower = 5.0f;
    KeyCode rightMove;
    KeyCode leftMove;
    KeyCode jump;

    Rigidbody2D rigidbody2d;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal;
        KeySetting(1);
        if (Input.GetKey(rightMove))
        {
            horizontal = 1;
        }
        else if (Input.GetKey(leftMove))
        {
            horizontal = -1;
        }
        else
        {
            horizontal = 0;
        }

        if (Input.GetKeyDown(jump))
        {
            Jump();
            Debug.Log("ggg");
        }


        Vector2 move = new Vector2(horizontal,0);
        Vector2 position = rigidbody2d.position;
        position.x = position.x + move.x * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

   

    private void KeySetting(int player)
    {
        if (player == 1)
        {
            rightMove = KeyCode.D;
            leftMove = KeyCode.A;
            jump = KeyCode.W;
        }
        else/*player==2*/
        {
            rightMove = KeyCode.RightArrow;
            leftMove = KeyCode.LeftArrow;
            jump = KeyCode.UpArrow;
        }
    }

    void Jump()
    {
        rigidbody2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
}
