# GO-JEK Parking Lot (Net Core Version)

## Background

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
#### slot_numbers_for_cars_with_colour **\<colour:string\>**
#### slot_number_for_registration_number **\<slot number:number\>**
#### help
  
## How to run the application in Console
Before running the application, you need to install [Netcore 3.1] (https://dotnet.microsoft.com/download/dotnet-core/3.1) and you need to change the current directory to .\Ecomindo.Riset.DKatalis\GojekParkingLotConsole. After that running the command below.

```
$ dotnet run 
```

List of the command can be seen at [Command List](##command-list)

## How to run the application in Docker

## How to test the application
