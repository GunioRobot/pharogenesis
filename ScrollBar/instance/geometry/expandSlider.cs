expandSlider
	| r val2 |
	val2 _ value + interval min: 1.0.
	r _ self roomToMove.
	slider extent: (bounds isWide
		ifTrue: [((r width * (val2 - value)) asInteger + self sliderThickness) @ slider height]
		ifFalse: [slider width @ ((r height * (val2 - value)) asInteger + self sliderThickness)])