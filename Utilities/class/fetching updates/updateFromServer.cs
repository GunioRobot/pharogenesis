updateFromServer
	"Update the image by loading all pending updates from the server.  Also save local copies of the update files if the #updateSavesFile preference is set to true"

	self readServerUpdatesSaveLocally: Preferences updateSavesFile updateImage: true