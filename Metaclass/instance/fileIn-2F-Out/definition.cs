definition 
	"Refer to the comment in ClassDescription|definition."
	| aStream names |
	aStream _ WriteStream on: (String new: 300).
	self printOn: aStream.
	names _ self instVarNames.
"
	names isEmpty ifTrue: [^  aStream contents].
"
	aStream nextPutAll: '
	instanceVariableNames: '''.
	1 to: names size do: [:i | aStream nextPutAll: (names at: i); space].
	aStream nextPut: $'.
	^ aStream contents