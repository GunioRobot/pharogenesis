initializeSlider
	slider := RectangleMorph newBounds: self totalSliderArea color: Color veryLightGray.
	slider on: #mouseStillDown send: #scrollAbsolute: to: self.
	slider setBorderWidth: 2 borderColor: #raised.
	self addMorph: slider.
	self computeSlider.
