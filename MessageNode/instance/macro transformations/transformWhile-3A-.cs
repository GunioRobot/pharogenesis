transformWhile: encoder
	(self checkBlock: receiver as: 'receiver' from: encoder)
		ifFalse: [^ false].
	arguments size = 0   "transform bodyless form to body form"
		ifTrue: [selector _ SelectorNode new
					key: (special = 10 ifTrue: [#whileTrue:] ifFalse: [#whileFalse:])
					code: #macro.
				arguments _ Array with: (BlockNode withJust: NodeNil).
				^ true]
		ifFalse: [^ self transformBoolean: encoder]