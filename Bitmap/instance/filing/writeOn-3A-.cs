writeOn: aStream 
	"Store the array of bits onto the argument, aStream."

	aStream nextInt32Put: self size.
	aStream nextPutAll: self