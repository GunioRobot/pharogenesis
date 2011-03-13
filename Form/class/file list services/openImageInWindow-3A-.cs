openImageInWindow: fullName 
	"Handle five file formats: GIF, JPG, PNG, Form storeOn: (run coded), and
	BMP. Fail if file format is not recognized."
	| image myStream |
	myStream := (FileStream readOnlyFileNamed: fullName) binary.
	image := self fromBinaryStream: myStream.
	myStream close.
	Project current resourceManager addResource: image url: (FileDirectory urlForFileNamed: fullName) asString.
	(World drawingClass withForm: image) openInWorld