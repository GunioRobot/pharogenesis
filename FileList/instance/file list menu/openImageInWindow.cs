openImageInWindow
	"Handle three file formats: GIF, Form stoteOn: (run coded), and BMP. Fail if file format is not recognized."
 
	| ff |
	ff _ Form fromFile: (directory oldFileNamed: fileName).
	FormView open: ff named: fileName.
