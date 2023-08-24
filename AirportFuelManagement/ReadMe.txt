# Airport Fuel Management

# Process to host the project on local server

# Create a localhost url of your site in hosts file
  Located in - C:\Windows\System32\drivers\etc

 Open IIS service
 click Add Website 

 A box will appear write the site name,in physical path select the path of your project that is FuelManagementSystem.web
 Write hostname and click OK. 

 Then click bindings and add https type with port 443 and ssl certificate 

 Now you can browse the project from your given url.

# Initialize Button
 On clicking the initialize button it sends a ajax call to a web method which then connects the database 
 and then it first delete all the foreign key constraints and then  clears airport , aircraft and transactional 
 record then refill the database with deafult aircraft and airports. 
