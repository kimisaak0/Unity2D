using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[]        prefabArray;
    [SerializeField]
    private Transform[]         spawnPointArray;
    [SerializeField]
    private int                 objectSpawnCount = 30;
    private int                 currentObjectSpawn = 0;

    private float               moveSpeed = 30.0f;
    private float               ObjectSpawnTime = 0.0f;

    private void Update()
    {
        if(currentObjectSpawn > objectSpawnCount) {
            return;
        }

        ObjectSpawnTime += Time.deltaTime;

        if(ObjectSpawnTime >= 0.5f) {
            int prefabIndex = Random.Range(0, prefabArray.Length);
            int spawnIndex = Random.Range(0, spawnPointArray.Length);

            Vector3     position    = spawnPointArray[spawnIndex].position;
            GameObject  clone       = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);

            clone.GetComponent<Rigidbody2D>().velocity = Vector3.up * moveSpeed;

            currentObjectSpawn++;
            ObjectSpawnTime = 0.0f;
        }

        

        // Color[] colorEnum = new Color[]
        // {Color.black, Color.blue, Color.cyan, Color.gray, Color.green, Color.magenta, Color.red, Color.white, Color.yellow};
        // //for문으로 깔기
        // for(int i = 0 ; i < 10; i++) {
        //     for(int j = 0 ; j < 10; j++) {
        //         Vector3 position = new Vector3((i-5)*1.5f, (j-5)*1.5f, 0);
        //         GameObject clone = Instantiate(boxPrefab, position, Quaternion.identity);
        //         clone.name = "box"+i+""+j;
        //         clone.GetComponent<SpriteRenderer>().color = colorEnum[(i+j)%8];
        //         Debug.Log(i+""+j);
        //     }
        // }

    }
}