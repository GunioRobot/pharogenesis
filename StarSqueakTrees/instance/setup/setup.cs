setup

	self clearAll.
	self makeTurtles: 1 class: TreeTurtle.
	self turtlesDo: [:t |
		t goto: 50@90.
		t penDown.
		t color: Color red.
		t heading: 0.
		t length: 15.
		t depth: depth].
	self addTurtleDemon: treeTypeSelector.
