#Readme Console-App Groep 1D 12/02/2020
          
   ### Requirements:
   - Visual Studio 2019 Community of Enterprise
   - Resharper 
   - .Net framework 
   - dotCover 
   - dotMemory 
   - dotPeek
   - dotTrace
   - Windows 7, 8 or 10 (Windows 10 recommended)
   - Some understanding of C# .Net Framework
          
   * #### .NetCore is prohibbited 
  
   ### File structure:
   - Translations: Json file of the text in the available languages. 
        - The blue part is the name of a translation and that name do u use to refer it in models/translate.cs
   - Documentation: All the UML and documentation files of this project.
   - Models: Houses the models and classes 
        - Calculator holds the methods for add minus divide and module
        - Circle holds the method for creating a "circle" (the food for the Snake)
        - Person holds the model for a person
        - translate holds the model for each and every translation
   - Models/menuItems: These are the models/classes for each menu item
        - When a menu item gets chosen it goes to this here and the things that happen are written in here
   - Handlers: These are the classes that handle things:
        - The ConsoleHandler handles input that get inserted into the console
        - The GameHandler handles inputs in the Snake game
        - The TranslateHandler handles the json files of the translations so the right language is loaded in
   - Game: this folder houses the files for the game Tic Tac Toe