initialize

	super initialize.
	self color: Color black.
	target _ nil.
	actionSelector _ #flash.
	arguments _ EmptyArray.
	actWhen _ #buttonUp.
	self contents: 'Flash'.
