put: aText
	| ff type |
	brevityState == #fullFile ifTrue:
		[ff _ directory newFileNamed: self fullName.
		Cursor write showWhile: [ff nextPutAll: aText asString; close].
		fileName = ff localName 
			ifTrue: [contents _ aText asString]
			ifFalse: [self updateFileList].		"user renamed the file"
		^ true  "accepted"].

	listIndex = 0 ifTrue:
		[PopUpMenu notify: 'No fileName is selected'.
		^ false  "failed"].
	type _ 'These'.
	brevityState = #briefFile ifTrue: [type _ 'Abbreviated'].
	brevityState = #briefHex ifTrue: [type _ 'Abbreviated'].
	brevityState = #fullHex ifTrue: [type _ 'Hexadecimal'].
	brevityState = #FileList ifTrue: [type _ 'Directory'].
	PopUpMenu notify: type , ' contents cannot
meaningfully be saved at present.'.
	^ false  "failed"
