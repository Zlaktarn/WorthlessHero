using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowSoundScript : MonoBehaviour
{
    public RowScript row;
    public AudioSource aSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        aSource.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        //if (row.currentSpeed >0)
        //    aSource.Play();
    }
}
