decodeNextImage32From: aStream
	| image |
	self setStream: aStream.
	self isStreaming ifFalse:[Cursor wait show].
	image := self nextImageDitheredToDepth: 32.
	self isStreaming ifFalse:[Cursor normal show].
	^image