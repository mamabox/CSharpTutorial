using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class DartBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private float selfDestroyDelay = 3f;
    [SerializeField] private GameObject particleEffect;
    private GameManager gameMngr;
    // Start is called before the first frame update

    private void Awake()
    {
        gameMngr = GameObject.FindObjectOfType<GameManager>();
    }
    void Start()
    {
        Destroy(gameObject, selfDestroyDelay);  // Dart self destroy after x seconds
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime *speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Balloon")
        {
            Destroy(gameObject, 2.0f);    //Destroy balloon
            Destroy(collision.gameObject);  //Destroy dart
            Instantiate(particleEffect, gameObject.transform.position, gameObject.transform.rotation);
            GameManager.Instance.BalloonPopped();
            
        }
    }
}
