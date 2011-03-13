adaptToWorld: aWorld

        super adaptToWorld: aWorld.
        (target isKindOf: Presenter) ifTrue: [^self target: aWorld presenter].
        (target isKindOf: TheWorldMenu) ifTrue: [^target adaptToWorld: aWorld].
        target isMorph ifTrue: [
                target isWorldMorph ifTrue: [self target: aWorld].
                target isHandMorph ifTrue: [self target: aWorld primaryHand]
        ].