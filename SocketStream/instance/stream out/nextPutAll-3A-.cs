nextPutAll: aCollection
	self outStream nextPutAll: (self isBinary ifTrue: [aCollection asByteArray] ifFalse: [aCollection asString]).
	self checkFlush