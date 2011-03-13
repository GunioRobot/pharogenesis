fileInForm
	"Ask the user for a file name and then recalls the Form in that file as the current source Form (form). Does not change the tool."

	| fileName |
	fileName := UIManager default
		request: 'File name?' translated
		initialAnswer: 'Filename.form'.
	fileName isEmpty ifTrue: [^ self].
	form := Form fromFileNamed: fileName.
	tool := previousTool.
