initialize

	super initialize.
	color _ Color transparent.
	borderWidth _ 1.
	borderColor _ Color blue.
	selectedItems _ OrderedCollection new.
	itemsAlreadySelected _ OrderedCollection new.
	slippage _ 0@0.