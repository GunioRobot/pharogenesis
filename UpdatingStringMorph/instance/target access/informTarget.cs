informTarget

	| newValue |
	((target ~~ nil) and: [putSelector ~~ nil]) ifTrue:
		[newValue _ self valueFromContents.
		newValue ifNotNil:
			[target perform: putSelector with: newValue.
			target isMorph ifTrue: [target changed]]]
