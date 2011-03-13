embeddedBlockMethods

	| set |
	set := OrderedCollection new.
	1 to: self numLiterals do: [:i |  | lit |
		lit := self literalAt: i.
		(lit isKindOf: CompiledMethod) ifTrue: [
			set add: lit.
		] ifFalse: [(lit isKindOf: BlockClosure) ifTrue: [
			set add: lit method.
		]].
	].
	^ set