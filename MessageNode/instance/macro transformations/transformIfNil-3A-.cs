transformIfNil: encoder

	(self transformBoolean: encoder) ifFalse: [^ false].
	(MacroSelectors at: special) = #ifNotNil:
	ifTrue:
		[(self checkBlock: arguments first as: 'ifNotNil arg' from: encoder) ifFalse: [^ false].

		"Transform 'ifNotNil: [stuff]' to 'ifNil: [nil] ifNotNil: [stuff]'.
		Slightly better code and more consistent with decompilation."
		self noteSpecialSelector: #ifNil:ifNotNil:.
		selector _ SelectorNode new key: (MacroSelectors at: special) code: #macro.
		arguments _ {BlockNode withJust: NodeNil. arguments first}.
		(self transform: encoder) ifFalse: [self error: 'compiler logic error'].
		^ true]
	ifFalse:
		[^ self checkBlock: arguments first as: 'ifNil arg' from: encoder]
