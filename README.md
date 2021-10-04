# ASP.NET Project - HotHitsLyrics Music Lyrics Website
##  Project Intriduction
The lyrics website includes the lyrics of popular songs. 
It makes people to enjoy singing songs more, especially when they don’t know what the exact lyrics is.  

Users can view the list of artists, albums and songs. In addition, they can create, edit or delete the data.

## Website Structures
It consists of 4 webpages:
### Home Page

### Artist Page
- Users can conduct CRUD operations
- In Index View, the Name column can be sorted ascending or descending

### Album Page
- Users can conduct CRUD operations
- Users can upload/ edit/ delete a photo file, the file will be stored/overwritten in the **/wwwroot/Image** folder
- In the **Index** View, the photos will be displayed
- In the **Create** View, the foreign key's dropdown list is sorted alphabetically

### Song Page
- Users can conduct CRUD operations
- Click on detail to view the lyrics
- In the **Create** View, the foreign key's dropdown list is sorted alphabetically

## Project Models
It consists of 3 models:
- Artist
- Album
- Song
### Entity Relationship Diagram
![HotHitsLyrics-ERD](https://user-images.githubusercontent.com/78240130/135736875-fee7a842-b8f7-46d6-b873-58fe1ae5a242.jpg)

## Additional Features
1. Users can upload, update or delete an album image file (*Albumns Views*)
2. The Artists Name column can be sorted asending or descending by clicking the column heading hyperlink (*Artists Index View*)


## References
- [Tutorial: Add sorting, filtering, and paging with the Entity Framework in an ASP.NET MVC application](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application#prerequisites)

- [ASP.NET Core MVC Image Upload and Retrieve](https://www.youtube.com/watch?v=QpJvqiHl1Fo)

