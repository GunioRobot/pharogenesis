pop: numObjects toIndexable: anIndexableCollection
	"Pop the top numObjects elements from the stack, and store them in
	 anIndexableCollection, topmost element last.
	 Do not call directly.  Called indirectly by {1. 2. 3} constructs."

	| oldTop i |
	i _ stackp _ (oldTop _ stackp) - numObjects.
	[(i _ i + 1) <= oldTop] whileTrue:
		[anIndexableCollection at: i-stackp put: (self at: i).
		 self at: i put: nil]