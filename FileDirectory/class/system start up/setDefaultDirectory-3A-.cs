setDefaultDirectory: directoryName
	"Initialize the default directory to the directory supplied. This method is called when the image starts up."
	| dirName |
	DirectoryClass _ self activeDirectoryClass.
	dirName _ (FilePath pathName: directoryName) asSqueakPathName.
	[dirName endsWith: self slash] whileTrue:[
		dirName _ dirName copyFrom: 1 to: dirName size - self slash size.
	].
	DefaultDirectory _ self on: dirName.