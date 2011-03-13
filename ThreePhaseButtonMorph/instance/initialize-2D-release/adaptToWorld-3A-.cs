adaptToWorld: aWorld
	super adaptToWorld: aWorld.
	target isMorph
		ifTrue:
			[target isWorldMorph ifTrue: [self target: aWorld].
			target isHandMorph ifTrue: [self target: aWorld primaryHand]]
		ifFalse: [(target isKindOf: Presenter) ifTrue: [self target: aWorld presenter]]