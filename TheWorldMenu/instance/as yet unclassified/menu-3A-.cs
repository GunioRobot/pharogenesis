menu: titleString

	| menu |

	(menu _ MenuMorph entitled: titleString) 
		defaultTarget: self; 
		addStayUpItem.
	self colorForDebugging: menu.
	^menu
