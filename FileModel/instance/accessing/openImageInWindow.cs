openImageInWindow
	"Handle three file formats: GIF, Form stoteOn: (run coded), and BMP. Fail if file format is not recognized."
 
	| f |
	f _ Form fromFileNamed: self fullName.
	f ifNil: [^ self error: 'unrecognized image file format'].
	FormView open: f named: fileName.
