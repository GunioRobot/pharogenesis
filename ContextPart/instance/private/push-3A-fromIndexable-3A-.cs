push: numObjects fromIndexable: anIndexableCollection
	"Push the elements of anIndexableCollection onto the receiver's stack.
	 Do not call directly.  Called indirectly by {1. 2. 3} constructs."

	| i |
	i _ 0.
	[(i _ i + 1) <= numObjects] whileTrue:
		[self at: (stackp _ stackp + 1) put: (anIndexableCollection at: i)]