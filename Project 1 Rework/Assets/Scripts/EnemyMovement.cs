using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 endPos;
    [Tooltip("How long it takes for the enemy to move from startPos to endPos")]
    [SerializeField] float timeToTravel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LerpPosition());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LerpPosition()
    {
        Vector2 dir = endPos - startPos;
        float t = 0;
        while (true) {
            transform.position = Vector3.LerpUnclamped(startPos, endPos, Mathf.Sin(t/timeToTravel));
            t += Time.deltaTime;
            yield return null;
        }
    }
}