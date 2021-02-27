using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour
{

    float horizontal;
    float vertical;
    Rigidbody body;
    public float speed = 5.0f;
    int nbProofFound;

    // Start is called before the first frame update
    void Start()
    {
        nbProofFound = 0;
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        body.velocity = new Vector3(horizontal, 0,  vertical).normalized * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Monster")
        {
            SceneManager.LoadScene("LostGame");
        }

        //if collision avec la porte de sortie
        if (collision.collider.tag == "EndDoor")
        {
            if (nbProofFound == 3)
            {
                SceneManager.LoadScene("WinGame");
            }
        }

    }
    //TODO : créer portes de sortie collider, créer scenes de win et loose, créee trucs trouvables et ramassables, me sucer 4 fois. #DébilitéDeGuillaume
}
