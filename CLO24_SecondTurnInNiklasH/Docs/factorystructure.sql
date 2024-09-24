+-----------------------+
|        Program        |
|-----------------------|
| - Main()              |
| - CreateVehicle(...)  |
| - DisplayAllVehicles()|
+-----------------------+
         |
         v
+-----------------------+
|    VehicleFactory     | (Abstract Interface)
|-----------------------|
| + CreateVehicle(...)  | (Abstract Method)
+-----------------------+
         ^
         |
         | Implements
         |
+-----------------------+            +-------------------------+
|     CarFactory       |            |    MotorcycleFactory    |
|-----------------------|            |-------------------------|
| + CreateCar(...)     |----------->| + CreateMotorcycle(...) |
+-----------------------+            +-------------------------+
         |                                      |
         |                                      |
         v                                      v
+-----------------------+            +-------------------------+
|  CarImplementation   |            | MotorcycleImplementation|
|-----------------------|            |-------------------------|
| + Car-specific Props |            | + Motorcycle-specific   |
+-----------------------+            |    Props               |
                                      +-------------------------+