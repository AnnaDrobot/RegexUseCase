# Regex Use Case

# App description

This app presents a method (inside Program class) named IsMatch, which validates various inputs using a regex. There are 10 different tests for this method in RegexUseCaseTests project. This regular expression validates as correct only those inputs, which comply with the following requirements:
- the input isn't longer than the required length (length value is also passed as a parameter for IsMatch method)
- the input contains at least one uppercase letter, one lowercase letter, one digit, and one special character from a predefined list: !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~
- the input doesn't contain any whitespace characters

# Regular expression description

The regex expression looks like this in the code:

```
var pattern = @"^(?=.{1," + maxLength + @"}$)(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!\x22#\$%&'\(\)\*\+,-\./:;<=>\?@\[\\\]\^_`{\|}~])([A-Za-z\d]|[!\x22#\$%&'\(\)\*\+,-\./:;<=>\?@\[\\\]\^_`{\|}~])*$";
```

The first part, ``` @"^(?=.{1," + maxLength + @"}$)  ``` uses positive lookahead to set the maximum length of the input. It matches the anchor ^ (start of the string), if it is followed by characters of any type (excluding line terminators), the total number of which should be between 1 and maxLength. There's no other limitations on character types on this step.

The second part, ``` (?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!\x22#\$%&'\(\)\*\+,-\./:;<=>\?@\[\\\]\^_`{\|}~]) ``` adds the limitation of character types that can be used. This part includes four positive lookahead operators to add these limitations. The first one, ``` (?=.*[A-Z]) ``` captures any characters, if they are followed by an uppercase latin character. At this stage, only the line start terminator would be captured, if it is followed by at least one character of every type needed. Because ``` .* ``` is used in every positive lookahead, it doesn't matter in which order the characters will be placed. When positive lookahead operator meets the first character of the needed type (uppercase character for ``` [A-Z] ```, lowercase character for ``` [a-z] ```, digit for ``` \d ```, special characters from this list ``` !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~ ``` for ``` [!\x22#\$%&'\(\)\*\+,-\./:;<=>\?@\[\\\]\^_`{\|}~] ```), it returns a match on this stage. All the other positive lookahead operators work the same here.
There are also cases of quoting some characters (or using hex codes) in the list of allowed special characters, so they will be processed correctly.

The final part, ``` ([A-Za-z\d]|[!\x22#\$%&'\(\)\*\+,-\./:;<=>\?@\[\\\]\^_`{\|}~])*$ ``` actually captures all the needed characters and marks the line end terminator. It uses ``` | ``` operator, to visually divide the easy-to-read part (``` [A-Za-z\d] ``` for uppercase characters, lowercase characters, and digits) and a part with the list of all the needed special characters. It also uses ``` ()* ``` to capture any characters from the parentheses unlimited amount of times (althouth the length limit is actually defined in the first part).

# How to run locally

To run this application locally, you need to install .NET 6 SDK.

There are two ways to run tests locally:

- install Microsoft Visual Studio 2022, open this project in Microsoft Visual Studio, build the project, open Test Explorer window, select all the tests and then click "Run All Tests In View" button.
- open command line in the "\RegexUseCase\RegexUseCase" directory and run ``` dotnet build; dotnet test ``` command.
