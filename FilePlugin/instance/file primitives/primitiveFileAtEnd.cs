primitiveFileAtEnd

	| file atEnd |
	self export: true.
	self var: 'file' declareC: 'SQFile *file'.
	file _ self fileValueOf: (interpreterProxy stackValue: 0).
	interpreterProxy failed ifFalse:[atEnd _ self sqFileAtEnd: file ].
	interpreterProxy failed ifFalse:[
		interpreterProxy pop: 2.  "rcvr, file"
		interpreterProxy pushBool: atEnd.
	].