pop: numObjects toAddable: anAddableCollection
	"Pop the top numObjects elements from the stack, and store them in
	 anAddableCollection, topmost element last.
	 Do not call directly.  Called indirectly by {1. 2. 3} constructs."

	| oldTop i |
	i _ stackp _ (oldTop _ stackp) - numObjects.
	[(i _ i + 1) <= oldTop] whileTrue:
		[anAddableCollection add: (self at: i).
		 self at: i put: nil]