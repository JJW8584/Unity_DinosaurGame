using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float maxSpawnDelay = 4f;
    public float curSpawnDelay = 3f;
    public int score = 0;
    public bool isPlaying = true;
    public ObjectManager objectManager;
    public Player player;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverSet;

    private string[] obstacle;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        obstacle = new string[] { "CactusA", "CactusB", "CactusC" };
    }

    private void Start()
    {
        isPlaying = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            scoreText.text = string.Format("{0:n0}", score);
            if (curSpawnDelay >= maxSpawnDelay)
            {
                GameObject gameObj = objectManager.MakeObject(obstacle[Random.Range(0, 3)]);
                gameObj.transform.position = new Vector3(12f, -2.3f, 0f);
                gameObj.GetComponent<BackGround>().player = player;
                curSpawnDelay = 0;
            }
            curSpawnDelay += Time.deltaTime;
        }
    }

    public void GameOver()
    {
        gameOverSet.SetActive(true);
    }
    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }
}
