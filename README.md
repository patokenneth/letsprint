/* A quick and important note: for the purpose of this project, Albelli has five product types: photoBook, calendar, canvas, set of greeting cards and mug.
I have implemented this types as enums. Hence, when running this project on Swagger, ensure that the ProductType you enter is between 0 - 4. It does not
accept a string or anything above 4. Well, I already implemented checks to guard against bad data. So... It's up to you.*/


# letsprint
This is a project I created for Albelli .NET position.

## Description

Albelli's vision is to brighten up the world by bringing people’s moments to life. Essentially, they help people relive their best and lovely moments 
through personalised photo products. In this project, I have built a web API to simulate the process of making orders on Albelli's platform and also
the ability to retrieve the order details using the OrderID.

## Getting Started
This project is on my github repo and has two branches: main and Dev. Start by cloning the main branch of the repo. Afterwards, restore the NuGet packages 
and run migration (that is, add-migration --name). The solution has two projects: the main project called letsprint and the test project named letsprint_test.
If you have followed the instructions above, the solution should start up on swagger when you run it.

### Dependencies

To successfully run this project, you need to have the following software updates installed:
* .NET 5 SDK or above (https://dotnet.microsoft.com/download/dotnet/5.0)

### Installing

This is a public repo, hence, there is no permission needed to get the installation. Simply head over to the url: https://github.com/patokenneth/letsprint

## Issues

* As at the time of writing, this project has been successfully tested and no bug or recurring issue is detected. Kindly ensure that the requisite .NET core runtime/SDK is installed before running the application

## Authors

Contributor(s) names and contact info

* Chiemezie Oloto (chiemezieoloto4@gmail.com)

## Version History
* 1.0.0

* 0.0.0
    * Initial Release

## Acknowledgments

Inspiration, code snippets, etc.
* https://docs.microsoft.com/en-us/aspnet/web-api/overview/
