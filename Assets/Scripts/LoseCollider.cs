using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;

    void Awake()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        Debug.Log("Trigger: " + trigger.name);
        levelManager.LoadLevel("Lose");
    }
}