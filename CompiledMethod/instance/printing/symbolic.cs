symbolic
	"Answer a String that contains a list of all the byte codes in a method 
	with a short description of each."

	| aStream |
	aStream := (String new: 1000) writeStream.
	self longPrintOn: aStream.
	^aStream contents