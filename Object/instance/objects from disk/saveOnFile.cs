saveOnFile
	"Ask the user for a filename and save myself on a SmartReferenceStream file.  Writes out the version and class structure.  The file is fileIn-able.  Does not file out the class of the object.  tk 6/26/97 13:48"

	| aFileName fileStream |
	aFileName _ self class name asFileName.	"do better?"
	aFileName _ FillInTheBlank request: 'File name?' initialAnswer: aFileName.
	aFileName size == 0 ifTrue: [^ Beeper beep].

	fileStream _ FileStream newFileNamed: aFileName asFileName.
	fileStream fileOutClass: nil andObject: self.