using UnityEngine;

public class Brick : MonoBehaviour
{
    private int timesHit;
    private LevelManager levelManager;
    public Sprite[] hitSprites;
    public AudioClip crack;
    private bool isBreakable;

    public GameObject smoke;

    public static int breakableCount = 0;

    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        isBreakable = (this.tag == "Breakable");
        timesHit = 0;

        if (isBreakable)
        {
            breakableCount++;
            Debug.Log("Breakables: " + breakableCount);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        var maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {
            breakableCount--;
            Debug.Log("Breakables: " + breakableCount);
            PuffSmoke();
            Destroy(gameObject);
            levelManager.BrickDestroyedMessage();
        }
        else
        {
            LoadSprites();
        }
    }

    void PuffSmoke()
    {
        var smokePuff = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
        if (smokePuff != null)
        {
            smokePuff.GetComponent<ParticleSystem>().startColor = GetComponent<SpriteRenderer>().color;
        }
    }

    private void LoadSprites()
    {
        var spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Did not find a sprite with index " + spriteIndex);
        }
    }
}