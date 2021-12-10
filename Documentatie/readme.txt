installatie:
server:
	- open CursusInzicht.sln in '\backend\CursusInzicht.sln'
	- open een package manager console met als default project CursusInzicht.DataAccess
	- type update-database en wacht tot deze klaar is.
	- Run CursusInzicht.API door middel van IIS Express.

client:
	- open de folder '\frontend' in visual studio code
	- open integrated terminal in de werkfolder ('\frontend')
	- type 'npm install' en wacht tot dit klaar is
	- type 'ng serve'
	- de client kan benaderd worden door in de browser naar localhost:4200 te gaan.	

