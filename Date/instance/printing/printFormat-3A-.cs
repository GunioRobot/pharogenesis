printFormat: formatArray 
	"Answer a String describing the receiver using the argument formatArray."

	| aStream |
	aStream _ WriteStream on: (String new: 16).
	self printOn: aStream format: formatArray.
	^aStream contents