addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	self addBookMenuItemsTo: aCustomMenu hand: aHandMorph
	"This factoring allows subclasses, such as TabbedPaletteMorph, to choose different items and different wording and still use the super call for the rest of the metamenu"