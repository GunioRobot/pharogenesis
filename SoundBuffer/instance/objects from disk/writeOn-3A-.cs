writeOn: aStream 
	| reversed convertToBytes |
	"Store the array of bits onto the argument, aStream.  (leading byte ~= 16r80) identifies this as raw bits (uncompressed).  Always store in Big Endian (Mac) byte order.  Do the writing at BitBlt speeds."

	convertToBytes _ aStream originalContents "collection" class isBytes.
	(aStream isKindOf: FileStream) ifTrue: [convertToBytes _ false].	"knows how"

	aStream nextInt32Put: self size.
	Smalltalk endianness == #big 
		ifTrue: ["no change"
			convertToBytes ifTrue: [self do: [:vv | aStream nextNumber: 4 put: vv]]
					"Later define (aStream nextPutWordsAll:) that uses BitBlt to 
					 put words on a non-file byteStream quickly" 
				ifFalse: [aStream nextPutAll: self]]	"files use this"
		ifFalse: [
			reversed _ self clone.
			reversed restoreEndianness.	"swap an extra time to get to big endian format"
			convertToBytes ifTrue: [reversed do: [:vv | aStream nextNumber: 4 put: vv]]
				ifFalse: [aStream nextPutAll: reversed]]
