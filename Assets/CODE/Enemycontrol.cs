using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontrol : MonoBehaviour
{
    public GameObject ExplosionGO;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //get the score text UI
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {

        //Get the player's current position
        Vector2 position = transform.position;

        //compute the enemy new position
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //update the bullet's position
        transform.position = position;

        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }void OnTriggerEnter2D(Collider2D col)
        {
            //detect collision of the player ship with an enemy ship, or with an enemy bullet
            if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
            {
            PlayExplosion();
            Destroy(gameObject) ;
            }

        }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        explosion.transform.position = transform.position;
    }
}

    