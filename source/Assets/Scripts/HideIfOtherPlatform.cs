﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIfOtherPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID

#elif UNITY_IOS

#else
        gameObject.SetActive(false);

#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
