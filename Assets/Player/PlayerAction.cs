using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    //public GameObject box;
    public BoxCollider2D col;

    Rigidbody2D rigidbody2D;

    private string boxTag = "Box";
    private string floorTag = "Floor";
    private string goalTag = "Goal";

    /*---- 変数宣言 ----*/
    public float moveSpeed = 0.005f;
    public float jumpPower = 80.0f;
    Vector3 bulletPos;//弾の位置
    float xLimit = 26.0f;
    float yLimit = 18.0f;
    bool isRight = false;
    bool isLeft = true;
    bool isHit = false;
    bool isJump = false;
    private Rigidbody2D rb = null;

    // Start is called before the first frame update
    void Start()
    {
        /*---- 初期化 ----*/
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*---- キー移動 ----*/

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
            isRight = false;
            isLeft = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
            isRight = true;
            isLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
        /*---- 移動制限 ----*/
        Vector3 player_pos = transform.position;
        player_pos.x = Mathf.Clamp(player_pos.x, -xLimit, xLimit);
        player_pos.y = Mathf.Clamp(player_pos.y, -yLimit, yLimit);
        transform.position = new Vector2(player_pos.x, player_pos.y);

    }
    /*---- ジャンプ ----*/
    //トリガーと他のオブジェクトが接触
    void OnTriggerEnter2D(Collider2D floor)
    {
        if (floor.tag == floorTag)
        {
            isJump = true;
        }
       if(floor.tag == boxTag)
        {
            isJump = true;
        }
    }

    //トリガーと他のオブジェクトが離れた
    void OnTriggerExit2D(Collider2D floor)
    {
        if (floor.tag == floorTag)
        {
            isJump = false;
        }
     
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == boxTag)
        {
            //ボックスの移動
            if (Input.GetKey(KeyCode.Z))
            {

                if (isLeft)
                {
                    collision.transform.Translate(-2, 0, 0);
                }
                else if (isRight)
                {
                    collision.transform.Translate(2, 0, 0);
                }
            }
            //ボックスの破壊
            if (Input.GetKey(KeyCode.X))
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.collider.tag == goalTag)
        {
            SceneManager.LoadScene("GameClear");
        }
    }
}
