using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playercontroller1 : MonoBehaviour {


    float maxHP = 8;
    float currentHP = 8;
    float maxMP = 10;
    float currentMP;

    int dogcount;
    int dogcounttext;
    float timer;
    float mutekitimer;
    
    
    public Image hpimage;
    public Image mpimage;
    public Text dogtext;

    public GameObject rightbullet;
    public GameObject leftbullet;
    public GameObject dogrightbullet;
    public GameObject dogleftbullet;
    public GameObject specialbullet;

    public float speed = 8;
    public float jumpPower = 12.5f;
    int jumpCount;
    public AudioClip pickupsound;
    public AudioClip jumpsound;
    public AudioClip attacksound;
    public AudioClip playerhitsound;

   

    public Camera camera;
    public float angle = 180;


    bool isRighButton;
    bool isRightdogButton;


    bool rightoperate;
    bool leftoperate;
    bool attackoperate;
    bool skilloperate;

    AudioSource audioSource;
    Animator animator;
    SpriteRenderer spriterenderer;

    //float x = Input.GetAxisRaw("Horizontal");





    // Use this for initialization
    void Start () {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        animator = this.gameObject.GetComponent<Animator>();
        spriterenderer = this.gameObject.GetComponent<SpriteRenderer>();

        dogcount = 0;
    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        mutekitimer += Time.deltaTime;

        if(mutekitimer >= 2.0f)
        { spriterenderer.color = Color.white; }

       //左：パソコン用　右：スマホ用
        if ( Input.GetKey(KeyCode.D) || rightoperate == true)
        {
            isRighButton = true;
            isRightdogButton = true;
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            //this.transform.localScale
               // = new Vector3(transform.localScale.x * 1, transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKey(KeyCode.D) || rightoperate == true)
        {
            animator.SetBool("walkright", true);
            
        }
        if (Input.GetKeyUp(KeyCode.D) || rightoperate == false)
        {
            animator.SetBool("walkright", false);
        }

        //左：パソコン用　右：スマホ用
        if ( Input.GetKey(KeyCode.A) || leftoperate == true )
        {
            isRighButton = false;
            isRightdogButton = false;
            this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
           // this.transform.localScale
               // = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKey(KeyCode.A) || leftoperate == true)
        {
            animator.SetBool("walkleft", true);
        }
        if (Input.GetKeyUp(KeyCode.A) || leftoperate == false)
        {
            animator.SetBool("walkleft", false);
        }

        //パソコン用ジャンプ（実装後無効化にする）
        if ( Input.GetKeyDown(KeyCode.W)  && jumpCount < 2)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
            audioSource.clip = jumpsound;
            audioSource.Play();

            jumpCount += 1;
        }


        //パソコン用攻撃（実装後無効化にする）
        if (Input.GetKeyDown(KeyCode.K) && timer > 1)
        {
            if (isRighButton == true)//right
            {
                Instantiate(rightbullet, this.transform.position, Quaternion.identity);
                timer = 0;
                audioSource.clip = attacksound;
                audioSource.Play();
            }
            else//left
            {
                 Instantiate(leftbullet, this.transform.position, Quaternion.identity);
                timer = 0;
                audioSource.clip = attacksound;
                audioSource.Play();
            }
            //Instantiate(bullet, this.transform.position, this.transform.rotation);
            

        }

        //スマホ用攻撃
        if ( attackoperate == true && timer > 1)
        {
            if (isRighButton == true)//right
            {
                Instantiate(rightbullet, this.transform.position, Quaternion.identity);
                timer = 0;
                audioSource.clip = attacksound;
                audioSource.Play();

            }
            else//left
            {
                Instantiate(leftbullet, this.transform.position, Quaternion.identity);
                timer = 0;
                audioSource.clip = attacksound;
                audioSource.Play();
            }
            //Instantiate(bullet, this.transform.position, this.transform.rotation);


        }

        //パソコン用攻撃（実装後無効化にする）
        if (Input.GetKeyDown(KeyCode.O) && timer > 1 && dogcount >0 )
        {
            if (isRightdogButton == true)//right
            {
                Instantiate(dogrightbullet, this.transform.position, Quaternion.identity);
                timer = 0;
                dogcount -= 1;              
                audioSource.clip = attacksound;
                audioSource.Play();
            }
            else//left
            {
                Instantiate(dogleftbullet, this.transform.position, Quaternion.identity);
                timer = 0;
                dogcount -= 1;
                audioSource.clip = attacksound;
                audioSource.Play();
            }
            //Instantiate(bullet, this.transform.position, this.transform.rotation);


        }


        //スマホ用攻撃
        if (skilloperate == true && timer > 1 && dogcount > 0)
        {
            if (isRightdogButton == true)//right
            {
                Instantiate(dogrightbullet, this.transform.position, Quaternion.identity);
                timer = 0;
                dogcount -= 1;
                dogcounttext = dogcounttext - 1;
                dogtext.text = dogcounttext.ToString();
                audioSource.clip = attacksound;
                audioSource.Play();
            }
            else//left
            {
                Instantiate(dogleftbullet, this.transform.position, Quaternion.identity);
                timer = 0;
                dogcount -= 1;
                dogcounttext = dogcounttext - 1;
                dogtext.text = dogcounttext.ToString();
                audioSource.clip = attacksound;
                audioSource.Play();
            }
            //Instantiate(bullet, this.transform.position, this.transform.rotation);


        }

        //パソコン用必殺攻撃（実装後無効化にする）
        if (Input.GetKeyDown(KeyCode.P) && currentMP >= 10)
        { Instantiate(specialbullet, this.transform.position, Quaternion.identity);
            currentMP = 0;
            mutekitimer = 0;
            mpimage.fillAmount = currentMP / maxMP;
            audioSource.clip = attacksound;
            audioSource.Play();
            spriterenderer.color = Color.blue;
        }

        //スマホ用攻撃


        if (currentHP <= 0)
        { SceneManager.LoadScene("endscene"); }

    }

    public void rightmovedown()
    {
        rightoperate = true;
    }
    public void rightmoveup()
    {
        rightoperate = false;
    }
    
    public void leftmovedown()
    {
        leftoperate = true;
    }
    public void leftmoveup()
    {
        leftoperate = false;
    }

    public void attackmovedown()
    {
        attackoperate = true;
    }
    public void attackmoveup()
    {
        attackoperate = false;
    }

    public void skillmovedown()
    {
        skilloperate = true;
    }
    public void skilmoveup()
    {
        skilloperate = false;
    }

    //スマホ用ジャンプ
    public void jumpmove()
    {
        if (jumpCount < 2)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
            audioSource.clip = jumpsound;
            audioSource.Play();

            jumpCount += 1;
        }
    }

    //スマホ用必殺攻撃
    public void specialmove()
    {
        if (currentMP >= 10)
        {
            Instantiate(specialbullet, this.transform.position, Quaternion.identity);
            currentMP = 0;
            mutekitimer = 0;
            mpimage.fillAmount = currentMP / maxMP;
            audioSource.clip = attacksound;
            audioSource.Play();
            spriterenderer.color = Color.blue;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "train" || collision.gameObject.tag == "secret")
        {
            jumpCount = 0;
        }

       

        if (collision.gameObject.tag == "damage")
        {
            currentHP -= 1;
            mutekitimer = 0;
            hpimage.fillAmount = currentHP / maxHP;
            audioSource.clip = playerhitsound;
            audioSource.Play();
            if (currentMP <= 10)
            {
                currentMP += 1;
                mpimage.fillAmount = currentMP / maxMP;
            }
            spriterenderer.color = Color.red;

        }

        if (collision.gameObject.tag == "dead")
        {
            SceneManager.LoadScene("endscene");
        }

        if (collision.gameObject.tag == "clear")
        {
            SceneManager.LoadScene("clearscene1");
            
        }
        if (collision.gameObject.tag == "clear2")
        {
            SceneManager.LoadScene("clearscene2");

        }
        if (collision.gameObject.tag == "clear3")
        {
            SceneManager.LoadScene("clearscene3");

        }
        if (collision.gameObject.tag == "clear4")
        {
            SceneManager.LoadScene("clearscene4");

        }
        if (collision.gameObject.tag == "clear5")
        {
            SceneManager.LoadScene("clearscene5");

        }

        if (collision.gameObject.tag == "sinanogawa")
        {
            SceneManager.LoadScene("sinanogawascene");

        }

        if (collision.gameObject.tag == "enemy" && mutekitimer >= 3.0f )
        {
            currentHP -= 1;
            mutekitimer = 0;
            audioSource.clip = playerhitsound;
            audioSource.Play();
            hpimage.fillAmount = currentHP / maxHP;
            Destroy(collision.gameObject);
            if (currentMP <= 10)
            {
                currentMP += 1;
                mpimage.fillAmount = currentMP / maxMP;            
            }
            spriterenderer.color = Color.red;
        }


        if (collision.gameObject.tag == "boss" && mutekitimer >= 3.0f)
        {
            currentHP -= 1;
            mutekitimer = 0;
            hpimage.fillAmount = currentHP / maxHP;
            audioSource.clip = playerhitsound;
            audioSource.Play();
            if (currentMP <= 10)
            {
                currentMP += 1;
                mpimage.fillAmount = currentMP / maxMP;
            }
            spriterenderer.color = Color.red;
        }

        if (collision.gameObject.tag == "enemy" && mutekitimer < 3.0f)
        {
            audioSource.clip = playerhitsound;
            audioSource.Play();
            Destroy(collision.gameObject);           
        }



    }

    private void OnTriggerEnter(Collider collider)
    {
       

        if (collider.gameObject.tag == "enemyattack" && mutekitimer >= 3.0f )
        {
            currentHP -= 1;
            mutekitimer = 0;
            hpimage.fillAmount = currentHP / maxHP;
            audioSource.clip = playerhitsound;
            audioSource.Play();
            Destroy(collider.gameObject);
            if (currentMP <= 10)
            {
                currentMP += 1;
                mpimage.fillAmount = currentMP / maxMP;
            }
            spriterenderer.color = Color.red;
        }

        if (collider.gameObject.tag == "bomb" && mutekitimer >= 3.0f)
        {
            currentHP -= 2;
            mutekitimer = 0;
            hpimage.fillAmount = currentHP / maxHP;
            audioSource.clip = playerhitsound;
            audioSource.Play();
            Destroy(collider.gameObject);
            if (currentMP <= 10)
            {
                currentMP += 1;
                mpimage.fillAmount = currentMP / maxMP;
            }
            spriterenderer.color = Color.red;
        }


        if (collider.gameObject.tag == "HPrecover")
        {
            if (currentHP <= 4)
            { currentHP += 4;
                hpimage.fillAmount = currentHP / maxHP;
                Destroy(collider.gameObject); }
            if (currentHP == 5)
            {
                currentHP += 3;
                hpimage.fillAmount = currentHP / maxHP;
                Destroy(collider.gameObject);
            }
            if (currentHP == 6)
            {
                currentHP += 2;
                hpimage.fillAmount = currentHP / maxHP;
                Destroy(collider.gameObject);
            }
            if (currentHP == 7)
            {
                currentHP += 1;
                hpimage.fillAmount = currentHP / maxHP;
                Destroy(collider.gameObject);
            }
            else { Destroy(collider.gameObject); }
            audioSource.clip = pickupsound;
            audioSource.Play();

        }

        if (collider.gameObject.tag == "dog")
        {
            dogcount += 3;
            Destroy(collider.gameObject);
            audioSource.clip = pickupsound;
            audioSource.Play();
            dogcounttext = dogcounttext + 3;
            dogtext.text = dogcounttext.ToString();
        }

        if (collider.gameObject.tag == "MPrecover")
        {
            if(currentMP <=10)
            { currentMP += 5;
                mpimage.fillAmount = currentMP / maxMP;
                Destroy(collider.gameObject);              
            }
             else { Destroy(collider.gameObject); }
            audioSource.clip = pickupsound;
            audioSource.Play();

        
        }

        if (collider.gameObject.tag == "card")
        {
            camera.transform.Rotate(new Vector3(0f, 0f, 180f));
            Destroy(collider.gameObject);
            audioSource.clip = pickupsound;
            audioSource.Play();
        }

        if (collider.gameObject.tag == "ticket1")
        {
            this.transform.position =(new Vector3(347, 35, 0));
            Destroy(collider.gameObject);
            audioSource.clip = pickupsound;
            audioSource.Play();
        }

        if (collider.gameObject.tag == "ticket2")
        {
            this.transform.position = (new Vector3(1285, 35, 0));
            Destroy(collider.gameObject);
            audioSource.clip = pickupsound;
            audioSource.Play();
            
        }

        if (collider.gameObject.tag == "key")
        {
            this.transform.position = (new Vector3(38, 160, 0));
            Destroy(collider.gameObject);
            audioSource.clip = pickupsound;
            audioSource.Play();

        }
    }

   

}
