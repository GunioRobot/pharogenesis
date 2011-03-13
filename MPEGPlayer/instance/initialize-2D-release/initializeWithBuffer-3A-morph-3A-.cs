initializeWithBuffer: aBuffer morph: aMorphic
	isBuffer _ true.
	buffer _ aBuffer.
	self initialize: aBuffer.
	self morph: aMorphic.
	^self