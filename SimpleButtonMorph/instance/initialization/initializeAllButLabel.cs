initializeAllButLabel

	super initialize.
	self borderWidth: 1.
	self color: (Color r: 0.4 g: 0.8 b: 0.6).
	self borderColor: self color darker.
	self borderStyle: BorderStyle thinGray.
	target _ nil.
	actionSelector _ #flash.
	arguments _ EmptyArray.
	actWhen _ #buttonUp
