storeString: s onFileNamed: fileName
	"Store the given string in a file of the given name."

	| f |
	f _ CrLfFileStream newFileNamed: fileName.
	f nextPutAll: s.
	f close.