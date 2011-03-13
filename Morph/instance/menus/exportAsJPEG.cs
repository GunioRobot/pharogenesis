exportAsJPEG
	"Export the receiver's image as a JPEG"

	| fName |
	fName := UIManager default request: 'Please enter the name' translated initialAnswer: self externalName,'.jpeg'.
	fName isEmptyOrNil ifTrue: [^ self].
	self imageForm writeJPEGfileNamed: fName