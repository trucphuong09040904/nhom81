using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Scripting.APIUpdating;

public class Playercontrol : MonoBehaviour
{
    public GameObject GameManagerGO;
    public GameObject PlayerbulletGO;
    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject ExplosionGO;
    public Text LivesUIText;
    const int MaxLives = 3;
    int lives;
    public float speed;
    public void Init()
    {
        lives = MaxLives;
        LivesUIText.text = lives.ToString();
        gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            //play the laser sound effect


            //instantiate the first bullet
            GameObject bullet1 = (GameObject)Instantiate(PlayerbulletGO);
            bullet1.transform.position = Bullet1.transform.position; //set the bullet initial position

            //instantiate the second bullet
            GameObject bullet2 = (GameObject)Instantiate(PlayerbulletGO);
            bullet2.transform.position = Bullet2.transform.position; //set the bullet initial position
        }



        float x = Input.GetAxisRaw("Horizontal"); //the value will be -1, 0, 1 (left, no input, right)
        float y = Input.GetAxisRaw("Vertical"); //the value will be -1, 0, 1 (down, no input, up)

        //now based on the input we compute a direction vector, and we normalize it to get a unit vector
        Vector2 direction = new Vector2(x, y).normalized;

        //now we call the function that computes and sets the player's position
        Move(direction);
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //this is the bottom-left point (corner) of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //this is the top-right point (corner) of the screen

        max.x = max.x - 0.225f; //subtract the player sprite half width
        min.x = min.x + 0.225f; //add the player dprite half width

        max.y = max.y - 0.225f; //subtract the player sprite half height
        min.y = min.y + 0.225f; //add the player dprite half width

        //Get the player's current position
        Vector2 pos = transform.position;

        //Calculate the new position
        pos += direction * speed * Time.deltaTime;

        //Make sure the new position is not outside the screen
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //Update the player's position
        transform.position = pos;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // detect collision of the player ship with an enemy ship, or with an enemy bullet
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayExplosion();
            lives--;
            LivesUIText.text = lives.ToString();

            if (lives == 0)
            {
                GameManagerGO.GetComponent<Gamemanager>().SetGameManagerState(Gamemanager.GameManagerState.GameOver);
                gameObject.SetActive(false);
            }
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }
}





   
