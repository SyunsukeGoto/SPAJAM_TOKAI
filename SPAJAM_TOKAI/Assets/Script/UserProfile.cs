﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;
using UnityEngine.SceneManagement;

public class UserProfile : MonoBehaviour
{
    private NCMBUser currentUser;

    // Start is called before the first frame update
    void Start()
    {
        currentUser = NCMBUser.CurrentUser;

        string userName = currentUser.UserName;

        Debug.Log(userName);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadRegisterUmbrella()
    {
        SceneManager.LoadScene("RegisterUmbrellaScene");
    }
}