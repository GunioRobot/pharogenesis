parserClass

	^parser ifNil: [self class parserClass] ifNotNil: [parser class]