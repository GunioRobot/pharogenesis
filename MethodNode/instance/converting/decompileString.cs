decompileString
	"Answer a string description of the parse tree whose root is the receiver."

	| aStream |
	aStream _ WriteStream on: (String new: 1000).
	self printOn: aStream.
	^aStream contents