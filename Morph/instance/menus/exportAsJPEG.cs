exportAsJPEG
	"Export the receiver's image as a JPEG"

	| fName |
	fName _ FillInTheBlank request: 'Please enter the name' translated initialAnswer: self externalName,'.jpeg'.
	fName isEmpty ifTrue: [^ self].
	self imageForm writeJPEGfileNamed: fName