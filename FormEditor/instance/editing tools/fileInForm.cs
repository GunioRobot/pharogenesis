fileInForm
	"Ask the user for a file name and then recalls the Form in that file as the current source Form (form). Does not change the tool."

	| fileName |
	fileName _ FillInTheBlank
		request: 'File name?'
		initialAnswer: 'Filename.form'.
	fileName isEmpty ifTrue: [^ self].
	form _ Form fromFileNamed: fileName.
	tool _ previousTool.
