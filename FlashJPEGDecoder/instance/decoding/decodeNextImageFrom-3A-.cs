decodeNextImageFrom: aStream
	| image |
	self setStream: aStream.
	self isStreaming ifFalse:[Cursor wait show].
	image _ self nextImage.
	self isStreaming ifFalse:[Cursor normal show].
	^image