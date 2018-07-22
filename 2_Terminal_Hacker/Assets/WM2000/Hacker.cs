using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    int level;
    string chosenPassword;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    string[] bears = { "Papa", "Mama", "Baby" };
    string[,] passwords = new string[3, 5]  {{"fur", "teeth", "honey", "big", "small" },
                                                {"panda", "leaves", "winter", "forest","porridge"},
                                                { "autumn","multiplication","alphabet","hibernate","habitat" }} ;
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
        if (currentScreen == Screen.MainMenu)
        {
            switch (input)
            {
                case "007":
                    Terminal.WriteLine("Meeshy Bond!");
                    Terminal.WriteLine("We've been expecting you!");
                    break;
                case "menu":
                    showMainMenu("Hello Meeshikins");
                    break;
                case "1":
                    StartGame(1);
                    break;
                case "2":
                    StartGame(2);
                    break;
                case "3":
                    StartGame(3);
                    break;
                default:
                    Terminal.WriteLine("Meeshy that's the wrong selection:(");
                    Terminal.WriteLine("Did you boobs get in the way?");
                    break;
            }
        } else if (currentScreen == Screen.Password)
        {
            checkPassword(input);
        }
          else
        {
            showMainMenu("Meeshy-poo");
        }
    }
    private string selectPassword (int level)
    {
        System.Random random = new System.Random();
        return passwords[level, random.Next(1, 5)];
    }

    private string scramblePassword (string password)
    {
        int length = password.Length;
        System.Random random = new System.Random();
        System.Text.StringBuilder scramble = new System.Text.StringBuilder();
        scramble.Append(password);
        print(password);
        for (int i = 0; i < password.Length; i++)
        {
            int j = random.Next(password.Length);
            char temp = scramble[i];
            print(scramble + "first");
            scramble[i] = scramble[j];
            print(scramble + "second");
            scramble[j] = temp;
            print(scramble + "third");

        }
        print(scramble);
        return scramble.ToString();
    }

    private void checkPassword (string input)
    {
        bool victory = false;
        if (input == chosenPassword)
            {
                victory = true;
            }
        if (victory == true)
        {
            Victory();
        } else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("guess again gorgeous ⊂(●￣(エ)￣●)⊃");
            Terminal.WriteLine("You have chosen " + bears[level - 1] + "'s room");
            Terminal.WriteLine("Hint: " + scramblePassword(chosenPassword));
        }
    }
    private void Victory ()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                Terminal.WriteLine(
                   @" 
( • ) ( • )ԅ(‾⌣‾ԅ) 
 \       /        
  )     (       
 (       )      
  \     /      
   \  \/        
    \  \          "); 
                break;
            case 2:
                Terminal.WriteLine(@"
             .------.
            /        `\
          _|_          |
         /   \         | 
         '==='         |
         . ' .         |
        . : ' .        |
           '.          |
       . '    .        |
        .-''' -.       |
       /  \___ \       |
       |/`    \|       |
       (  a  a )       |
       | _\ |  |       |
       )\  =  /        |
   _.- ' '---;         | 

");
                break;
            case 3:
                Terminal.WriteLine(@"
     (()__(()
     \ o o   \
     (_()_)__/ \             
    / _,==.____ \
   (   |--|      )
   /\_.|__|'-.__/\_
   \  \      (     /
   )  '._____)    /    
(((____.--(((____/
");
                break;
        }
        Terminal.WriteLine("Well Done Meeshy, I love you!");
    }
    private void StartGame(int input)
    {
        currentScreen = Screen.Password;
        level = input;
        Terminal.WriteLine("You have chosen " + bears[input - 1] + "'s room");
        Terminal.WriteLine("Please enter the password to get in!");
        chosenPassword = selectPassword(level - 1);
        Terminal.WriteLine("Hint: " + scramblePassword(chosenPassword));
    }

    void Update () {
		
	}
}
