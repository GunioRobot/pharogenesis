readBitsFrom: aBinaryStream
	
	bits _ Bitmap newFromStream: aBinaryStream.
	bits size = self bitsSize ifFalse: [self error: 'wrong bitmap size; bad Form file?'].
	^ self
