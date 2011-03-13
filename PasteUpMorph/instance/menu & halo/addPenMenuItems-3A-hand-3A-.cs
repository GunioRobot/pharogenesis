addPenMenuItems: menu hand: aHandMorph
	"Add a pen-trails-within submenu to the given menu"

	| subMenu |
	subMenu _ MenuMorph new defaultTarget: self.
	self addPenTrailsMenuItemsTo: subMenu.
	menu add: 'pens trails within...' subMenu: subMenu