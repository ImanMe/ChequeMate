## ChequeMate - An accounting software 

[Live Demo](https://chequemate.azurewebsites.net/)


> Please make sure you have Visual Studio 2022 (v17.5.1) and .Net 6 and Node (v14.20.1) to run. 

Right-click the solution and select Set Startup Project. Change the startup project from Single startup project to Multiple startup projects. Select Start for both ChequeMate.Api and ChequeMateClient.


>If angular application doesn't show the data, most likely the frontend started before the backend. Once you see the backend swagger page up and running, just refresh the Angular App in the browser

Future enhancments:
1. Increase unit test coverage.
2. Application secret (connection string) to be stored in Azure kevault.
3. Exceptions to be logged to a log management system. eg. splunk, new relic.
4. Add authentication/authorization to the application.
