tab
	| oldX |
	oldX _ destX.
	destX _ (textStyle alignment == Justified and: [self leadingTab not])
		ifTrue:		"imbedded tabs in justified text are weird"
			[destX + (textStyle tabWidth - (line justifiedTabDeltaFor: spaceCount)) max: destX]
		ifFalse: 
			[textStyle nextTabXFrom: destX
				leftMargin: leftMargin
				rightMargin: rightMargin].
	fillBlt == nil ifFalse:
		[fillBlt destX: oldX destY: destY width: destX - oldX height: height; copyBits].
	lastIndex _ lastIndex + 1.
	^ false