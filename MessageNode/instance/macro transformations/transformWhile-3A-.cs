transformWhile: encoder
	(self checkBlock: receiver as: 'receiver' from: encoder) ifFalse:
		[^false].
	arguments size = 0 ifTrue:  "transform bodyless form to body form"
		[selector := SelectorNode new
						key: (special = 10 ifTrue: [#whileTrue:] ifFalse: [#whileFalse:])
						code: #macro.
		 arguments := Array with: (BlockNode withJust: NodeNil) noteOptimized.
		 receiver noteOptimized.
		 ^true].
	^(self transformBoolean: encoder)
	   and: [receiver noteOptimized.
			arguments first noteOptimized.
			true]