initialize
	"initialize the state of the receiver"
	super initialize.
	""
	
	selectedItems _ OrderedCollection new.
	itemsAlreadySelected _ OrderedCollection new.
	slippage _ 0 @ 0