# JSON Flattener ✨

JSON Flattener is a console app which I wrote in C#. It was created as an assignment for the [Mongo DB](https://www.mongodb.com) company. JSON Flattener can flatten simple JSON files 
(so such without arrays). It can be run using the console and thanks to .NET Core can be used on any major operating system.

**Before**
```
{
    "a": 1,
    "b": true,
    "c": {
        "d": 3,
        "e": "test"
    }
}
```

**After**
```
{
    "a": 1,
    "b": true,
    "c.d": 3,
    "c.e": "test"
}
```

# Usage 👨‍💻

To use the app it's recommended to download it from this repository. After that, open the terminal in the project's location (JSON-Flattener, where there are two .cs files) and type:
```
dotnet build
```
After project building process is done (it can take a second), run the program using:
```
dotnet run <JSON location>
```
where *JSON location* is a full location of the JSON file on your computer. After a second JSON Flattener will print a flattened version of the provided JSON file
to the standard output. 

# Testing 💡

There are four tests already implemented in the project. They can be used to test the validity of the program.

# FAQ 🤔

**1. Why C# if the app could be implemented in any language?**

Because I think that it was the best language for that problem. JSON files are parsed using awesome *JSON .NET* library which is obviously available only for
.NET. What is more, I usually used Java for such projects - it was fun to write it in something different. 

**2. Why are there some if / else statements instead of switch statements?**

That's a fun story, but we were actually discouraged from using switch statements on the university on the Object-Oriented Design course. And because of my
respect for the professor teaching this subject I decided not to use switch statement. Other than that, there are really no major reasons - code can be quickly
rewritten to use it.
