createListHeadingUsingFont: font
	| sm |
	sm _ StringMorph contents: '  uncomp     comp   CRC-32       date     time  file name'.
	font ifNotNil: [ sm font: font ].
	^(AlignmentMorph newColumn)
		color: self defaultBackgroundColor;
		addMorph: sm;
		yourself.