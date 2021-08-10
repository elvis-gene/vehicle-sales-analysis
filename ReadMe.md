This is a .NET console application.

## Note:
- To test the project with a different Json file, put the file under ***/VehicleSalesAnalysis/Data*** and using your IDE, right-click on it and set its ***"Build Action"*** to ***"Content"*** and ***"Copy Output to Directory"*** to ***"Copy if Never"***. And lastly, don't forget to change the ***JsonFileName*** constant inside the ***VehicleSalesAnalysisService*** class.
- Tests were written. To view them, check the test ***(VehicleSalesAnalysis.Tests)*** project. This project can be executed with the command ```dotnet test```
- The file ***Program.cs*** contains the Main method. Inside this class, the methods are called passing the years ***2011*** & ***2020*** as parameters.

### Folders you could look at:
- Factory
- Services
- Models
- Helpers
- Data

The ***Helpers*** folder has ***validation*** code and a common method shared inside the ***VehicleSalesAnalysisService*** class.