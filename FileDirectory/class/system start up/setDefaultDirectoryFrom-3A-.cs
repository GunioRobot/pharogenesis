setDefaultDirectoryFrom: imageName
	"Initialize the default directory to the directory containing the Squeak image file. This method is called when the image starts up."

	DirectoryClass := self activeDirectoryClass.
	DefaultDirectory := self on: (FilePath pathName: (self dirPathFor: imageName) isEncoded: true) asSqueakPathName.
