addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addLine.
	aCustomMenu add: 'add title...' action: #addTitle.
	aCustomMenu add: 'set target...' action: #setTarget:.
	defaultTarget ifNotNil: [
		aCustomMenu add: 'add item...' action: #addItem].
	aCustomMenu add: 'remove item' action: #removeItem:.
	aCustomMenu add: 'add line' action: #addLine.
	(self canDetachSubMenu: aHandMorph)
		ifTrue: [aCustomMenu add: 'detach submenu' action: #detachSubMenu:].
