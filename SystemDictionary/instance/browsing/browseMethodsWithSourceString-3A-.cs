browseMethodsWithSourceString: aString
	"Smalltalk browseMethodsWithSourceString: 'SourceString' "
	"Launch a browser on all methods whose source code contains aString as a substring."

	| caseSensitive suffix |
	(caseSensitive _ Sensor shiftPressed)
		ifTrue: [suffix _ ' (case-sensitive)']
		ifFalse: [suffix _ ' (use shift for case-sensitive)'].
	^ self browseMessageList: (self allMethodsWithSourceString: aString
									matchCase: caseSensitive)
		name: 'Methods containing ' , aString printString , suffix autoSelect: aString