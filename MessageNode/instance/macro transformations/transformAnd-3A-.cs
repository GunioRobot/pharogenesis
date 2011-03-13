transformAnd: encoder
	(self transformBoolean: encoder)
		ifTrue: 
			[arguments _ 
				Array 
					with: (arguments at: 1)
					with: (BlockNode withJust: NodeFalse).
			^true]
		ifFalse: 
			[^false]