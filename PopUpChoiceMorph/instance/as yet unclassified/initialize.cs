initialize

	super initialize.
	self contents: 'PopUpChoice of Colors'.
	target _ Color.
	actionSelector _ nil.
	arguments _ EmptyArray.
	getItemsSelector _ #colorNames.
	getItemsArgs _ EmptyArray.
