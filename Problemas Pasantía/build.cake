#addin "nuget:?package=System.Runtime.InteropServices.RuntimeInformation&version=4.3.0"

using System.Runtime.InteropServices;

var target = Argument("target", "Publish");
var configuration = Argument("configuration", "Release");
var compileAll = Argument("compileAll", false);

var solutionFolder = "./";
var outputFolder = "./Builds";
var currentRID = RuntimeInformation.RuntimeIdentifier;

string[] runtimes = new string[]
{
    "win-x64",
    "win-x86",
    "osx-x64",
    "linux-x64"
};

Task("Clean")
    .Does(()=>{
        CleanDirectory(outputFolder);
    });

Task("Publish")
    .IsDependentOn("Clean")
    .Does(()=>{
        string outFolder = $"{outputFolder}/{currentRID}";
        var publishConfiguration = new DotNetCorePublishSettings(){
            Configuration = configuration,
            OutputDirectory = outFolder,
            SelfContained = true,
            PublishTrimmed = true,
            Runtime= currentRID,
        };

        if (!compileAll)
        {
            DotNetCorePublish(solutionFolder, publishConfiguration);
            return;
        }

        foreach (var runtime in runtimes)
        {
            outFolder = $"{outputFolder}/{runtime}";
            publishConfiguration.OutputDirectory = outFolder;
            publishConfiguration.Runtime = runtime;

            DotNetCorePublish(solutionFolder, publishConfiguration);
        }
    });

RunTarget(target);