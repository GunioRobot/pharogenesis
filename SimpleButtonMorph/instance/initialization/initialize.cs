initialize

	super initialize.
	self borderWidth: 1.
	self borderColor: #raised.
	self color: (Color r: 0.4 g: 0.8 b: 0.6).
	target _ nil.
	actionSelector _ #flash.
	arguments _ EmptyArray.
	actWhen _ #buttonUp.
	self label: 'Flash'.
