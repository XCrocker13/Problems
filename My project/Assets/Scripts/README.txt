Blackjack Project Code Recovery
================================

This folder contains a reconstructed set of the Unity Blackjack scripts based on the code and project details available in the conversation.

IMPORTANT:
- This is a recovery/reconstruction of the scripts, not a recovered copy of the original Unity project.
- The original Unity scene, project settings, imported images, prefabs, packages, and any code not retained in the conversation are not included.
- Some source snippets were summarized rather than preserved verbatim, so compare these files with any code you still have before replacing anything.
- The optional BlackjackUI.cs file was drafted to connect Unity UI text and buttons to BlackJackManager.

Included scripts:
- Card.cs
- Deck.cs
- Hand.cs
- Rank.cs
- Suit.cs
- BlackJackManager.cs
- DeckTester.cs
- SkillCard.cs
- BlackjackUI.cs (optional UI controller)

How to use:
1. Create/open a Unity project.
2. Copy the C# files from Assets/Scripts into that project's Assets/Scripts folder.
3. Make sure each MonoBehaviour script's filename matches its class name.
4. If using BlackjackUI.cs, ensure TextMeshPro is available and assign its Inspector fields.
5. Do not keep duplicate definitions of Rank or Suit in other scripts.
6. For testing, attach DeckTester.cs to a temporary GameObject. Remove/disable it after checking the Console, since it runs tests when the scene starts.

Current scope:
- Standard 52-card deck
- Shuffle and draw
- Blackjack hand values with Aces and face cards
- One player versus CPU round
- Simple Unity UI controller
- Basic SkillCard data class

Not included yet:
- Card-face/card-back prefab and art
- Automatic display of individual card objects
- Roguelike progression, shops, gold, events, save data, and multiple tables
