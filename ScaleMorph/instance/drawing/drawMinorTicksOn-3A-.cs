drawMinorTicksOn: aCanvas 
	| scale x1 y1 y2 x loopStart yoffset randomLabel |
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
	y2 _ y1 - minorTickLength.
	loopStart _ (start / minorTick) ceiling * minorTick.
	loopStart
		to: stop
		by: minorTick
		do: 
			[:v | 
			x _ x1 + (scale * (v - start)).
			aCanvas
				line: x @ y1
				to: x @ y2
				width: 1
				color: Color black].
	