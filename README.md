#A. Summary 

TerbilangApp develop based on web asp.net mvc application, the functionality is to converting currency number / amount in USD to words. 

#B. Pre-requisite  

Development Tools : Visual Studio 2017 Community Version 15.54
Framework : .NET Framework 4.6 ,  asp.net MVC 5.2.3.0
Nuget Component : Unity.Mvc5


#C. How to Open, Install  and run the project


Clone source code from git repository (Muhamad Muchlis)

> git clone https://github.com/tru3d3v/terbilangApp.git	 
Open Solution file : terbilangApp\Terbilang.sln open with your Visual Studio 2017 

Make sure you have good internet connection, you could not rebuild component from nuget if you have an issue with internet connection.

Build All Solution,  On top Menu Visual Studio. Choose the menu Build > Rebuild Solution
If you want to Test backend Functionality, you can run UnitTestProject.  Open file UnitTest.cs and then on top Menu Visual studio Choose the menu Test > Run > All Tests in the left side panel of your Visual Studio, you can see Test Explorer Panel and you can see Passed Test with the green checklist "TestTranslate" 


Run the presentation Project WebApp. Open file WebApp\NumberToWordController.cs and then on the top Menu Visual Studio, Choose Project> Set As Startup Project and then on top menu Visual studio, Choose Debug > Start Debuging or press F5 with your keyboard. If you succeed, the Web page will be appear.  
