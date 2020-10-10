using System;

namespace Games.Hangman
{
    class Program
    {
        static void Main()
        {
            string word = Program.GetWord();
            Hangman game = new Hangman(word);

            while (true)
            {
                Console.Clear();
                game.Draw();

                if (game.Lost())
                {
                    Console.WriteLine($"\n\nYOU LOST!\nThe word was: {word}");
                    break;
                }

                Console.Write("\n\nGuess a letter\n> Your choice: ");
                char guess = Console.ReadLine().ToUpper()[0];
                game.Guess(guess);
            }
        }

        static string GetWord()
        {
            string[] words = new string[] { "The quick brown fox jumps over the lazy dog.", "My Mum tries to be cool by saying that she likes all the same things that I do.", "If the Easter Bunny and the Tooth Fairy had babies would they take your teeth and leave chocolate for you?", "A purple pig and a green donkey flew a kite in the middle of the night and ended up sunburnt.", "What was the person thinking when they discovered cow’s milk was fine for human consumption… and why did they do it in the first place!?", "Last Friday in three week’s time I saw a spotted striped blue worm shake hands with a legless lizard.", "Wednesday is hump day, but has anyone asked the camel if he’s happy about it?", "If Purple People Eaters are real… where do they find purple people to eat?", "A song can make or ruin a person’s day if they let it get to them.", "Sometimes it is better to just walk away from things and go back to them later when you’re in a better frame of mind.", "Writing a list of random sentences is harder than I initially thought it would be.", "Where do random thoughts come from?", "Lets all be unique together until we realise we are all the same.", "I will never be this young again. Ever. Oh damn… I just got older.", "If I don’t like something, I’ll stay away from it.", "I love eating toasted cheese and tuna sandwiches.", "If you like tuna and tomato sauce- try combining the two. It’s really not as bad as it sounds.", "Someone I know recently combined Maple Syrup &amp; buttered Popcorn thinking it would taste like caramel popcorn. It didn’t and they don’t recommend anyone else do it either.", "Sometimes, all you need to do is completely make an ass of yourself and laugh it off to realise that life isn’t so bad after all.", "When I was little I had a car door slammed shut on my hand. I still remember it quite vividly.", "The clock within this blog and the clock on my laptop are 1 hour different from each other.", "I want to buy a onesie… but know it won’t suit me.", "I was very proud of my nickname throughout high school but today- I couldn’t be any different to what my nickname was.", "I currently have 4 windows open up… and I don’t know why.", "I often see the time 11:11 or 12:34 on clocks.", "This is the last random sentence I will be writing and I am going to stop mid-sent", "I checked to make sure that he was still alive.", "She had convinced her kids that any mushroom found on the ground would kill them if they touched it.", "The pigs were insulted that they were named hamburgers.", "We will not allow you to bring your pet armadillo along.", "Random words in front of other random words create a random sentence.", "He had accidentally hacked into his company's server.", "Plans for this weekend include turning wine into water.", "She hadn't had her cup of coffee, and that made things all the worse.", "The skeleton had skeletons of his own in the closet.", "The opportunity of a lifetime passed before him as he tried to decide between a cone or a cup.", "It had been sixteen days since the zombies first attacked.", "Mothers spend months of their lives waiting on their children.", "She had a difficult time owning up to her own crazy self.", "Rock music approaches at high velocity.", "She advised him to come back at once.", "Nudist colonies shun fig-leaf couture.", "They desperately needed another drummer since the current one only knew how to play bongos.", "There was coal in his stocking and he was thrilled.", "There should have been a time and a place, but this wasn't it.", "Your girlfriend bought your favorite cookie crisp cereal but forgot to get milk.", "So long and thanks for the fish.", "You have every right to be angry, but that doesn't give you the right to be mean.", "No matter how beautiful the sunset, it saddened her knowing she was one day older.", "They called out her name time and again, but were met with nothing but silence.", "The bullet pierced the window shattering it before missing Danny's head by mere millimeters.", "The beach was crowded with snow leopards." };
            return words[new Random().Next(0, 52)];
        }
    }
}

