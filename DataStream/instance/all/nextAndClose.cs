nextAndClose
	"Speedy way to grab one object.  Only use when we are inside an object binary file.  Do not use for the start of a SmartRefStream mixed code-and-object file."

	| obj |
	byteStream peek = 4 ifFalse: ["Try to fix the user's sins..."
		self inform: 'Should be using fileInObjectAndCode'.
		byteStream ascii.
		byteStream fileIn.
		obj _ SmartRefStream scannedObject.
		SmartRefStream scannedObject: nil.
		^ obj].

	obj _ self next.
	self close.
	^ obj