﻿using System;
using AssetManagerPackage;
using GAIPS.Rage;
using RolePlayCharacter;
using WellFormedNames;

namespace RolePlayCharacterTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
			AssetManager.Instance.Bridge = new BasicIOBridge();
            //Loading the asset
	        var rpc = RolePlayCharacterAsset.LoadFromFile("../../../Examples/RPCTest.rpc");
            rpc.Initialize();
            var eventStr = "Event(Action-Finished, Player, Kick, "+ rpc.CharacterName + ")";
            var action = rpc.PerceptionActionLoop(new []{(Name)eventStr})?.ActionName;
            Console.WriteLine("The name of the character loaded is: " + rpc.CharacterName);
            Console.WriteLine("The following event ocurred: " + eventStr);
            Console.WriteLine("Mood after event: " + rpc.Mood);
            Console.WriteLine("Strongest emotion: " + rpc.GetStrongestActiveEmotion()?.EmotionType + "-" + rpc.GetStrongestActiveEmotion()?.Intensity);
            Console.WriteLine("Response: " + action?.ToString());
            Console.ReadKey();
            rpc.SaveConfigurationToFile("../../../Examples/RPCTest-Output.rpc");
        }
    }
}
