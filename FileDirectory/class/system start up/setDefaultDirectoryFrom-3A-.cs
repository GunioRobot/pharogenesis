setDefaultDirectoryFrom: imageName
	"Initialize the default directory to the directory containing the Squeak image file. This method is called when the image start up."

	DefaultDirectory _ self on: (self dirPathFor: imageName).
