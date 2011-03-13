definitionST80: isST80
	"Refer to the comment in ClassDescription|definition."

	isST80 ifTrue: [^ self definitionST80].

	^ String streamContents: 
		[:strm |
		strm print: self;
			nextPutKeyword: ' instanceVariableNames: '
				withArg: self instanceVariablesString]