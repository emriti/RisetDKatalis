# Parking Lot Problem

## Setup application

Run bash ```setup``` in ```bin``` directory
```sh
parking_lot $ bin/setup
```
That command has automatically run unit testing, unit testing commands contained in the file  ```bin/run_functional_tests```

This application fully controlled by command. Run bash ```parking_lot``` in bin directory with 2 options:

* The inputs commands are expected and taken from the file specified
```sh
parking_lot $ bin/parking_lot [input_filepath]
```
* Or start the program in interactive mode.
```sh
parking_lot $ bin/parking_lot
```
**Command list**

* ```>> create_parking_lot [capacity]```
Initialization of parking lot with parameters of slot capacity. This command must be run first to initialize the parking lot.

* ```>> park [car_registration_number] [car_color]```
The parking car in available slot with identity of registration number and color.
If success, program will print ```Allocated slot number: [nearest_slot_number]```. If failed,
(parking lot is full, slot already filled) will print ```Sorry, parking lot is full```

* ```>> leave [slot_number]```
The slot is available again after the car leaves the parking lot (give the entrance ticket) so that the slot can be occupied by the another car will park.

* ```>> status```
For print parking area status in table format.
```Slot No.    Registration No     Colour```

