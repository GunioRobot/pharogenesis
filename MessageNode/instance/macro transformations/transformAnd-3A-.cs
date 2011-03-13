transformAnd: encoder
	(self transformBoolean: encoder)
		ifTrue: 
			[arguments := 
				Array 
					with: (arguments at: 1) noteOptimized
					with: (BlockNode withJust: NodeFalse) noteOptimized.
			^true]
		ifFalse: 
			[^false]