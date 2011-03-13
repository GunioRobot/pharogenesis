decodeNextImageFrom: aStream
	| image |
	self setStream: aStream.
	self isStreaming ifFalse:[Cursor wait show].
	image := self nextImage.
	self isStreaming ifFalse:[Cursor normal show].
	^image