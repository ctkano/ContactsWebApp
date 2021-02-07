# Contacts Web Application

This is the place where you should organize your contact list, in this web application you can register, list, view and delete contacts.

## Premises/Assumptions of this implementation

This application was developed to manage the contact information of a user.

For the development, the following premises were taken into account:
- Contact Type:
  - Required option field and should be Natural or Legal person;
  - Is registered into the ContactType field of the Contact's Model;
  - In order to centralize into one single contact creation form, this information turned into a field with these two options.
- Name / Company Name:
  - Required text field;
  - Is registered into the MainName field of the Contact's Model, regardless of the contact type selected;
  - Validation by regex can be found in the Postal Code Regex Library (Dictionary/ContactRegexLib.cs);
  - The label changes depending on the contact type selected.
- Trade Name:
  - Text field;
  - Is registered into the TradeName field of the Contact's Model;
  - Validation by regex can be found in the Postal Code Regex Library (Dictionary/ContactRegexLib.cs);
  - The field appears and is registered in the DB only when the contact type is "Legal person".
 - Document Number:
  - Required tield that represents the number of CPF or CNPJ;
  - It is validated according with its type (CPF or CNPJ), based on the contaty type selected (maped document type in: Dictionary/ContactDocumentLib.cs) and their specific patterns (999.999.999-99 for CPF and 99.999.999/9991-99 for CNPJ);
  - Validation by regex can be found in the Contact Regex Library (Dictionary/ContactRegexLib.cs);
  - Is registered into the DocumentNumber field of the Contact's Model, regardless of the contact type selected;
  - The label changes depending on the contact type selected.
- Birthday:
  - Date field;
  - Is registered into the Birthday field of the Contact's Model;
  - The field appears and is registered in the DB only when the contact type is "Natural person";
  - The date format is defined by: dd/MM/yyyy.
- Gender:
  - Option field and should be Male or Female or Other;
  - Is registered into the Gender field of the Contact's Model;
  - The field appears and is registered in the DB only when the contact type is "Natural person".
- Country:
  - Drop down list field and is automatically loaded from the country library (Dictionary/CountryLib.cs) with a loader method (Helper/LoadHelper.cs);
  - Is registered into the Country field of the Contact's Model.
- ZipCode:
  - Text field;
  - Is validated according to the country selected (e.g.: If the country selected was Brazil, then the zip code pattern is 99999-999);
  - Validation by regex can be found in the Postal Code Regex Library (Dictionary/PostalCodeRegexLib.cs);
  - Is registered into the ZipCode field of the Contact's Model.
- State:
  - Text field;
  - Validation by regex can be found in the Postal Code Regex Library (Dictionary/ContactRegexLib.cs);
  - Is registered into the State field of the Contact's Model.
- City:
  - Text field;
  - Validation by regex can be found in the Postal Code Regex Library (Dictionary/ContactRegexLib.cs);
  - Is registered into the City field of the Contact's Model.
- Address Line 1:
  - Text field;
  - Represents the address first line of the contact;
  - Validation by regex can be found in the Postal Code Regex Library (Dictionary/ContactRegexLib.cs);
  - Is registered into the AddressLine1 field of the Contact's Model.
- Address Line 2:
  - Text field;
  - Represents the address second line for additional address information of the contact;
  - Validation by regex can be found in the Postal Code Regex Library (Dictionary/ContactRegexLib.cs);
  - Is registered into the AddressLine2 field of the Contact's Model.
  
The contact information validation occurs on code-behind at ValidationHelper (Helper/ValidationHelper.cs).

For the label changing information and the display of a field is described at a JS library (Scripts/contactlib.js).

This project has two views and controller:
- Home 
  - Containing:
    - Home Page;
    - About Page.
- Contacts
  - Containing:
    - Creation Page;
    - Deletion Page;
    - Details Page;
    - Edition Page (this page is not show to users, as it is not in the scope of this project, however, it already reflects all actual data as it can be found in the creation page).

This page has two models:
- Contact:
  - Used for the view and controler of the same name.
- Contry:
  - Used just for object in the project.

## Solution's basics

When loading the web application the user is redirected to the Main Page. In the Main Page the user can select the following:
- Creating new contacts:
  - This action can be done by clicking in the button of the section "Create a new contact"
  - Or by clicking in the link "Create" on the top of the page.
  - Or by accessing the contact's list page (see Listing contacts below) and clicking in the link "Create New"
- Listing contacts:
  - This action can be done by clicking in the button of the section "Check your contact's list" or by clicking in the link "List" on the top of the page
- Visualizing a contact's detailed information:
  - This action can be done by accessing the contact's list page (see Listing contacts above) and clicking in the link "Details" of one of the contacts listed
- Deleting a contact
  - This action can be done by accessing the contact's list page (see Listing contacts above) and clicking in the link "Delete" of one of the contacts listed

## Requirements

The requirements are divided by for runtime and for development:
- For runtime is when the application is running in production server;
- For development is when the application is being developed.

### Runtime
- [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- SQL Server 2012 or later

### For development
- [.NET Framework 4.8 SDK](https://dotnet.microsoft.com/download/visual-studio-sdks)
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)
- [SQL Server Developer](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
