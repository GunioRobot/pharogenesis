add: aString subMenu: aMenuMorph
	"Append the given submenu with the given label."

	| item |
	item _ MenuItemMorph new.
	item contents: aString;
		subMenu: aMenuMorph.
	self addMorphBack: item.
