drawMajorTicksOn: aCanvas 
	| scale x1 y1 y2 x y3 even yy loopStart checkStart yoffset randomLabel |
	scale _ self innerBounds width - 1 / (stop - start) asFloat.
	majorTickLength < 0
		ifTrue: [yoffset _ majorTickLength abs + 1]
		ifFalse: [yoffset _ 1].
	caption
		ifNotNil: [captionAbove
				ifFalse: 
					[randomLabel _ StringMorph contents: 'Foo'.
					yoffset _ yoffset + randomLabel height + 2]].
	tickPrintBlock
		ifNotNil: [labelsAbove
				ifFalse: 
					[randomLabel _ StringMorph contents: '50'.
					yoffset _ yoffset + randomLabel height + 2]].
	x1 _ self innerBounds left.
	y1 _ self innerBounds bottom - yoffset.
	y2 _ y1 - majorTickLength.
	y3 _ y1 - (minorTickLength + majorTickLength // 2).
	even _ true.
	"Make sure major ticks start drawing on a multiple of majorTick"
	loopStart _ (start / majorTick) ceiling * majorTick.
	checkStart _ (start / (majorTick / 2.0)) ceiling * majorTick.
	"Check to see if semimajor tick should be drawn before majorTick"
	checkStart = (loopStart * 2)
		ifFalse: 
			[loopStart _ checkStart / 2.0.
			even _ false].
	loopStart
		to: stop
		by: majorTick / 2.0
		do: 
			[:v | 
			x _ x1 + (scale * (v - start)).
			yy _ even
						ifTrue: [y2]
						ifFalse: [y3].
			aCanvas
				line: x @ y1
				to: x @ yy
				width: 1
				color: Color black.
			even _ even not]