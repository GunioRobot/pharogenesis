printOn: aStream
	self isLiteral ifTrue: [self printAsLiteralFormOn: aStream. ^ self].
	self isSelfEvaluating ifTrue: [self printAsSelfEvaluatingFormOn: aStream. ^ self].

	super printOn: aStream