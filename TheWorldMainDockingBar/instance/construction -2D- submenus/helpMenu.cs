helpMenu
	| menu |
	menu := MenuMorph new defaultTarget: self.
	""
	self createMenuItem: {'move objects onscreen'. 'Bring back all objects whose current coordinates keep them from being visible, so that at least a portion of each of my interior objects can be seen'} on: menu.
	self createMenuItem: {'unhide hidden objects'. 'If any items on the world are currently hidden, make them visible'} on: menu.
	menu addLine.
	self createMenuItem: {'show all viewers'. 'Make visible the viewers for all objects which have user-written scripts in this playfield'} on: menu.
	self createMenuItem: {'hide all viewers'. 'Make invisible the viewers for all objects in the world'} on: menu.
	menu addLine.
	self createMenuItem: {'clear turtle trails'. 'Remove any pigment laid down on the desktop by objects moving with their pens down'} on: menu.
"
	menu addLine.
	self createMenuItem: {'eToy vocabulary summary'. 'Displays a summary of all the pre-defined commands and properties in the pre-defined eToy vocabulary'} on: menu.
"
	""
	^ menu