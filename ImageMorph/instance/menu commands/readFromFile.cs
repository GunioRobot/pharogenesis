readFromFile
	| fileName |
	fileName _ FillInTheBlank
		request: 'Please enter the image file name'
		initialAnswer: 'fileName'.
	fileName isEmpty ifTrue: [^ self].
	self image: (Form fromFileNamed: fileName).
