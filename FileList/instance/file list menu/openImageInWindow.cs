openImageInWindow
	"Handle five file formats: GIF, JPG, PNG, Form stoteOn: (run coded), and BMP.
	Fail if file format is not recognized."

	| image |
	image _ Form fromFileNamed: self fullName.

	Smalltalk isMorphic
		ifTrue: [World addMorph: (SketchMorph withForm: image)]
		ifFalse: [FormView open: image named: fileName]