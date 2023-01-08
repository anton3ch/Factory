# Dr. Sillystringz's Factory

#### Tracks Dr. Sillystringz's Factory engineers and machines

#### By [Anton Ch](https://github.com/anton3ch)

## Technologies Used

- CSS
- HTML
- C#
- .NET 5.0
- ASP.Net
- Razor
- dotnet script REPL
- MySQL
- Workbench
- EF Core

## Description

Dr. Sillystringz's Factory lets owner add and track their engineers and machines.

## Setup/Installation Requirements

- Clone this repository to your Desktop:
  1. Your computer will need to have GIT installed. If you do not currently have GIT installed, follow [these](https://docs.github.com/en/get-started/quickstart/set-up-git) directions for installing and setting up GIT.
  2. Once GIT is installed, clone this repository by typing following commands in your command line:
     ```
     ~ $ cd Desktop
     ~/Desktop $ git clone https://github.com/anton3ch/Factory.Solution.git
     ~/Desktop $ cd Factory.Solution
     ```
- Install the [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Install Packages for EF Core and a tool to update databases:
  ```
  ~/Desktop/Factory.Solution $ dotnet add package Microsoft.EntityFrameworkCore -v 6.0.0
  ~/Desktop/Factory.Solution $ dotnet add package Pomelo.EntityFrameworkCore.MySql -v 6.0.0-alpha.2
  ~/Desktop/Factory.Solution $ dotnet tool install --global dotnet-ef --version 6.0.1
  ```
- Create .gitignore file:
  ```
   ~/Desktop/Factory.Solution/ $ touch .gitignore
   ~/Desktop/Factory.Solution/ $ echo "*/obj/
   */bin/
   */appsettings.json" > .gitignore
  ```
- Create appsettings.json file:
  ```
   ~/Desktop/Factory.Solution $ cd Factory
   ~/Desktop/Factory.Solution/Factory $ touch appsettings.json
   ~/Desktop/Factory.Solution/Factory $ echo '{
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=anton_ch_factory;uid=root;pwd=[PASSWORD];"
      }
    }' > appsettings.json
  ```
  [PASSWORD] is your password

  - Create MySQL database
  ```
    Open MySQLWorkbench, log in, and connect to your local server
    Go to the Administration tab, select Data Import/Restore
    Select Import from Self Contained File
    Select ../anton_ch.sql from the top level of the cloned repository, HairSalon.
    Select "New..." and set new schema name to anton_ch
    Select 'Start Import'
    Now you have a copy of the project database on your machine.
  ```
  
- Update Database:
  ```
  ~/Desktop/Factory.Solution/Factory $ dotnet ef database update
  ```
- Build the project:
  ```
   ~/Desktop/Factory.Solution/Factory $ dotnet build
  ```
- Run the project
  ```
   ~/Desktop/Factory.Solution/Factory $ dotnet run
  ```
- Visit [http://localhost:5000](http://localhost:5000) to try this application

## Known Bugs



## License

[ISC](https://opensource.org/licenses/ISC)

Permission to use, copy, modify, and/or distribute this software for any purpose with or without fee is hereby granted, provided that the above copyright notice and this permission notice appear in all copies.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.

Copyright (c) 01/06/2023 Anton Ch