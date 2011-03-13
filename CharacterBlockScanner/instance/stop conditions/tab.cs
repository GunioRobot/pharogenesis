tab
	| currentX |
	currentX _ (textStyle alignment == Justified and: [self leadingTab not])
		ifTrue:		"imbedded tabs in justified text are weird"
			[destX + (textStyle tabWidth - (line justifiedTabDeltaFor: spaceCount)) max: destX]
		ifFalse:
			[textStyle
				nextTabXFrom: destX
				leftMargin: leftMargin
				rightMargin: rightMargin].
	lastSpaceOrTabExtent _ lastCharacterExtent copy.
	lastSpaceOrTabExtent x: (currentX - destX max: 0).
	currentX >= characterPoint x
		ifTrue: 
			[lastCharacterExtent _ lastSpaceOrTabExtent copy.
			^self crossedX].
	destX _ currentX.
	lastIndex _ lastIndex + 1.
	^false