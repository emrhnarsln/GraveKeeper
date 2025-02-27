using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawning_Axe : MonoBehaviour
{
    public GameObject axe;

    // Start is called before the first frame update
    void Start()
    {
        spawn_Axe();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawn_Axe()
    {
        Instantiate(axe, transform.position, transform.rotation * Quaternion.Euler(90, 0, 0));
    }
}
