using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YummyPellet : MonoBehaviour
{
    private int timer = 0;
    public int lifespan = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= lifespan)
        {
            Destroy(gameObject);
        }
        else
        {
            timer++;
        }
    }

    public void getNommed()
    {
        Destroy(gameObject);
        Debug.Log("NOM!");
    }
}
