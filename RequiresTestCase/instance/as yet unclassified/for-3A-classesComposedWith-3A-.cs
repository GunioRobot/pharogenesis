for: ba classesComposedWith: aBehavior 
	^(ba includes: aBehavior) 
		or: [(ba gather: [:c | c traitComposition allTraits]) includes: aBehavior]