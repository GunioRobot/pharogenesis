writeOn: aStream 
	| reversed convertToBytes |
	"Store the array of bits onto the argument, aStream.  (leading byte ~= 16r80) identifies this as raw bits (uncompressed).  Always store in Big Endian (Mac) byte order.  Do the writing at BitBlt speeds."

	convertToBytes _ aStream originalContents "collection" class isBytes.
	(aStream isKindOf: FileStream) ifTrue: [convertToBytes _ false].	"knows how"
	Smalltalk endianness == #big 
		ifTrue: ["no change"
			aStream nextInt32Put: self size.
			convertToBytes ifTrue: [self do: [:vv | aStream nextNumber: 4 put: vv]]
					"Later define (aStream nextPutWordsAll:) that uses BitBlt to 
					 put words on a byteStream quickly" 
				ifFalse: [aStream nextPutAll: self]]
		ifFalse: [
			reversed _ self clone.
			reversed swapBytesFrom: 1 to: reversed size.
			aStream nextInt32Put: reversed size.
			convertToBytes ifTrue: [reversed do: [:vv | aStream nextNumber: 4 put: vv]]
				ifFalse: [aStream nextPutAll: reversed]]
