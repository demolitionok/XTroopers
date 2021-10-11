using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class StartGroundSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabsToSpawn;
    [SerializeField]
    private int amountToSpawn = 1;
    [SerializeField]
    private Vector2 startBorder;
    [SerializeField]
    private Vector2 endBorder;
    
    [SerializeField]
    private float heightToRaycastDownFrom = 100;

    private Vector3 GetGroundPosition(Vector2 flatOrigin)
    {
        var origin = new Vector3(flatOrigin.x, heightToRaycastDownFrom, flatOrigin.y);
        Physics.Raycast(origin, Vector3.down, out var hit, heightToRaycastDownFrom + 100);
        return hit.point;
    }

    private Vector2 RandomVector()
    {
        var smallerX = Mathf.Min(startBorder.x, endBorder.x);
        var smallerY = Mathf.Min(startBorder.y, endBorder.y);
        var biggerX = Mathf.Max(startBorder.x, endBorder.x);
        var biggerY = Mathf.Max(startBorder.y, endBorder.y);
        
        var x = Random.Range(smallerX, biggerX);
        var z = Random.Range(smallerY, biggerY);

        return new Vector2(x, z);
    }

    private void SpawnGameObjects()
    {
        for (int i = 0; i <= amountToSpawn; i++)
        {
            var gameObj = prefabsToSpawn.RandomElement();
            var groundPosition = GetGroundPosition(RandomVector());
            Instantiate(gameObj, groundPosition, Quaternion.identity);
        }
    }

    private void Start()
    {
        SpawnGameObjects();
    }
}
