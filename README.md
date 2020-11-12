# Robert's Safe SQL Parser

Accepting SQL from a client application is a security hole. 
This library parses a string of SQL to ensure that it only contains 
a SELECT statement, or the criteria portion of a SELECT statement.

Whitelisting tables/columns, functions, and variables names ensure that a particular 
SELECT can only access specific schema elements.


#### Example 1

    //
    // Only allow dbo.SomeTable.SomeColumn to be queried
    //
    var p = new RobertsSQLParser.QueryParser();
    p.Permitted.PermittedColumns.Add(new Regex(@"dbo\.SomeTable\.SomeColumn"));
    
    var rc = p.CriteriaToSafeSql("dbo.SomeTable.SomeColumn = 1");

    Console.WriteLine($"{rc.IsSafe}"); // prints True
    Console.WriteLine($"{rc.ErrorDetails}"); // prints nothing (null)
    Console.WriteLine($"{rc.SafeSql}"); // prints dbo.SomeTable.SomeColumn = 1


#### Example 2

    //
    // Allow any schema/table/column to be queried
    //
    var p = new RobertsSQLParser.QueryParser();
    p.Permitted.PermittedColumns.Add(new Regex(".*"));
    
    var rc = p.CriteriaToSafeSql("SomeTable.SomeColumn = 1");

    Console.WriteLine($"{rc.IsSafe}"); // prints True
    Console.WriteLine($"{rc.ErrorDetails}"); // prints nothing (null)
    Console.WriteLine($"{rc.SafeSql}"); // prints SomeTable.SomeColumn = 1

## The Unit Tests

This project originally used the GOLD parser generator and the tests were written
for that environment. One of the goals in that environment was to provide very high
code coverage not only of the library's code but also GOLD's execution engine.