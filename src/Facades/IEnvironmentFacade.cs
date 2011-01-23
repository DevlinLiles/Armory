using System;
using System.Collections;

namespace Armory.Facades
{
    public interface IEnvironmentFacade
    {
        string CommandLine { get; }
        string CurrentDirectory { get; set; }
        int ExitCode { get; set; }
        bool HasShutdownStarted { get; }
        bool Is64BitOperatingSystem { get; }
        bool Is64BitProcess { get; }
        string MachineName { get; }
        string NewLine { get; }
        OperatingSystem OSVersion { get; }
        int ProcessorCount { get; }
        string StackTrace { get; }
        string SystemDirectory { get; }
        int SystemPageSize { get; }
        int TickCount { get; }
        string UserDomainName { get; }
        bool UserInteractive { get; }
        string UserName { get; }
        Version Version { get; }
        long WorkingSet { get; }
        void Exit(int exitCode);
        string ExpandEnvironmentVariables(string name);
        void FailFast(string message);
        void FailFast(string message, Exception exception);
        string[] GetCommandLineArgs();
        string GetEnvironmentVariable(string variable, EnvironmentVariableTarget target = default (EnvironmentVariableTarget));
        IDictionary GetEnvironmentVariables(EnvironmentVariableTarget target = default (EnvironmentVariableTarget));
        string GetFolderPath(Environment.SpecialFolder folder, Environment.SpecialFolderOption option = default (Environment.SpecialFolderOption));
        string[] GetLogicalDrives();
        void SetEnvironmentVariable(string variable, string value, EnvironmentVariableTarget target = default (EnvironmentVariableTarget));
    }
}
