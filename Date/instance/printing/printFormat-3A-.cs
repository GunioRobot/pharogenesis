printFormat: formatArray 
	"Answer a String describing the receiver using the argument formatArray."

	| aStream |
	aStream := (String new: 16) writeStream.
	self printOn: aStream format: formatArray.
	^ aStream contents