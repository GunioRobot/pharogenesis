pragmas
	| selectorOrProperties |
	^(selectorOrProperties := self penultimateLiteral) isMethodProperties
		ifTrue: [selectorOrProperties pragmas]
		ifFalse: [#()]