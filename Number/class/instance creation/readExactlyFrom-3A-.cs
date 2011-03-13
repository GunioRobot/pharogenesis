readExactlyFrom: stringOrStream 
	"Answer a number as described on aStream. The number may
	include a leading radix specification, as in 16rFADE"
	
	^(SqNumberParser on: stringOrStream) nextNumber