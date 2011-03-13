fileOutForm
	"Ask the user for a file name and save the current source form under that name. Does not change the tool."

	| fileName |
	fileName _ FillInTheBlank
		request: 'File name?'
		initialAnswer: 'Filename.form'.
	fileName isEmpty ifTrue: [^ self].
	Cursor normal
		showWhile: [form writeOnFileNamed: fileName].
	tool _ previousTool.
