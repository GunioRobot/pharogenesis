setup

	self clearAll.
	self setupPatches.
	self setupTurtles.
	turtleDemons _ #(walk wiggle lookForChip lookForPile).
