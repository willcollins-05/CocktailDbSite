# Cocktail Db Data Aggregation Capstone
___
Cocktail Db Data Aggregation is a project created by Will Collins, Daniel Blidchenko, 
Lucas Borton, Trent Grooms, and Jennifer Opperman using .NET 10 and a Blazor web application 
containing information regarding all types of drinks, alcoholic or not. 

This project uses the [Cocktail DB](https://www.thecocktaildb.com) free API to source
the data. User data and related information is stored in a database hosted on
[Neon DB](https://neon.com). The entire application is being hosted on 
[Microsoft Azure](https://azure.microsoft.com/en-us).

## Running the project locally
___
### Environment Variables
Set up the user secrets in the CocktailDbSite.Client by doing the following in the terminal.
```
cd CocktailDbSite.Client
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "{YOUR CONNECTION STRING HERE}"
```
Doing this creates a secrets.json file that will secure your personal connection string,
keeping it out of version control. 

If you want to verify that it worked properly, you can run the following command while 
still in the CocktailDbSite.Client project in the terminal
```
dotnet user-secrets list
```

### Running the project
Make sure to run the project with the following configuration (if you are not using this one specifically, you will not be able to access authentication services): 
``` 
CocktailDbSite.Client: https
```
