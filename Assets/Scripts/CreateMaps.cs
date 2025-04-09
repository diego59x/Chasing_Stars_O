using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreateMaps : MonoBehaviour
{
    public GameObject[] map;
    public GameObject player;
    private int dist = 0;
    int rand; 

    void Update()
    {
        if (player) {

            if ((player.transform.position.z) > dist - 35) {
                rand = Random.Range(0, map.Length);
                GameObject clonMp = Instantiate(map[rand], new Vector3(0, 0, dist), Quaternion.identity) as GameObject;
                Destroy(clonMp, 15);
                dist += 28;
            }

        } else {
            Time.timeScale = 0;
        }

    }

    public void reloadGame() 
    {
        SceneManager.LoadScene("Main");
    }
}
