saveContentsInFile
	| fileName stringToSave parentWindow labelToUse |
	stringToSave _ paragraph text string.
	stringToSave size == 0 ifTrue: [^ self inform: 'nothing to save.'].
	parentWindow _ self model dependents
						detect: [:dep | dep isKindOf: SystemWindow]
						ifNone: [nil].
	parentWindow isNil
		ifTrue: [labelToUse _ 'Untitled']
		ifFalse: [labelToUse _ parentWindow label].

	fileName _ FillInTheBlank request: 'File name? (".text" will be added to end)' 
			initialAnswer: labelToUse.
	fileName size == 0 ifTrue: [^ self beep].
	(fileName asLowercase endsWith: '.text') ifFalse: [fileName _ fileName,'.text'].

	(FileStream newFileNamed: fileName)
		nextPutAll: stringToSave; close