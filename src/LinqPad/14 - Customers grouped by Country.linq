<Query Kind="Expression">
  <Connection>
    <ID>18109b28-6563-40c1-97b9-460c7b5b66d7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Display all the company names and contact names for our customers, grouped by country
from row in Customers
group  row   by   row.Address.Country into CustomersByCountry
//    \what/      \       how       /
select new
{
   Country = CustomersByCountry.Key, // the key is "how" we have sorted the data
   Customers = from data in CustomersByCountry
               select new
               {
                   Company = data.CompanyName,
                   Contact = data.ContactName
               }
}