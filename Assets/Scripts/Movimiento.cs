using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Movimiento : MonoBehaviour
{
    // Movement
    private static readonly string DistanceCoveredPref = "DistanceCoveredPref";
    private static readonly string StarsCollectedPref = "StarsCollectedPref";

    // Local
    private bool _isMoving = false;
    private int collectedStars = 0;
    private float posXShip = 0;
    private Animator animationController;
    private AudioSource audioManage;
    private float soundVolumeEffects;
    private RightAnimEvents eventRightAnim;
    private LeftAnimEvents eventLeftAnim;

    public float min_distToIncrease = 10;
    public AudioClip audioChangePosition;
    public AudioClip audioGameOver;
    public float speed;
    public float maxHeight;
    public float minHeight;
    public GameObject deadScreen;
    public TextMeshProUGUI scoreTextScreen;
    public TextMeshProUGUI distanceTextScreen;
    public TextMeshProUGUI starsTextScreen;
    public GameObject particleBoost;


    private void Start()
    {
        //Time.timeScale = 0.2f;
        soundVolumeEffects = PlayerPrefs.GetFloat("SoundEffectsPref");
        Time.timeScale = 1;
        audioManage = GetComponent<AudioSource>();
        animationController = GetComponent<Animator>();
        eventRightAnim = animationController.GetBehaviour<RightAnimEvents>();
        eventLeftAnim = animationController.GetBehaviour<LeftAnimEvents>();
    }

    void Update()
    {
        _isMoving = IsMoving();

        if (transform.position.z > min_distToIncrease)
            speed += 0.001f;

        if (distanceTextScreen)
            distanceTextScreen.text = "M" + Mathf.RoundToInt(transform.position.z).ToString();

        if (Input.GetKeyDown(KeyCode.A))
        {
            ButtonLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ButtonRight();
        }

        if (eventLeftAnim.animationEnded)
        {
            eventLeftAnim.animationEnded = false;
            if (Mathf.RoundToInt(transform.position.x) == 0)
            {
                transform.SetPositionAndRotation(new Vector3(0, 0, transform.position.z), Quaternion.identity);
            }
            else
            {
                transform.SetPositionAndRotation(new Vector3(minHeight, 0, transform.position.z), Quaternion.identity);
            }
        }
        if (eventRightAnim.animationEnded) {
   
            eventRightAnim.animationEnded = false;
            if (Mathf.RoundToInt(transform.position.x) == 0)
            {
                transform.SetPositionAndRotation(new Vector3(0, 0, transform.position.z), Quaternion.identity);
            }
            else
            {
                transform.SetPositionAndRotation(new Vector3(maxHeight, 0, transform.position.z), Quaternion.identity);
            }
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("asteroid"))
        {
            audioManage.PlayOneShot(audioGameOver, soundVolumeEffects);
            Time.timeScale = 0;
            deadScreen.SetActive(true);

            int scoreDistance = Mathf.RoundToInt(transform.position.z);
            int acumulativeScore = PlayerPrefs.GetInt(DistanceCoveredPref);
            PlayerPrefs.SetInt(DistanceCoveredPref, scoreDistance + acumulativeScore);

            scoreTextScreen.text = "Your score was " + scoreDistance.ToString() + "m";
        } else if (collider.gameObject.CompareTag("star"))
        {
            collectedStars++;
            int acumulativeStars = PlayerPrefs.GetInt(StarsCollectedPref);
            PlayerPrefs.SetInt(StarsCollectedPref, collectedStars + acumulativeStars);

            Destroy(collider.gameObject);
            starsTextScreen.text = "Collected Stars: " + collectedStars.ToString();
        }
    }

    private bool IsMoving()
    {
        posXShip = Mathf.Round(transform.position.x);

        if (( posXShip > 0.1 && posXShip < maxHeight ) || (posXShip > minHeight && posXShip < - 0.1))
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void ButtonRight()
    {
        if (transform.position.x < maxHeight - 0.8)
        {
            if (!_isMoving)
            {
                audioManage.PlayOneShot(audioChangePosition, soundVolumeEffects);
                animationController.SetTrigger("RightMove");
            }
        }

    }
    public void ButtonLeft()
    {
        if (transform.position.x > minHeight + 0.8)
        {
            if (!_isMoving)
            {
                audioManage.PlayOneShot(audioChangePosition, soundVolumeEffects);
                animationController.SetTrigger("LeftMove");
            }
        }
    }

    public void ButtonBoost()
    {
        if (!_isMoving)
            audioManage.PlayOneShot(audioChangePosition, soundVolumeEffects);
            transform.Translate(Vector3.forward * 8);
            particleBoost.SetActive(true);
            StartCoroutine(DeactivateBoostParticles());
    }


    IEnumerator DeactivateBoostParticles()
    {
        yield return new WaitForSeconds(1.9f);
        particleBoost.SetActive(false);
        StopCoroutine(DeactivateBoostParticles());
    }

}
