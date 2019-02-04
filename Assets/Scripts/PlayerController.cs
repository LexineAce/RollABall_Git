using UnityEngine; using UnityEngine.UI; using System.Collections;  public class PlayerController : MonoBehaviour
{      public float speed;     public Text countText;     public Text winText;     public Text scoreText;     public Text lifeText;     public Text dieText;      private Rigidbody rb;     private int count;     private int score;     private int life;      void Start()     {         rb = GetComponent<Rigidbody>();         score = 0;         count = 0;         life = 3;         SetCountText();         winText.text = "";         dieText.text = "";     }      void FixedUpdate()     {         float moveHorizontal = Input.GetAxis("Horizontal");         float moveVertical = Input.GetAxis("Vertical");          Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);          rb.AddForce(movement * speed);          if (Input.GetKey("escape"))             Application.Quit();     }


    //changed code
    void OnTriggerEnter(Collider other)     {         if (other.gameObject.CompareTag("Pick Up"))         {             other.gameObject.SetActive(false);             count = count + 1;             score = score + 1;             SetCountText();         }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score - 1; // this removes 1 from the score             life = life - 1;           SetCountText();
        }         if (count == 10)
        {
            transform.position = new Vector3(35.0f, transform.position.y, transform.position.z);
        }  
    }

    //end change


    private void SetCountText()
    {         countText.text = "Count: " + count.ToString();         scoreText.text = "Score: " + score.ToString();         lifeText.text = "Life: " + life.ToString();         if (score >= 18)         {             winText.text = "You Win!";         }         else if (life <= 0)
        {
            dieText.text = "You Died!";
        }     } } 