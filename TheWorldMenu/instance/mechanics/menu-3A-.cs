menu: titleString
	"Create a menu with the given title, ready for filling"

	| menu |
	(menu := MenuMorph entitled: titleString translated capitalized) 
		defaultTarget: self; 
		addStayUpItem;
		commandKeyHandler: self.
	^ menu
