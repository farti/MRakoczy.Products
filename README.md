## MRakoczy.Products

* [General info](#general-info)
* [Technologies](#technologies)
* [Configuration](#configuration)
* [Postman](#postman)

## General info

*  Simple .Net Core 3.0 apliccation, which create Api to CRUD products.


## Technologies

* C#  
* .Net Core 3.0
* Microsoft.EntityFrameworkCore
* AutoMapper


## Configuration


* Create empty MSSQL datbase and update ConnectionStrings in appsettings.json
  
 ```json
{
  "ConnectionStrings": {
    "Default": "server=DESKTOP-M\\SQLEXPRESS; database=Products; Integrated Security=SSPI"
  },

  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

* Go to Package Manager Console and run Update-Database
* Build and run app !

## Postman


[Postman CRUD](../blob/master/MRakoczy.Products/Postman/Product.postman_collection.json)



 
