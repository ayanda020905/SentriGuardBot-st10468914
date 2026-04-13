using System;
using System.Media;
using System.Threading;

namespace SentriGuardBotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SentriGuardBot bot = new SentriGuardBot();
            bot.Start();
        }
    }

    class SentriGuardBot
    {
        private string userName = "";

        public void Start()
        {
            Console.Title = "SentriGuard Bot - Cybersecurity Assistant";

            PlayVoiceGreeting();
            ShowHeader();
            GetUserName();
            ShowWelcomeMessage();
            ChatLoop();
        }

        private void PlayVoiceGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.PlaySync();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Voice file not found. Continuing without audio...");
                Console.ResetColor();
            }
        }

        private void ShowHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("==============================================");
            Console.WriteLine("      ███████╗███████╗███╗   ██╗████████╗");
            Console.WriteLine("      ██╔════╝██╔════╝████╗  ██║╚══██╔══╝");
            Console.WriteLine("      ███████╗█████╗  ██╔██╗ ██║   ██║   ");
            Console.WriteLine("      ╚════██║██╔══╝  ██║╚██╗██║   ██║   ");
            Console.WriteLine("      ███████║███████╗██║ ╚████║   ██║   ");
            Console.WriteLine("      ╚══════╝╚══════╝╚═╝  ╚═══╝   ╚═╝   ");
            Console.WriteLine("        SentriGuard Bot - Cybersecurity Assistant");
            Console.WriteLine("==============================================");

            Console.ResetColor();
        }

        private void GetUserName()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your name: ");
            userName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "User";
            }

            Console.ResetColor();
        }

        private void ShowWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nWelcome {userName}! I'm SentriGuard Bot 🤖");
            Console.WriteLine("Ask me anything about cybersecurity.\n");
            Console.ResetColor();
        }

        private void ChatLoop()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("You: ");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    ShowInvalidInput();
                    continue;
                }

                if (input == "exit" || input == "quit")
                {
                    Console.WriteLine("SentriGuard Bot: Stay safe online! Goodbye 👋");
                    break;
                }

                Respond(input);
            }
        }

        private void Respond(string input)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            if (input.Contains("how are you"))
            {
                TypeText($"I'm doing well, {userName}! Always monitoring cyber threats.");
            }
            else if (input.Contains("your purpose"))
            {
                TypeText("My purpose is to help you stay safe online and learn cybersecurity basics.");
            }
            else if (input.Contains("what can i ask"))
            {
                TypeText("You can ask me about passwords, phishing, and safe browsing.");
            }
            else if (input.Contains("password"))
            {
                TypeText("Use strong passwords with numbers, symbols, and uppercase letters.");
            }
            else if (input.Contains("phishing"))
            {
                TypeText("Phishing is when attackers trick you into giving personal information.");
            }
            else if (input.Contains("safe browsing"))
            {
                TypeText("Only visit trusted websites and avoid clicking unknown links.");
            }
            else
            {
                ShowInvalidInput();
            }

            Console.ResetColor();
        }

        private void ShowInvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("SentriGuard Bot: I didn’t quite understand that. Could you rephrase?");
            Console.ResetColor();
        }

        private void TypeText(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }
    }
}