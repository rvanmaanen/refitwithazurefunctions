It appears that when adding an interface annotated with Refit attributes to a project containing Azure Functions, some conflict occurs, which results in the following error: "System.IO.FileNotFoundException: Could not load file or assembly 'System.Net.Http, Version=4.1.1.2, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' or one of its dependencies. The system cannot find the file specified."
This appears to be linked to the Visual Studio tooling, probably the Azure Functions and Web Jobs Tools (currently using 15.0.40413.0, together with Visual Studio 15.7.0 Preview 4), because building from the commandline works fine.

![ThisIsBroken](https://github.com/rvanmaanen/refitwithazurefunctions/blob/master/ThisIsBroken/Screenshot.png "ThisIsBroken")

A workaround is to add the Refit interface to a seperate project, which you can then reference from the project with the Azure Functions.
The conflict probably happens because both Refit and Functions generate files when building and are using different DLL versions, and this way of setting up projects adds an order to the build sequence, instead of both build targets triggering on the same project.

![ThisWorks](https://github.com/rvanmaanen/refitwithazurefunctions/blob/master/ThisWorks/Screenshot.png "ThisWorks")
