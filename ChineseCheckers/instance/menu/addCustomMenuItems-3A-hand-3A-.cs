addCustomMenuItems: aCustomMenu hand: aHandMorph
	"Include our modest command set in the ctrl-menu"

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addLine.
	self addMenuItemsTo: aCustomMenu hand: aHandMorph