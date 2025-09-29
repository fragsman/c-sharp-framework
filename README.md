# c-sharp-framework
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
- In 📟 type `dotnet test` and press Enter
- Once tests finished _allure-results_ folder will be generated (inside _AutomationFrameworkTest/Report_ folder), along with the results.
- To generate human-readable and beautiful HTML report, type in the 📟 `allure generate AutomationFrameworkTest/Reports/allure-results -o AutomationFrameworkTest/Reports/allure-report --clean --single-file`. The report will be generated in _AutomationFrameworkTest/Reports/allure-report_.


## Github Actions ✔️
- TBD

## Troubleshooting 🔧
- If you see this message on Visual Studio `Test assembly not found. Please build the project to enable the Reqnroll Visual Studio Extension features.`. Rebuild the project and execute the tests. 
- If you add some steps for a feature file and ReqnRoll doesn't see them, just run the test and ReqnRoll will "update" itself and see the new steps.

## References
  📟 => Visual Studio Terminal or Power Shell for developers