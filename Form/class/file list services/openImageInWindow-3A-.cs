openImageInWindow: fullName
	"Handle five file formats: GIF, JPG, PNG, Form storeOn: (run coded), and BMP.
	Fail if file format is not recognized."

	| image myStream |

	myStream _ (FileStream readOnlyFileNamed: fullName) binary.
	image _ self fromBinaryStream: myStream.
	myStream close.

	Smalltalk isMorphic ifTrue:[
		Project current resourceManager 
			addResource: image 
			url: (FileDirectory urlForFileNamed: fullName) asString.
	].

	Smalltalk isMorphic
		ifTrue: [(World drawingClass withForm: image) openInWorld]
		ifFalse: [FormView open: image named: fullName]