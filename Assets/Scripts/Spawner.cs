using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] availableObstacles;
    public List<GameObject> currentObstacles;
    public Transform target;
    private float obstacleNumber = 0;
    public float obstacleSpacing = 3;
    public float maxObstaclesInGame = 5;
    public float obstacleRemovePosition = 10;
    private float sameObstacleInARow = 0;
    private string previousObstacleName;
    private bool didSpawn;

    // Use this for initialization
    void Start () {
        StartCoroutine(GeneratorCheck());
    }



    // Update is called once per frame
    void Update () {

    }


    void AddObstacle(float obstaclePosition)
    {

        int randomRoomIndex = Random.Range(0, availableObstacles.Length);

        GameObject obstacle = (GameObject)Instantiate(availableObstacles[randomRoomIndex]);
        if(obstacle.name == previousObstacleName){
            sameObstacleInARow += 1f;
        }else{
            sameObstacleInARow = 0f;
        }
        if(sameObstacleInARow >=3 ){
            Destroy(obstacle);
            didSpawn = false;
            AddObstacle(obstacleNumber);
            return;
        }
        didSpawn = true;
        float obstacleCenter = (float)(obstaclePosition * obstacleSpacing);
        float obstacleY = 0f;
        if(obstacle.name  == "FireEngine(Clone)")
        {
            obstacleY = -4.25f;
        }else if( obstacle.name == "FireEngineReverse(Clone)")
        {
            obstacleY = 4.3f;
        }
        else if (obstacle.name == "CandyObstacle(Clone)")
        {
            obstacleY = -2.6f;
        }
        else if (obstacle.name == "CandyObstacleReverse(Clone)")
        {
            obstacleY = 2.6f;
        }

        obstacle.transform.position = new Vector3(obstacleCenter, obstacleY, 0);
        var myScale = obstacle.transform.lossyScale;
        if (obstacleNumber < 3)
        {
            obstacle.transform.localScale = new Vector3(myScale.x, 0.8f * myScale.y, myScale.z);
        }
        else if(obstacleNumber < 5){
            obstacle.transform.localScale = new Vector3(myScale.x, 0.9f * myScale.y, myScale.z);
        }else{
            obstacle.transform.localScale = new Vector3(myScale.x, 0.95f * myScale.y, myScale.z);
        }
        currentObstacles.Add(obstacle);
        previousObstacleName = obstacle.name;
    }





    private void GenerateObstacleIfRequired()
    {

        List<GameObject> obstaclesToRemove = new List<GameObject>();

        float playerX = target.position.x;
        float removeObstacleX = playerX - obstacleRemovePosition;
        
        foreach (var obstacle in currentObstacles)
        {
            if (obstacle.transform.position.x < removeObstacleX)
            {
                obstaclesToRemove.Add(obstacle);
            }
        }

        foreach (var obstacle in obstaclesToRemove)
        {
            currentObstacles.Remove(obstacle);
            Destroy(obstacle);
        }

        if (currentObstacles.Count < maxObstaclesInGame)
        {
            AddObstacle(obstacleNumber);
            if (didSpawn)
            {
                obstacleNumber += 1;
            }
        }
    }

    private IEnumerator GeneratorCheck()
    {
        while (true)
        {
            GenerateObstacleIfRequired();
            yield return new WaitForSeconds(0.25f);
        }
    }




}
