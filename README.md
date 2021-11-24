# ASP.NET Project - HotHitsLyrics Music Lyrics Website
##  Project Intriduction
The lyrics website includes the lyrics of popular songs. 
It makes people to enjoy singing songs more, especially when they don’t know what the exact lyrics is.  

Any users can view the list of artists, albums and songs.   
Only **authenticated** users can create, edit or delete the data.

## Published version of the project:
### Azure
https://hothitslyrics.azurewebsites.net/

### Smarter Asp.Net
This free trail doesn't support SSL.  
http://paohua-001-site1.etempurl.com/

## Website Structures
It consists of 4 webpages as below.   
Anonymous users can ONLY view the list of Artists, Albumns, and Songs, and their details.  

### Home Page
- Include the references used in the project

### Artist Page
- Users can conduct CRUD operations
- In **Index** View, the table headings are clickable for sorting and the searching box cna be used to filter Name

### Album Page
- Users can conduct CRUD operations
- Users can upload/ edit/ delete a photo file, the file will be stored/overwritten in the **/wwwroot/Image** folder
- In **Index** View, the table headings are clickable for sorting and the searching box cna be used to filter Name
- In the **Index** View, the photos will be displayed
- In the **Create** View, the foreign key's dropdown list is sorted alphabetically and searchable

### Song Page
- Users can conduct CRUD operations
- Click on detail to view the lyrics
- In **Index** View, the table headings are clickable for sorting and the searching box cna be used to filter Name
- In the **Create** View, the foreign key's dropdown list is sorted alphabetically and searchable

## Project Models
It consists of 3 models:
- Artist
- Album
- Song
### Entity Relationship Diagram
![HotHitsLyrics-ERD](https://user-images.githubusercontent.com/78240130/135736875-fee7a842-b8f7-46d6-b873-58fe1ae5a242.jpg)

## Additional Features
1. Users can upload, update or delete an album image file 
   - ***All Albumns Views***
2. The Artists, Albumns and Songs tables can be sorted asending or descending by clicking the column heading hyperlink 
   - ***Artists Index View***
   - ***Albums Index View***
   - ***Songs Index View***
4. The dropdown lists of Artist Name and Albumn Name (foreign keys) are sorted alphabetically and searchable 
   - ***Albumns Create View and Edit View***
   - ***Songs Create View and Edit View***
5. Users can search the Artist Name, Albumn Name and Song Name for filtering from all the Index Views
   - ***Artists Index View***
   - ***Albumns Index View***
   - ***Songs Index View***
6. Only **authenticated** users can access **Create**, **Edit**, and **Delete** functions.
7. **Google Authentication** has been added to both local and Azure signin.

## References
- [Tutorial: Add sorting, filtering, and paging with the Entity Framework in an ASP.NET MVC application](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application#prerequisites)

- [ASP.NET Core MVC Image Upload and Retrieve](https://www.youtube.com/watch?v=QpJvqiHl1Fo)

- [select2 jQuery-based replacement for select boxes](https://select2.org/)

- [select2 cdnjs library](https://cdnjs.com/libraries/select2)

- [table sorting](https://kryogenix.org/code/browser/sorttable/)

- Logo made from [Logomakr](https://logomakr.com/)

- Royalty-Free images from [Pixabay](https://pixabay.com/)  

- [Google external login setup](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-5.0) in ASP.NET Core
