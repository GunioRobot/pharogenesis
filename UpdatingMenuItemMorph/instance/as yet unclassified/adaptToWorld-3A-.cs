adaptToWorld: aWorld
	super adaptToWorld: aWorld.
	wordingProvider isMorph
		ifTrue:
			[wordingProvider isWorldMorph ifTrue: [	wordingProvider _ aWorld].
			wordingProvider isHandMorph ifTrue: [wordingProvider _ aWorld primaryHand]]
		ifFalse: [(wordingProvider isKindOf: Presenter) ifTrue: [wordingProvider _ aWorld presenter]]