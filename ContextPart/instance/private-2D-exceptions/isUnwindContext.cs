isUnwindContext

	| m |
	^(m := self method) == (BlockContext compiledMethodAt: #ensure:)
		or: [m == (BlockContext compiledMethodAt: #ifCurtailed:)]