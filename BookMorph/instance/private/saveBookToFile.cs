saveBookToFile
	"Save this book in a file."

	| fileName s |
	fileName _ FillInTheBlank request: 'File name for this Book?'.
	fileName isEmpty ifTrue: [^ self].  "abort"

	s _ SmartRefStream newFileNamed: fileName, '.morph'.
	s nextPut: self fullCopy.
	s close.
