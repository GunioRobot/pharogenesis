firstInChain
	"Return the first morph in a chain of textMorphs"
	| first |
	first _ self.  
	[first predecessor == nil]
		whileFalse: [first _ first predecessor].
	^ first