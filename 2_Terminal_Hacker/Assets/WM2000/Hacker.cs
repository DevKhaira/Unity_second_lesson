using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    string[] bears = { "Papa", "Mama", "Baby" };
    // Use this for initialization
    void Start () {
        string greeting = "Hello Meeshilocks";
        showMainMenu(greeting);
    }
    void showMainMenu (string greeting) {

        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Where do you want to sleep?");
        Terminal.WriteLine(" ");

        for (int i = 0; i < bears.Length; i++) {
            int number = i + 1;
            Terminal.WriteLine("Press " + number + " for " + bears[i] + " Bear");
        }

        Terminal.WriteLine("  ");
        Terminal.WriteLine("Enter your number:");
    }
    // Update is called once per frame
    void OnUserInput (string input)
    {
        switch (input) {
            case "007":
                Terminal.WriteLine("Meeshy Bond!");
                Terminal.WriteLine("We've been expecting you!");
                break;
            case "menu":
                showMainMenu("Hello Meeshikins");
                break;
            case "1":
                startGame(1);
                break;
            case "2":
                startGame(2);
                break;
            case "3":
                startGame(3);
                break;
            default:
                 Terminal.WriteLine("Meeshy that's the wrong selection:(");
                 Terminal.WriteLine("Did you boobs get in the way?");
                 break;
            }
    }

    private void startGame(int input)
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen " + bears[input - 1] + "'s room");
        Terminal.WriteLine("Please enter the password to get in!");
    }

    void Update () {
		
	}
}
