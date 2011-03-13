readCompressedFrom: aStream 
	"Initialize the array of bits by reading integers from the argument, 
	aStream."
	| pixSize |
	pixSize _ aStream next.  "1, 2, or 4 bytes"
	