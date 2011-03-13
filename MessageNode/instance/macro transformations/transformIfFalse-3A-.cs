transformIfFalse: encoder
	(self transformBoolean: encoder)
		ifTrue: 
			[arguments := 
				Array 
					with: (BlockNode withJust: NodeNil) noteOptimized
					with: (arguments at: 1) noteOptimized.
			^true]
		ifFalse:
			[^false]