helpMenu

	| menu |
	menu := MenuMorph new defaultTarget: self.
	self createMenuItem: {'move objects onscreen'. 'Bring back all objects whose current coordinates keep them from being visible, so that at least a portion of each of my interior objects can be seen'} on: menu.
	self createMenuItem: {'unhide hidden objects'. 'If any items on the world are currently hidden, make them visible'} on: menu.

	^ menu