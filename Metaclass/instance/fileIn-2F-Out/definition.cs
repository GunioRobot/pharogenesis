definition 
	"Refer to the comment in ClassDescription|definition."

	| aStream names |
	aStream _ WriteStream on: (String new: 300).
	self printOn: aStream.
	aStream nextPutAll: '
	instanceVariableNames: '''.
	names _ self instVarNames.
	1 to: names size do: [:i | aStream nextPutAll: (names at: i); space].
	aStream nextPut: $'.
	^aStream contents