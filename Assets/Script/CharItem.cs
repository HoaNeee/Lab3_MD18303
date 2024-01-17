using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CharItem : MonoBehaviour
{
    public int coin = 0;
    public TextMeshProUGUI coinText;

    public CharHP charHP;
    public float currentHP;
    public float maxHP = 10;
    // Start is called before the first frame update

    public static CharItem instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        coinText.SetText(coin.ToString());

        ResestPlayer();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            coin++;
            coinText.SetText(coin.ToString());
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("MushRoom"))
        {

            currentHP = currentHP - 2;
            charHP.UpdateHP(currentHP, maxHP);

            if(currentHP < 0)
            {

            }

        }
        if (collision.CompareTag("Door"))
        {
            LoadScence("LV1");
        }
        
    }

    private void OnDisable()
    {
        SavePlayer();
    }
    public void SavePlayer()
    {
        PlayerPrefs.SetInt("PlayerCoin", coin);
        PlayerPrefs.SetFloat("PlayerHP", currentHP);
        PlayerPrefs.Save();
    }

    public void LoadDataPlayer()
    {
        coin = PlayerPrefs.GetInt("PlayerCoin",0);
        currentHP = PlayerPrefs.GetFloat("PlayerHP", maxHP);

        coinText.SetText(coin.ToString());
        charHP.UpdateHP(currentHP, maxHP);
    }

    public void LoadScence(string name)
    {
        SavePlayer();
        SceneManager.LoadScene(name);
    }


    public void ResestPlayer()
    {
        coin = 0;
        currentHP = maxHP;
        charHP.UpdateHP(currentHP, maxHP);
    }
}
