helpContributions
	^ #((numericValue
			'A number representing the current position of the knob.')
		(minVal
			'The number represented when the knob is at the left or top of the slider; the smallest value returned by the slider.')
		(maxVal
			'The number represented when the knob is at the right or bottom of the slider; the largest value returned by the slider.')
		(descending
			'Tells whether the smallest value is at the top/left (descending = false) or at the bottom/right (descending = true)')
		(truncate
			'If true, only whole numbers are used as values; if false, fractional values are allowed.')
		(knobColor
			'The color of the slider''s knob.'))