longPrintString
	"Answer a String whose characters are a description of the receiver."
	^ String streamContents: [:aStream | self longPrintOn: aStream]