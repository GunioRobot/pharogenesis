formFromFileNamed: fileName
	"Answer a ColorForm stored on the file with the given name."

	^ self formFromFile: (FileStream oldFileNamed: fileName)