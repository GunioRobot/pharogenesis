put: aText
	"Private - put the supplied text onto the file"

	| ff type |
	brevityState == #fullFile ifTrue:
		[ff _ directory newFileNamed: self fullName.
		Cursor write showWhile: [ff nextPutAll: aText asString; close].
		fileName = ff localName 
			ifTrue: [contents _ aText asString]
			ifFalse: [self updateFileList].		"user renamed the file"
		^ true  "accepted"].

	listIndex = 0 ifTrue:
		[self inform: 'No fileName is selected' translated.
		^ false  "failed"].
	type _ 'These'.
	brevityState = #briefFile ifTrue: [type _ 'Abbreviated'].
	brevityState = #briefHex ifTrue: [type _ 'Abbreviated'].
	brevityState = #fullHex ifTrue: [type _ 'Hexadecimal'].
	brevityState = #FileList ifTrue: [type _ 'Directory'].
	self inform: ('{1} contents cannot
meaningfully be saved at present.' translated format:{type translated}).
	^ false  "failed"
