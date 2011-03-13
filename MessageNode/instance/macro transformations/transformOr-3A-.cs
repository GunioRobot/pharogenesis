transformOr: encoder
	(self transformBoolean: encoder)
		ifTrue: 
			[arguments _ 
				Array 
					with: (BlockNode withJust: NodeTrue)
					with: (arguments at: 1).
			^true]
		ifFalse: 
			[^false]