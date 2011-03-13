fileOut

	| fileName |
	fileName := UIManager default 
		request: 'File name?' translated
		initialAnswer: 'Filename.form'.
	fileName isEmpty ifTrue: [^ self].
	Cursor normal
		showWhile: [model writeOnFileNamed: fileName].
