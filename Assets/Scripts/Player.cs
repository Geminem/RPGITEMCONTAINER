using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float moveSpeed;
    float minX, maxX;// minY, maxY;
    [SerializeField] bool onGround = false;
    [SerializeField] float paddingX, paddingY; //movement restriction ( don't go off the map)s
    [SerializeField] float jumpDistance;
    [SerializeField] float damage;
    [SerializeField] float spawnPadding; //laserspawn offset from player center
    [SerializeField] GameObject Laser;
    [SerializeField] float laserSpeed;
    [SerializeField] float cdSec; // shoot cooldown
    //texty stuff
    [SerializeField] TMPro.TextMeshProUGUI A;
    [SerializeField] TMPro.TextMeshProUGUI D;
    [SerializeField] TMPro.TextMeshProUGUI E;
    [SerializeField] TMPro.TextMeshProUGUI SPACE;
    [SerializeField] ItemStats Weapon;
    bool facingLeft;
    Vector2 objPos;
    Vector2 mousePos;
    //texty
    bool hasShot = false; //shoot cooldown
    //texty stuff
    // Use this for initialization
    void Start() {
        GetBoundaries();
                 }

    // Update is called once per frame
    void Update() {
        //directional shooting
        laserFace();
        playerFace();
        //directional shooting
        //movement
        Movement();
        Jump();
        //movement
        changeLetters();
       if(!hasShot) shoot(); // shoot has cooldown
    }

    //movement
    void Movement()
    {
        var getX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //  var getY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXpos = Mathf.Clamp(transform.position.x + getX, minX + paddingX, maxX + (paddingX*-1));

        // var newYpos = Mathf.Clamp(transform.position.x + getX, minY + paddingY, maxY + paddingY);
        transform.position = new Vector2(newXpos, transform.position.y);
    }
    void GetBoundaries()
    {
        Camera camera; camera = Camera.main;
        minX = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
    }
    void Jump()
    {

        if (Input.GetKeyDown("space") && onGround == true)
        {
            onGround = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpDistance);
        }
    }
    //movement

    //keyLetters pressed
    void lightLetters()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            A.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            D.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            E.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SPACE.color = Color.red;
        }
    }

    void unLightLetters()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            A.color = Color.white;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            D.color = Color.white;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            E.color = Color.white;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SPACE.color = Color.white;
        }
    }

    void changeLetters()
    {
        lightLetters();
        unLightLetters();
    }
    //keyLetters pressed

    //set player stats from item
    public void setPlayerDamage(float dmg)
    {
        damage = dmg;
    }
    //set player stats from item

        //instantiate laser
    void getLaser()
    {
        var laser = Instantiate(Laser, new Vector2(transform.position.x + spawnPadding, transform.position.y), Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(laserSpeed, 0);
        Destroy(laser, 1f);
    }
    //instantiate laser

        //fire the laser and activate shoot cooldown
    void shoot()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(cooldown());
            getLaser();
        }
    }
    //fire the laser and activate shoot cooldown

    IEnumerator cooldown()
        { if (Input.GetButtonDown("Fire1"))
        {
           hasShot=true;
            yield return new WaitForSeconds(cdSec);
        }
        hasShot = false;
        }

    //gets mouse position relative to player
    void playerFace()
    {
        objPos = transform.position;//gets player position
        mousePos = Input.mousePosition;//gets mouse postion
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        if (mousePos.x > objPos.x)
        {
            facingLeft = false;
        }
        else facingLeft = true;
        
    }
    //gets mouse position relative to player

        //adjusts which way the laser should go depending on where player is facing
    void laserFace()
    {
        if (facingLeft && laserSpeed > 0)
        {
            laserSpeed *= -1;
            spawnPadding *= -1;
        }
        if (!facingLeft && laserSpeed < 0)
        {
            laserSpeed *= -1;
            spawnPadding *= -1;
        }
    }

   public void setIteminInv(ItemStats newitem)
    {
        Weapon = newitem;
        damage = Weapon.giveDamage();
    }
    //adjusts which way the laser should go depending on where player is facing
}
