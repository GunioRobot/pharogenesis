buildLabels
	| scale x1 y1 y2 x captionMorph tickMorph loopStart offset |
	((majorTickLength * minorTickLength) < 0) ifTrue: [minorTickLength _ 0 - minorTickLength].
	self removeAllMorphs.
	caption
		ifNotNil: 
			[captionMorph _ StringMorph contents: caption.
			captionAbove
				ifTrue: [offset _ majorTickLength abs + captionMorph height + 7]
				ifFalse: [offset _ 2].
			captionMorph align: captionMorph bounds bottomCenter with: self bounds bottomCenter - (0 @ offset).
			self addMorph: captionMorph].
	tickPrintBlock
		ifNotNil: 
			["Calculate the offset for the labels, depending on whether or not 
			  1) there's a caption   
			below, 2) the labels are above or below the ticks, and 3) the   
			ticks go up or down"
			labelsAbove
				ifTrue: [offset _ majorTickLength abs + minorTickLength abs + 2]
				ifFalse: [offset _ 2].
			caption
				ifNotNil: [captionAbove ifFalse: [offset _ offset + captionMorph height + 2]].
			scale _ self innerBounds width - 1 / (stop - start) asFloat.
			x1 _ self innerBounds left.
			y1 _ self innerBounds bottom.
			y2 _ y1 - offset.
			"Start loop on multiple of majorTick"
			loopStart _ (start / majorTick) ceiling * majorTick.
			loopStart
				to: stop
				by: majorTick
				do: 
					[:v | 
					x _ x1 + (scale * (v - start)).
					tickMorph _ StringMorph contents: (tickPrintBlock value: v).
					tickMorph align: tickMorph bounds bottomCenter with: x @ y2.
					tickMorph left < self left ifTrue: [tickMorph position: self left @ tickMorph top].
					tickMorph right > self right ifTrue: [tickMorph position: self right - tickMorph width @ tickMorph top].
					self addMorph: tickMorph]]