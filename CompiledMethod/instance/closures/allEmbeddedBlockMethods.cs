allEmbeddedBlockMethods

	| set |
	set _ OrderedCollection new.
	1 to: self numLiterals do: [:i |  | lit |
		lit _ self literalAt: i.
		(lit isKindOf: CompiledMethod) ifTrue: [
			set add: lit.
			set addAll: lit allEmbeddedBlockMethods.
		] ifFalse: [(lit isKindOf: BlockClosure) ifTrue: [
			set add: lit method.
			set addAll: lit method allEmbeddedBlockMethods
		]].
	].
	^ set