initializeSlider
	slider := RectangleMorph newBounds: self totalSliderArea color: self sliderColor.
	sliderShadow := RectangleMorph newBounds: self totalSliderArea
						color: self pagingArea color.
	slider on: #mouseStillDown send: #scrollAbsolute: to: self.
	slider on: #mouseDown send: #mouseDownInSlider: to: self.
	slider on: #mouseUp send: #mouseUpInSlider: to: self.
	slider setBorderWidth: 1 borderColor: #raised.
	sliderShadow setBorderWidth: 1 borderColor: #inset.
	"(the shadow must have the pagingArea as its owner to highlight properly)"
	self pagingArea addMorph: sliderShadow.
	sliderShadow hide.
	self addMorph: slider.
	self computeSlider.
