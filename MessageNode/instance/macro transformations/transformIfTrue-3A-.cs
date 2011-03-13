transformIfTrue: encoder
	(self transformBoolean: encoder)
		ifTrue: 
			[arguments := 
				Array 
					with: (arguments at: 1) noteOptimized
					with: (BlockNode withJust: NodeNil) noteOptimized.
			^true]
		ifFalse: 
			[^false]