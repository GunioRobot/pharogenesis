readFromFile

	| fName |
	fName _ FillInTheBlank
		request: 'Please enter the image file name'
		initialAnswer: 'fileName'.
	fName isEmpty ifTrue: [^ self].
	self image: (Form fromFileNamed: fName).
