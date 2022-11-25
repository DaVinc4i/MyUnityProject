using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewUser
{
    public string name;
    public int health;
    public int id;

    public void Move()
    {

    }

}

public class Temp : MonoBehaviour
{
    struct User
    {
        public string name;
        public int health;
        public int id;
    }

    NewUser myClass;

    void Start()
    {
        User user = new User();
        user.name = "Василий";
        user.health = 100;
        user.id = 1;

        Debug.Log(user.name);

        myClass = new NewUser();
        myClass.name = "Егор";
        myClass.health = 120;
        myClass.id = 2;

        Debug.Log(myClass.name);
    }

    
    void Update()
    {
        
    }
}
