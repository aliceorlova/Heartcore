A sample application to utilize Umbraco Content Management and GraphQL Apis.

To run the application, run 'npm install' from the ClientApp directory, and hit that Start button from an IDE of your choice.

In this project, I am using .NET for backend and React.js for frontend.
On button click from the Fetch Data page in the browser, the following logic takes place:
1. A call is made to the public Api to get some sample data in the form of people with the corresponding shows that they have starred in.
The response is limited to 10 people for demo purposes.
2. The received data is then mapped and send to the Umbraco Content Management Api to seed some data. The shows are created first, and people second.
3. Using the Umbraco GraphQL Api, people along with their shows are queried to be returned to the calling controller, and later to the frontend for displaying.

Technical details:    
Each external api connection is separated into its own provider (i.e. ContentManagementApiProvider, PublicApiProvider and GraphQLApiProvider).
Each response from an Api requires a separate model to be used for parsing.
The DataManager class encompasses all of the functionality to perform the import of data and its loading afterwards from Umbraco.

Known issues:
- Image display is not supported, as media types need to be handled before content creation.
- When creating a person, adding shows to that person is not successful either from UI or Api, which may indicate either a permission issue or an incorrect structuring of the request.
- Api keys shouldn't be committed xD

Optimization possibilities:
1. Moving the Logic folder into a separate project in the solution, so the business logic serves as a single source of truth for the application.
2. Creating mappers for model conversions
3. Separating functionality of Importing/Loading data, for example, as so:
    - In the UI, have two different triggers - one for initiating data import, another (which would only be available after the first one is complete) for performing the loading and displaying data
    - Refactor DataManager to support the functionality described above to comply with the Single Responsibility and Interface Segregation principles
4. Moving HttpClient creation functionality to a separate class to be reaused, or using HttpClientFactory.
5. Making the number of items returned from the Public/Umbraco Apis a configurable parameter.
