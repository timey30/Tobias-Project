using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    private Animator anim;
    private GameObject script;
    private GameObject colide;
    public GameObject GameOverUI;
    private int maxHeart = 6;
    public int startHeart = 3;
    public int curHealth;
    private int maxHealth;
    private int healthPer = 2;

    public Image[] healthImage;
    public Sprite[] healthSprite;

    void Start()
    {
        script = GameObject.FindWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        curHealth = startHeart * healthPer;
        maxHealth = maxHeart * healthPer;
        checkHealth();
    }

    IEnumerator Wait()
    {    
        FindObjectOfType<Movement>().PColide();
        FindObjectOfType<AudioManager>().Play("Death");
        anim.Play("Death");
        script.GetComponent<Movement>().enabled = false;
        yield return new WaitForSeconds(2);
        GameOverUI.SetActive(true);
        Time.timeScale = 1f;
        FindObjectOfType<GameMan>().EndGame();
        
    }

    void checkHealth()
    {
        for (int i = 0; i < maxHeart; i++)
        {
            if (startHeart <= i)
            {
                healthImage[i].enabled = false;
            }
            else
            {
                healthImage[i].enabled = true;
            }
        }
        UpdateHeart();
    }

    void UpdateHeart()
    {
        bool empty = false;
        int i = 0;

        foreach(Image image in healthImage)
        {
            if (empty)
            {
                image.sprite = healthSprite[0];
            }
            else
            {
                i++;
                if (curHealth >= i * healthPer)
                {
                    image.sprite = healthSprite[healthSprite.Length - 1];
                }
                else
                {
                    int currentHeart = (int)(healthPer - (healthPer * i - curHealth));
                    int healthPerImage = healthPer/(healthSprite.Length-1);
                    int imageIndex = currentHeart/ healthPerImage;
                    image.sprite = healthSprite[imageIndex];
                    empty = true;
                }
            }
        }    
    }

    public void TakeDamage(int amount)
    {
        
        curHealth += amount;
        curHealth = Mathf.Clamp(curHealth, 0, startHeart * healthPer);
        if (amount < 0)
        {
            FindObjectOfType<AudioManager>().Play("Damage");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Heal");
        }
        if (curHealth == 0)
        {
           
            StartCoroutine(Wait());
            
            
        }
        UpdateHeart();

    }

    public void AddHeartContainer()
    {

        startHeart++;
        startHeart = Mathf.Clamp(startHeart, 0, maxHeart);
        FindObjectOfType<AudioManager>().Play("Heart");

        //curHealth health = startHeart * healthPer;
        //maxHealth = maxHeart * healthPer;

        checkHealth();

    }

}
