mouseDown: evt

	| menu |
	evt yellowButtonPressed ifFalse: [^ self].
	menu _ MenuMorph new defaultTarget: self.
	self addMenuItemsTo: menu hand: evt hand.
	menu popUpEvent: evt in: self world.
