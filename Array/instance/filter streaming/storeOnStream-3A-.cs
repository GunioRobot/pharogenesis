storeOnStream:aStream
	self isLiteral ifTrue: [super storeOnStream:aStream] ifFalse:[aStream writeCollection:self].
