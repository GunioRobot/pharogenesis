getTypedFileName: aResult

	| name |
	name _ FillInTheBlank 
		request: 'Enter a new file name' 
		initialAnswer: ''.
	name = '' ifTrue: [^self startUpWithCaption: 'Select a File:'].
	name _ aResult directory fullNameFor: name.
	^ StandardFileMenuResult
			directory: (FileDirectory forFileName: name)
			name: (FileDirectory localNameFor: name)
