read
	stream reset.
	[stream atEnd] whileFalse: [events add: self nextEvent].
	self addPitches