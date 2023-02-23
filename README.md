# Api-Automation

# Pre-requisites
1. VSCode/Visual Studio
2. [.NET Core SDK 7.0.200]( https://dotnet.microsoft.com/en-us/download/dotnet/7.0 )

# Setup Guide
1. Clone or download the project from GitHub
2. Import the project into VSCode/Visual Studio
3. Open the terminal in VSCode/Visual Studio and execute following commands
    **dotnet restore**
    **dotnet build**
4 Execute the tests from \Api-Automation-Test\test folder or you can use below command to run the tests \
    **dotnet test**

# Test Result
1. Test reports will be generated under the folder below after each successful test execution
 \Api-Automation-Test\html-report\index.html 

# Test Execution

Method-1: Run the below batch file (located in project main folder) in command prompt

**api-automation.bat**

Method-2: Open Developer Powershell in Visual Studio and run the following command

dotnet test "Api-Automation-Test"
