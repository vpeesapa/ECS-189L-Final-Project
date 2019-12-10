using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rb;
    [SerializeField] private Animator Anim;
    [SerializeField] private GameObject SpawnLocation;
    [SerializeField] private float NormalSpeed = 5.0f;
    [SerializeField] private float FastSpeed = 7.5f;
    [SerializeField] private float JumpStrength = 100.0f;
    [SerializeField] private float JumpTime;
    [SerializeField] private Text UIScore;
    [SerializeField] private Text UILivesRemaining;
    [SerializeField] private Text UILevelName;
    [SerializeField] private Image UIPanelImage;
    [SerializeField] private TextMesh UINumGemsLeft;
    [SerializeField] private int NumGemsLeft;
    [SerializeField] private Image UIGameOverPanel;
    [SerializeField] private string NextScene;
    [SerializeField] private AudioClip DeathSound;
    [SerializeField] private AudioClip GemCollectSound;

    // for jump effect
    [SerializeField] private float XSqueeze = 0.9f;
    [SerializeField] private float YSqueeze = 1.1f;
    [SerializeField] private float SqueezeSeconds = 0.1f;


    private float JumpTimeCounter;
    private bool IsJumping = false;
    private bool Collided;
    private bool IsGrounded = true;
    private GameObject Drop;
    private int GemsCollected = 0;
    private bool OnConveyor = false;
    private float ConveyorSpeed = 3.0f;
    private Vector3 MovementDirection = new Vector3(1.0f, 0.0f, 0.0f);
    private bool IsPortal = false;
    private int NumDeaths = 0;
    private int LivesRemaining = 3;
    private AudioSource Audio;
    private bool Invincible = false;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            this.Audio.PlayOneShot(this.GemCollectSound, 1.0f);
            this.GemsCollected++;
            this.NumGemsLeft--;
            Debug.Log("Collected a Gem! Total Gem Count: " + this.GemsCollected.ToString());
            other.gameObject.SetActive(false);
            this.UIScore.text = this.GemsCollected.ToString();
            this.UINumGemsLeft.text = this.NumGemsLeft.ToString();
            
        }

        else if (other.gameObject.CompareTag("Portal"))
        {
            this.IsPortal = true;

        }
        else if (other.gameObject.CompareTag("Enemy") && !this.Invincible)
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.Die();
        }
        else if (other.gameObject.CompareTag("Spike") && !this.Invincible)
        {
            this.Die();
        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        this.Collided = false;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        //bool wasGrounded = this.IsGrounded;

        if (other.gameObject.CompareTag("Ground"))
        {
            this.IsGrounded = true;
            this.Rb.velocity = Vector2.zero;
        }

        else if (other.gameObject.CompareTag("Platform"))
        {
            this.IsGrounded = true;
            this.gameObject.GetComponent<BoxCollider2D>().transform.SetParent(other.transform);
        }
      

        else if(other.gameObject.CompareTag("Conveyor"))
        {
            this.IsGrounded = true;
            this.gameObject.GetComponent<BoxCollider2D>().transform.SetParent(other.transform);
            this.OnConveyor = true;
        }

        else if (other.gameObject.CompareTag("Crate"))
        {
            this.IsGrounded = true;
            this.Rb.velocity = Vector2.zero;
        }

        else if (other.gameObject.CompareTag("Spikes") && !this.Invincible)
        {
            this.Die();
        }


        else if (other.gameObject.CompareTag("Enemy") && !this.Invincible)
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.Die();
        }

        else if ((other.gameObject.CompareTag("Saw") || other.gameObject.CompareTag("Acid")) && !this.Invincible)
        {
            // Kills the player upon contact with the blade.
            this.Die();
        }

        // if(!wasGrounded && this.IsGrounded)
        // {
        //     StartCoroutine(Squeeze(this.YSqueeze, this.XSqueeze, this.SqueezeSeconds));
        // }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            this.IsGrounded = false;
        }

        else if (other.gameObject.CompareTag("Platform"))
        {
            this.IsGrounded = false;
            this.gameObject.GetComponent<BoxCollider2D>().transform.SetParent(null);
        }

        else if(other.gameObject.CompareTag("Conveyor"))
        {
            this.IsGrounded = false;
            this.OnConveyor = false;
            this.gameObject.GetComponent<BoxCollider2D>().transform.SetParent(null);
        }
        else if (other.gameObject.CompareTag("Portal"))
        {
            this.IsPortal = false;

        }
    }

    void Start()
    {
        this.Audio = this.GetComponent<AudioSource>();
        Rb.freezeRotation = true;
        this.transform.position = this.SpawnLocation.transform.position;
        this.GemsCollected = 0;
        this.UINumGemsLeft.text = this.NumGemsLeft.ToString();
        this.UILivesRemaining.text = this.LivesRemaining.ToString();
    }

    private IEnumerator Squeeze(float xSqueeze, float ySqueeze, float seconds)
    {
        Vector3 initialSize = Vector3.one;
        Vector3 newSize = new Vector3(xSqueeze, ySqueeze, initialSize.z);
        float t = 0.0f;
        
        // from initial to squeeze
        while(t <= 1.0f)
        {
            t += Time.deltaTime / seconds;
            this.transform.localScale = Vector3.Lerp(initialSize, newSize, t);
            this.transform.localScale = new Vector3(this.transform.localScale.x * this.MovementDirection.x, this.transform.localScale.y, this.transform.localScale.z); 
            yield return null;
        }

        // from squeeze back to initial
        t = 0.0f;
        while(t <= 1.0f)
        {
            t += Time.deltaTime / seconds;
            this.transform.localScale = Vector3.Lerp(newSize, initialSize, t);
            this.transform.localScale = new Vector3(this.transform.localScale.x * this.MovementDirection.x, this.transform.localScale.y, this.transform.localScale.z); 
            yield return null;
        }
    }


    private void updateMoveAnimation(float horizontalMovement)
    {
        if(!this.IsGrounded)
        {
            this.Anim.SetBool("MidAir", true);
        }

        else 
        {
            this.Anim.SetBool("MidAir", false);
        }

        if (horizontalMovement < 0.0f)
        {
            this.transform.localScale = new Vector2(-1, 1);
            if (!this.IsJumping)
            {
                // The run animation should only work while on the ground.
                this.Anim.SetBool("Run", true);
            }
        }

        else if (horizontalMovement > 0.0f)
        {
            this.transform.localScale = new Vector2(1, 1);
            if (!this.IsJumping)
            {
                // The run animation should only work while on the ground.
                this.Anim.SetBool("Run", true);
            }
        }

        else
        {
            this.Anim.SetBool("Run", false);
        }
    }


    void FixedUpdate()
    {
        float moveSpeed = this.NormalSpeed;

        if (Input.GetKey(KeyCode.Z))
        {
            moveSpeed = this.FastSpeed;
        }

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        this.Rb.velocity = new Vector2(horizontalMovement * moveSpeed, this.Rb.velocity.y);
        updateMoveAnimation(horizontalMovement);


        if(Mathf.Approximately(horizontalMovement, 0.0f));
        
        else if(horizontalMovement > 0)
        {
            this.MovementDirection = new Vector3(1.0f, 0.0f, 0.0f);
        }

        else
        {
            this.MovementDirection = new Vector3(-1.0f, 0.0f, 0.0f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.IsGrounded)
        {
            this.IsGrounded = false;
            this.IsJumping = true;
            this.JumpTimeCounter = this.JumpTime;
            this.Rb.velocity = Vector2.up * this.JumpStrength;
            this.Anim.SetBool("Run", false);
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(Squeeze(this.XSqueeze, this.YSqueeze, this.SqueezeSeconds));
        }

        if (Input.GetKey(KeyCode.Space) && this.IsJumping)
        {
            if (this.JumpTimeCounter > 0.0f)
            {
                this.Rb.velocity = Vector2.up * this.JumpStrength;
                this.JumpTimeCounter -= Time.deltaTime;
            }

            else
            {
                this.IsJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.IsJumping = false;
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (this.Collided)
            {
                Destroy(this.Drop);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
     
            if (this.IsPortal && this.NumGemsLeft <= 0)
            {
                LoadNextLevel();
            }
        }

        if((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.F1))
        {
            LoadNextLevel();
        }

        if((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.F2))
        {
            this.Invincible = !this.Invincible;

            var canvas = GameObject.Find("Canvas");
            var prefab = Resources.Load<GameObject>("Popup Message");
            var popupMessage = Instantiate(prefab, canvas.transform);
            Destroy(popupMessage, 1.0f);

            var text = popupMessage.GetComponent<Text>();
            if (this.Invincible)
                text.text = "Invincibility Mode Enabled";
            else
                text.text = "Invincibility Mode Disabled";
        }

        if (UILevelName.color.a != 0.0f)
        {
            // The name of the level slowly fades out every frame.
            var textColor = this.UILevelName.color;
            textColor.a -= Time.deltaTime;
            this.UILevelName.color = textColor;
            if(UIPanelImage.color.a != 0.0f)
            {
                // The panel that serves as a name also fades out every frame.
                var panelColor = this.UIPanelImage.color;
                panelColor.a -= Time.deltaTime;
                this.UIPanelImage.color = panelColor;
            }
        }

        if(this.OnConveyor)
        {
            var playerPos = this.gameObject.transform.position;
            playerPos.x -= ConveyorSpeed * Time.deltaTime;
            this.gameObject.transform.position = playerPos;
        }
    }

    // If something kills the player, the level is reloaded
    public void Die()
    {
        this.Audio.PlayOneShot(this.DeathSound, 2.0f);
        this.NumDeaths += 1;
        this.LivesRemaining -= 1;
        this.UILivesRemaining.text = this.LivesRemaining.ToString();
        this.gameObject.transform.position = this.SpawnLocation.transform.position;
        this.Rb.velocity = Vector2.zero;
        if(this.LivesRemaining <= 0)
        {
            this.UIGameOverPanel.gameObject.SetActive(true);
        }
    }

    public void LoadNextLevel()
    {
        Debug.Log(1);
        SceneManager.LoadScene(this.NextScene);
    }
}