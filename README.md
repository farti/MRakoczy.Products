## MRakoczy.Products

* [General info](#general-info)
* [Technologies](#technologies)
* [Configuration](#configuration)
* [Print screens](#print-screens)

## General info

*  Simple Net Core 3.0 apliccation, which create Api to CRUD products.


## Technologies

* C#  
* Microsoft.EntityFrameworkCore
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

## Print screens



 
