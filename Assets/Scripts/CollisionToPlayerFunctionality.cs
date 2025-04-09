using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionToPlayerFunctionality : MonoBehaviour
{
    private int rand;
    private GameObject clonObj;
    private int dist = 150;
    private Vector3 positionPlayerToHit;
    private float soundVolumeEffects;
    private AudioSource audioManageEffects;
    
    public AudioClip asteroidAppear;
    public GameObject player;
    public GameObject[] throwableObjects;
    public float speed = 10.0f;

    private void Start()
    {
        soundVolumeEffects = PlayerPrefs.GetFloat("SoundEffectsPref");
        audioManageEffects = GetComponent<AudioSource>();
        audioManageEffects.volume = soundVolumeEffects;
    }
    void Update()
    {
        if (player)
        {
            if ((player.transform.position.z) > dist && !clonObj)
            {
                audioManageEffects.PlayOneShot(asteroidAppear, soundVolumeEffects);
                rand = Random.Range(0, throwableObjects.Length);

                int randX = Random.Range(-5, 5);
                int randY = Random.Range(-5, 5);
                int randZ = (int)player.transform.position.z + 20;

                clonObj = Instantiate(throwableObjects[rand], new Vector3(randX, randY, randZ), Quaternion.identity) as GameObject;
                Destroy(clonObj, 4);
                dist += 15;
                positionPlayerToHit = player.transform.position;
            }
            var step = speed * Time.deltaTime;
            if (clonObj)
            {
                clonObj.transform.position = Vector3.MoveTowards(clonObj.transform.position, positionPlayerToHit, step);
            }
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
