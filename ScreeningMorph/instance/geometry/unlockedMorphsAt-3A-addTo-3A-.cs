unlockedMorphsAt: aPoint addTo: mList
	"Impose screenMorph clipping when screening is in effect"

	(submorphs size = 2
		and: [displayMode == #showScreened
		and: [(self containsPoint: aPoint) not]]) ifTrue: [^ mList].
	^ super unlockedMorphsAt: aPoint addTo: mList
