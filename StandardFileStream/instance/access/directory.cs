directory
	"Return the directory I am in"

	^ FileDirectory on: (FileDirectory dirPathFor: self fullName)