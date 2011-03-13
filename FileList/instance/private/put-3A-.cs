put: aText

	| ff |
	listIndex = 0 ifTrue: [^ self].
	((aText size >= 5) and:
	 [#('File ' '16r0 ') includes: (aText copyFrom: 1 to: 5)])
		ifTrue: [
			(self confirm:
'Abbreviated and hexadecimal file views
cannot be meaningfully saved at present.
Is this REALLY what you want to do?') ifFalse: [^ false]].
	ff _ directory newFileNamed: self fullName.
	Cursor write showWhile: [ff nextPutAll: aText asString; close].
	fileName = ff localName 
		ifTrue: [contents _ aText asString]
		ifFalse: [self updateFileList].		"user renamed the file"
	^ true  "accepted"
