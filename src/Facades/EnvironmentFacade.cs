using System;
using System.Collections;

namespace Armory.Facades
{
    public class EnvironmentFacade : IEnvironmentFacade
    {
        public string CommandLine { get { return Environment.CommandLine; } }

        public string CurrentDirectory
        {
            get { return Environment.CurrentDirectory; }
            set { Environment.CurrentDirectory = value; }
        }

        public int ExitCode
        {
            get { return Environment.ExitCode; }
            set { Environment.ExitCode = value; }
        }
        
        public bool HasShutdownStarted { get { return Environment.HasShutdownStarted; } }
        
        public bool Is64BitOperatingSystem { get { return Environment.Is64BitOperatingSystem; } }
        
        public bool Is64BitProcess { get { return Environment.Is64BitProcess; } }
        
        public string MachineName { get { return Environment.MachineName; } }
        
        public string NewLine { get { return Environment.NewLine; } }
        
        public OperatingSystem OSVersion { get { return Environment.OSVersion; } }
        
        public int ProcessorCount { get { return Environment.ProcessorCount; } }
        
        public string StackTrace { get { return Environment.StackTrace; } }
        
        public string SystemDirectory { get { return Environment.SystemDirectory; } }
        
        public int SystemPageSize { get { return Environment.SystemPageSize; } }
        
        public int TickCount { get { return Environment.TickCount; } }
        
        public string UserDomainName { get { return Environment.UserDomainName; } }
        
        public bool UserInteractive { get { return Environment.UserInteractive; } }
        
        public string UserName { get { return Environment.UserName; } }
        
        public Version Version { get { return Environment.Version; } }
        
        public long WorkingSet { get { return Environment.WorkingSet; } }

        public void Exit(int exitCode) { Environment.Exit(exitCode); }
        
        public string ExpandEnvironmentVariables(string name) 
        {
            return Environment.ExpandEnvironmentVariables(name); 
        }
        
        public void FailFast(string message) { Environment.FailFast(message); }

        public void FailFast(string message, Exception exception)
        {
            Environment.FailFast(message, exception);
        }
        
        public string[] GetCommandLineArgs() { return Environment.GetCommandLineArgs(); }
        
        public string GetEnvironmentVariable(string variable, EnvironmentVariableTarget target = default(EnvironmentVariableTarget))
        {
            return Environment.GetEnvironmentVariable(variable, target);
        }
        
        public IDictionary GetEnvironmentVariables(EnvironmentVariableTarget target = default(EnvironmentVariableTarget))
        {
            return Environment.GetEnvironmentVariables(target);
        }
        
        public string GetFolderPath(Environment.SpecialFolder folder, Environment.SpecialFolderOption option = default(Environment.SpecialFolderOption))
        {
            return Environment.GetFolderPath(folder, option);
        }
        
        public string[] GetLogicalDrives() { return Environment.GetLogicalDrives(); }

        public void SetEnvironmentVariable(string variable, string value, EnvironmentVariableTarget target = default(EnvironmentVariableTarget))
        {
            Environment.SetEnvironmentVariable(variable, value, target);
        }
    }
}
