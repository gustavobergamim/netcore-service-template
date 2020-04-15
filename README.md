# Getting Started

## Installing Template

Installing this template to .Net CLI using `dotnet new` tool.

1. Run `dotnet new -i <PROJECT_DIR>`, where `<PROJECT_DIR>` is the directory where this template is in.
   
2. You'll see a list of available `dotnet new` templates, like this:
   
   ```
    Templates                                         Short Name               Language          Tags                                 
    ----------------------------------------------------------------------------------------------------------------------------------
    Console Application                               console                  [C#], F#, VB      Common/Console                       
    Class library                                     classlib                 [C#], F#, VB      Common/Library                       
    WPF Application                                   wpf                      [C#]              Common/WPF                           
    WPF Class library                                 wpflib                   [C#]              Common/WPF                           
    WPF Custom Control Library                        wpfcustomcontrollib      [C#]              Common/WPF                           
    WPF User Control Library                          wpfusercontrollib        [C#]              Common/WPF                           
    Windows Forms (WinForms) Application              winforms                 [C#]              Common/WinForms                      
    Windows Forms (WinForms) Class library            winformslib              [C#]              Common/WinForms                      
    Worker Service                                    worker                   [C#]              Common/Worker/Web                    
    Unit Test Project                                 mstest                   [C#], F#, VB      Test/MSTest                          
    NUnit 3 Test Project                              nunit                    [C#], F#, VB      Test/NUnit                           
    NUnit 3 Test Item                                 nunit-test               [C#], F#, VB      Test/NUnit                           
    xUnit Test Project                                xunit                    [C#], F#, VB      Test/xUnit                           
    Razor Component                                   razorcomponent           [C#]              Web/ASP.NET                          
    Razor Page                                        page                     [C#]              Web/ASP.NET                          
    MVC ViewImports                                   viewimports              [C#]              Web/ASP.NET                          
    MVC ViewStart                                     viewstart                [C#]              Web/ASP.NET                          
    Blazor Server App                                 blazorserver             [C#]              Web/Blazor                           
    ASP.NET Core Empty                                web                      [C#], F#          Web/Empty                            
    ASP.NET Core Web App (Model-View-Controller)      mvc                      [C#], F#          Web/MVC                              
    ASP.NET Core Web App                              webapp                   [C#]              Web/MVC/Razor Pages                  
    ASP.NET Core with Angular                         angular                  [C#]              Web/MVC/SPA                          
    ASP.NET Core with React.js                        react                    [C#]              Web/MVC/SPA                          
    ASP.NET Core with React.js and Redux              reactredux               [C#]              Web/MVC/SPA                          
    Razor Class Library                               razorclasslib            [C#]              Web/Razor/Library/Razor Class Library
    ASP.NET Core Web API                              webapi                   [C#], F#          Web/WebAPI                           
    ASP.NET Core gRPC Service                         grpc                     [C#]              Web/gRPC                             
    Projeto Base para APIs                            dotnet-api               [C#]              WebApi/Class Library/Console
    dotnet gitignore file                             gitignore                                  Config                               
    global.json file                                  globaljson                                 Config                               
    NuGet Config                                      nugetconfig                                Config                               
    Dotnet local tool manifest file                   tool-manifest                              Config                               
    Web Config                                        webconfig                                  Config                               
    Solution File                                     sln                                        Solution                             
    Protocol Buffer File                              proto                                      Web/gRPC
   ```
   
   Note that our project template "Projeto Base para APIs" was added to this list.

## Using Template

To create a project using this template, run:

```bash
dotnet new dotnet-api -n ProjectPreffix -o ProjectDir
```

Where:

1. `ProjectPreffix` is the name that will be replaced in every occurrence of` ProjetoBase` in the template. Both in source code and directories.

2. `ProjectDir` is the directory name where project will be created.

## Uninstalling Template

To remove this template, you'll need to run the same command used to install, changing the `-i` switch to `-u`.

Run `dotnet new -u <PROJECT_DIR>`, where `<PROJECT_DIR>` is the directory where this template is in.