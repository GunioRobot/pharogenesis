menu: titleString
	"Create a menu with the given title, ready for filling"

	| menu |
	(menu _ MenuMorph entitled: titleString translated) 
		defaultTarget: self; 
		addStayUpItem;
		commandKeyHandler: self.
	self colorForDebugging: menu.
	^ menu
