initializePagingArea
	pagingArea := RectangleMorph newBounds: self totalSliderArea
								color: (Color r: 0.6 g: 0.6 b: 0.8).
	pagingArea borderWidth: 0.
	pagingArea on: #mouseDown send: #resetTimer to: self.
	pagingArea on: #mouseStillDown send: #scrollByPage: to: self.
	self addMorph: pagingArea