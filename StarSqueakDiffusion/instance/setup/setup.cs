setup

	self clearAll.
	self patchesDo: [:p | p color: (Color gray: 0.9)].
	self setupTurtles.
	turtleDemons := #(move bounce).
