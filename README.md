Project Name: Cove Services (Cove is a street name)
Description:
  It's platform to provide and search for services. There are three types of users:
1. Providers - can create/edit account by selecting services they provide
2. Seekers - can search for Providers based on service they are looking for. Provider details with Name, Email, Phone Number, Services Provided will be returned in a table format
3. Admin - to add or delete services. The list of services added by Admin will be used to auto populate for searching by seekers and Providers when creating or editing account.

Database Tables:
1. User: ID (int, primary)
         UserName (varchar)
         Password (varchar)
         Email (varchar)
         PhoneNumber (int)
         RoleId (foreign key)
2. Roles: ID (int, primary)
          Name (varchar)         
3. Services: ID (int, primary)
             Name (varchar)       
4. ServiceProvider: ID (int, primary)
                    UserId (foreign key)
                    ServiceId (foreign key)

Pages:
   Admin - /Admin/Login (using JWT Authentication)
           /Admin/AddServive (only Admin have access)
           /Admin/DeleteService (only Admin have access. service will be deleted from Services table and rows associated with the service will be deleted from ServiceProvider table)
    
   Provider - /Provider/Login
              /Provider/CreateAccount (new Providers will create account first. There will be a multiselect type field for services along with Name, Email, Phone, UserName, Password, Confirm Password fields.)
              /Provider/EditAccount (Looks similar to Create Account but with values populated. Name, Email, Phone, Change Password and Services fields will be editable.)
    
   Seeker - /Home (Default Landing page with buttons to select for Seeker and Provider.)
            /Search (Basic page with dropdown of Services and search icon. Results will be displayed in a table)

Tech stack:
Backend - ASP.NET Core Web API and MS SQL Server Management Studio
     
