transformIfFalse: encoder
	(self transformBoolean: encoder)
		ifTrue: 
			[arguments _ 
				Array 
					with: (BlockNode withJust: NodeNil)
					with: (arguments at: 1).
			^true]
		ifFalse:
			[^false]