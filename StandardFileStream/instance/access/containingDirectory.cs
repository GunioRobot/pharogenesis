containingDirectory
	"Return the directory containing this file."

	^ FileDirectory on: (FileDirectory dirPathFor: self fullName)
