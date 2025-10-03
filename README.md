![CSharp Logo](https://github.com/user-attachments/assets/cbc71c34-30a5-41c3-8ae3-8f01d378a8f8)
This is a Selenium with C# Automation framework just in case I need to use one quick and I don't want to be setting up all from scratch.

## Technologies 👾
- C# (.NET 8.0)
- Selenium
- MSEdge Web Driver
- ReqnRoll
- NUnit
- Allure Reports

## Installing this framework 💾
- Clone the project
- For this we will install Visual Studio 2022
- This framework is currently configured for MS Edge Browser only, but it uses WebDriverManager, so there  is no need to install download the driver.
- For ehnanced visualization and support of the feature files and step install the  _ReqnRoll for Visual Studio 2022_ extension.

## Running Tests 🏃
- You can either run tests from Test Explorer visual interface or via cli. For the following example we will do everything using cli. _Note:_ To execute previous commands, verify you are located inside at the Solution level in the 📟.
- In 📟 type `dotnet test` press Enter
### Run Results
- After every run a _logfile.log_ with execution details will be generated inside _AutomationFrameworkTest/bin/Debug_.
- Once tests finished _allure-results_ folder will be generated (inside _AutomationFrameworkTest/Report_ folder), along with the results.
- To generate human-readable and beautiful HTML report, type in the 📟 `allure generate AutomationFrameworkTest/Reports/allure-results -o AutomationFrameworkTest/Reports/allure-report --clean --single-file`. The report will be generated in _AutomationFrameworkTest/Reports/allure-report_.

## Github Actions ✔️
- In Progress 🚧: I'm currently at the end of my free time so I have around 24hs to finish this or will be a small upgrade in the future.

## Troubleshooting 🔧
- If you see this message on Visual Studio `Test assembly not found. Please build the project to enable the Reqnroll Visual Studio Extension features.`. Rebuild the project and execute the tests. 
- If you add some steps for a feature file and ReqnRoll doesn't see them, just run the test and ReqnRoll will "update" itself and see the new steps.
- If you see the following message: `System.InvalidOperationException : session not created: This version of Microsoft Edge WebDriver only supports Microsoft Edge version 141 Current browser version is 140.0.3485.94 with binary path C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe (SessionNotCreated)` update Selenium Package from NuGetPackage to the most recient versión.

## References
  📟 => Visual Studio Terminal or Power Shell for developers
