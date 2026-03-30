**Note:** Main implementation is available in the `master` branch.

## Description
This is a simple console application written in C# that simulates a university equipment rental system. The system allows users to borrow and return equipment and checks if items are available.
## Functionality
- adding users (students and employees)
- adding equipment (laptops, projectors, cameras)
- renting equipment
- returning equipment (with penalty for late return)
- checking available equipment
- viewing active and overdue rentals
- generating a simple summary
## Project structure
The project is divided into a few parts:
- Models – classes like Equipment, User, Rental
- Services – logic for handling operations (renting, returning, etc.)
- Policies – rules for limits and penalties
- Enums – equipment status
- Exceptions – handling errors (like unavailable equipment)
## Design decisions
Keep the code simple and readable.  
The responsibilities are divided between classes, so each class does one main thing.
Business rules like rental limits and penalties are placed in separate classes (Policies), so they are easy to change.
Services handle operations.
Example change in feature branch.
