fileOut

	| fileName |
	fileName _ FillInTheBlank
		request: 'File name?'
		initialAnswer: 'Filename.form'.
	fileName isEmpty ifTrue: [^ self].
	Cursor normal
		showWhile: [model writeOnFileNamed: fileName].
