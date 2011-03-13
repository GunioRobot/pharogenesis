addDropShadowMenuItems: aMenu hand: aHand
	| menu |
	menu _ MenuMorph new defaultTarget: self.
	menu addUpdating: #hasDropShadowString
		action: #toggleDropShadow.
	menu addLine.
	menu add: 'shadow color...' target: self selector: #changeShadowColor.
	menu add: 'shadow offset...' target: self selector: #setShadowOffset:.
	aMenu add: 'drop shadow' subMenu: menu.