mouseMove: evt
	| aColor |
	(aColor _ self valueOfProperty: #oldColor) ifNotNil:
		[(self containsPoint: evt cursorPoint)
			ifTrue:
				[self color: (aColor mixed: 1/2 with: Color white)]
			ifFalse: [self color: aColor]]
