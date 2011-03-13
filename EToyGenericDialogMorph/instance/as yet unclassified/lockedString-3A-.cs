lockedString: aString

	^self inAColumn: {(StringMorph contents: aString font: self myFont) lock}.
