informTarget

	| newValue |
	((target ~~ nil) and: [putSelector ~~ nil]) ifTrue:
		[newValue _ self valueFromContents.
		newValue ifNotNil:
			[target scriptPerformer perform: putSelector with: newValue.
			target isMorph ifTrue: [target changed]].
			self fitContents.
			"self growable ifTrue:
				[self readFromTarget; fitContents.
				owner ifNotNil:  [owner updateLiteralLabel]]"]