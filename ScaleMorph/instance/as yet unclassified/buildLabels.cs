buildLabels
	| scale x1 y1 y2 x captionMorph tickMorph |
	self removeAllMorphs.
	caption ifNotNil:
		[captionMorph _ StringMorph contents: caption.
		captionMorph align: captionMorph bounds bottomCenter
				with: self bounds bottomCenter - (0@majorTickLength)
						- (0@(captionMorph height + 2)).
		self addMorph: captionMorph].
	tickPrintBlock ifNotNil:
		[scale _ (self innerBounds width-1) / (stop-start) asFloat.
		x1 _ self innerBounds left.
		y1 _ self innerBounds bottom.
		y2 _ y1 - majorTickLength.
		start to: stop by: majorTick do:
			[:v | x _ x1 + (scale*v).
			tickMorph _ StringMorph contents: (tickPrintBlock value: v).
			tickMorph align: tickMorph bounds bottomCenter
						with: x@y2.
			tickMorph left < self left ifTrue:
				[tickMorph position: self left@tickMorph top].
			tickMorph right > self right ifTrue:
				[tickMorph position: (self right-tickMorph width)@tickMorph top].
			self addMorph: tickMorph]]