using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private Pipe pipeUp, pipeDown;

    [SerializeField] private float spawnInterval;
    [SerializeField] private float holeSize;
    [SerializeField] private float maxMinOffset = 1f;
    [SerializeField] private Point point;

    private Coroutine CR_Spawn;
    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
    }

    void StartSpawn()
    {
        if(CR_Spawn == null)
        {
            CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        if(CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }

    void SpawnPipe()
    {
        holeSize = Random.Range(2, 4);
        spawnInterval = Random.Range(2, 4);

        float y = maxMinOffset * Mathf.Sin(Time.time);
        Debug.Log(y);


        Pipe newPipeUp = Instantiate(pipeUp, transform.position, Quaternion.Euler(0, 0, 180));

        newPipeUp.gameObject.SetActive(true);

        newPipeUp.transform.position += Vector3.up * (holeSize / 2);

        newPipeUp.transform.position += Vector3.up * y;


        Pipe newPipeDown = Instantiate(pipeDown, transform.position, Quaternion.identity);

        newPipeDown.gameObject.SetActive(true);

        newPipeDown.transform.position += Vector3.up * y;


        Point newPoint = Instantiate(point, transform.position, Quaternion.identity);

        newPoint.gameObject.SetActive(true);

        newPoint.SetSize(holeSize);

        newPoint.transform.position += Vector3.up * y;
    }

    IEnumerator IeSpawn()
    {
        while(true)
        {
            if(bird.IsDead())
            {
                StopSpawn();
            }

            SpawnPipe();

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
