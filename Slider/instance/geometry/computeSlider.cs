computeSlider
	| r |
	r _ self roomToMove.
	slider position: (bounds isWide
		ifTrue: [r topLeft + ((r width * value) asInteger @ 0)]
		ifFalse: [r topLeft + (0 @ (r height * value)  asInteger)]).
	slider extent: self sliderExtent