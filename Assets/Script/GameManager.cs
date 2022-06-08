using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Texture2D corsor;

    float gameTime = 0;
    Image fadeOutImage;
    Color imageColor;

    private GameObject monsterSpawner;
    private static GameManager gameManager;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Cursor.SetCursor(corsor, new Vector2(32, 32), CursorMode.ForceSoftware);
        DontDestroyOnLoad(gameObject);
        //GameStart();
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void GameStart()
    {
        StartCoroutine(LoadPlaying());
    }

    public void GameEnd()
    {
        StopAllCoroutines();
        fadeOutImage.gameObject.SetActive(true);
        imageColor = fadeOutImage.color;
        StartCoroutine(LoadEndGmae());
    }

    public static void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

    public int GetGameTime()
    {
        return (int)gameTime;
    }

    IEnumerator LoadEndGmae()
    {
        while (fadeOutImage.color.a < 0.9f)
        {
            imageColor.a = Mathf.Lerp(imageColor.a, 1, Time.deltaTime * 1f);
            fadeOutImage.color = imageColor;
            yield return null;
        }
        SceneManager.LoadScene("EndGame");
    }

    IEnumerator LoadPlaying()
    {
        SceneManager.LoadScene("Playing");
        yield return null;
        gameTime = 0;
        monsterSpawner = GameObject.Find("Spawners");
        fadeOutImage = GameObject.Find("FadeOut").GetComponent<Image>();
        fadeOutImage.gameObject.SetActive(false);
        StartCoroutine(MonsterSpawn());
    }

    IEnumerator MonsterSpawn()
    {
        while (true)
        {
            for (int i = 0; i < monsterSpawner.transform.childCount; i++)
            {
                monsterSpawner.transform.GetChild(i).GetComponent<MonsterSpawner>().Spawn(1 + (int)(gameTime / 40), 1 + (gameTime / 2500), 1 + (int)(gameTime / 30));
            }
            
            yield return new WaitForSeconds(10f);
        }
    }
}
