stringAsObject: aString
	"Answer the given string in object form."
	
	^super stringAsObject: (self transformBlock value: aString)