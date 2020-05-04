# GO-JEK Parking Lot (Net Core Version)

## Background
These are my interpretation of developing GO-JEK Parking Lot with .NET Core 3.1. The application were developed using three tier architecture (presentation layer - business logic layer - data access layer). The structure of the application is derived from the architecture that were mentioned before. The description of the parking lot can be seen in (ParkingLot-1.3.0.pdf)[https://github.com/emriti/RisetDKatalis/blob/master/ParkingLot-1.3.0.pdf]. This application can be executed using command line / bash interactively or by inserting a command file. The application can also run on docker. This application has been tested using xUnit 2.4.0 with code coverage 97%.

## Command List
These are syntaxes for running the application:

#### create_parking_lot **\<capacity:number\>** 
This command for creating a parking lot, capacity is number of cars that can be accomodated by the parking lot.

#### park **\<registration no:string\>** **\<colour:string\>**
This command to park a car, it need car registration number and colour.

#### leave **\<slot no:number\>**
This command to unpark a car, it needs the slot number that the car parked before.

#### status
This command for displaying the parked cars, it shows slot number, registration number and colour.

#### registration_numbers_for_cars_with_colour **\<colour:string\>**
This command to show registration number of a parked car with specific colour.

#### slot_numbers_for_cars_with_colour **\<colour:string\>**
This command to show slot number of a parked with specific colour.

#### slot_number_for_registration_number **\<slot number:number\>**
This command to show slot number of a parked car by registration number.

#### help
This command to show available commands.

## How to run the application in Console
Before running the application, you need to install [Netcore 3.1] (https://dotnet.microsoft.com/download/dotnet-core/3.1) and you need to change the current directory to .\Ecomindo.Riset.DKatalis\GojekParkingLotConsole. After that running the command below.

```
$ dotnet run 
```

Or, if you want to run it with a file, you can do that with:

```
$ dotnet run \<filepath\>
```

List of the command can be seen at [Command List](#command-list)

## How to run the application in Docker

## How to test the application
