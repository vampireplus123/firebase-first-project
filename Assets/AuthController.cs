using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Firebase.Auth;
using UnityEngine;
using System.Threading.Tasks;

public class AuthController : MonoBehaviour
{
    public Text MailInput, PasswordInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void Login()
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(MailInput.text,
        PasswordInput.text).ContinueWith((Task => {
            if (Task.IsCanceled)
            {
                Firebase.FirebaseException e = 
                Task.Exception?.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorMessage((AuthError)e.ErrorCode);
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (Task.IsFaulted)
            {
                Firebase.FirebaseException e = 
                Task.Exception?.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorMessage((AuthError)e.ErrorCode);
                return;
            }
            if(Task.IsCompleted)
            {
                Debug.Log("User signed in successfully!");
            }
        }));
    }
    public void Login_Anonymous()
    {

    }
    public void Register()
    {
        if(MailInput.text.Equals("") && PasswordInput.text.Equals(""))
        {
            print("Please enter your Email or Password");
            return;
        }
        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(MailInput.text,
        PasswordInput.text).ContinueWith((Task =>{
            if(Task.IsCanceled)
            {
                Firebase.FirebaseException e = 
                Task.Exception?.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorMessage((AuthError)e.ErrorCode);
                return;
            }
            if(Task.IsCanceled)
            {
                Firebase.FirebaseException e = 
                Task.Exception?.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorMessage((AuthError)e.ErrorCode);
                return;
            }
            if(Task.IsCompleted)
            {
                Debug.Log("User created successfully!");
            }
        }));
    }
    public void Logout()
    {

    }

    void GetErrorMessage(AuthError errCode)
    {
        string msg = "";
        msg  = errCode.ToString();
        print(msg);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
