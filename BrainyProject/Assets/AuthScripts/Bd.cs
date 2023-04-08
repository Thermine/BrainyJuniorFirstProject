using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class Bd : MonoBehaviour
{
    DatabaseReference _bdRef;


    private void Awake()
    {
        Firebase.FirebaseApp.Create();
    }
    void Start()
    {
        
        _bdRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SaveData(string playeName, int playerAge, int playerKnowledge, string playerSex)
    {
        User user = new User(playeName, playerAge, playerKnowledge, playerSex);
        string json = JsonUtility.ToJson(user);
        _bdRef.Child("Users").Child(playeName).SetRawJsonValueAsync(json);
    }

    public class User
    {
        public string name;
        public int age;
        public int knowledge;
        public string sex;

        public User(string name, int age, int knowledge, string sex)
        {
            this.name = name;
            this.age = age;
            this.knowledge = knowledge;
            this.sex = sex;
        }
    }

}
