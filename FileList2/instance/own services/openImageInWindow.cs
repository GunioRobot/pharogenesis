openImageInWindow
	"Handle five file formats: GIF, JPG, PNG, Form stoteOn: (run coded), and BMP.
	Fail if file format is not recognized."

	| image myStream |

	myStream _ (directory readOnlyFileNamed: fileName) binary.
	image _ Form fromBinaryStream: myStream.
	myStream close.

	Smalltalk isMorphic
		ifTrue: [(World drawingClass withForm: image) openInWorld]
		ifFalse: [FormView open: image named: fileName]