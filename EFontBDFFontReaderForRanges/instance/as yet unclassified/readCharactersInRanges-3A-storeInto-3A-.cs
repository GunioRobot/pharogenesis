readCharactersInRanges: ranges storeInto: chars

	| array form code rangeStream currentRange |
	rangeStream _ ReadStream on: ranges.
	currentRange _ rangeStream next.
	[true] whileTrue: [
		array _ self readOneCharacter.
		array second ifNil: [^ self].
		code _ array at: 2.
		code > currentRange last ifTrue: [
			[rangeStream atEnd not and: [currentRange _ rangeStream next. currentRange last < code]] whileTrue.
			rangeStream atEnd ifTrue: [^ self].
		].
		(code between: currentRange first and: currentRange last) ifTrue: [
			form _ array at: 1.
			form ifNotNil: [
				chars add: array.
			].
		].
	].
