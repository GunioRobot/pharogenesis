yellowButtonMenu
	| menu sel |
	menu _ CustomMenu new.
	menu title: self class name.
	self addCustomMenuItems: menu.
	sel := menu startUp.
	sel ifNotNil: [self perform: sel]