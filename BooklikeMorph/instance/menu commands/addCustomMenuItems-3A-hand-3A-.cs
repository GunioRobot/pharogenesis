addCustomMenuItems: aCustomMenu hand: aHandMorph
	"This factoring allows subclasses to have different menu yet still use the super call for the rest of the metamenu."

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	self addBookMenuItemsTo: aCustomMenu hand: aHandMorph