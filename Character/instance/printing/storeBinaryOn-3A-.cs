storeBinaryOn: aStream
	"Store the receiver on a binary (file) stream"
	value < 256 
		ifTrue:[aStream basicNextPut: self]
		ifFalse:[Stream nextInt32Put: value].