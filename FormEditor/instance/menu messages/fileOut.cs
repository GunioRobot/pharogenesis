fileOut
	Cursor normal showWhile:
	[model writeOnFileNamed:
		(FillInTheBlank request: 'Enter file name'
				initialAnswer: 'Filename.form')]
