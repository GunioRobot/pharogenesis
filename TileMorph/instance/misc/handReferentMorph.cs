handReferentMorph
	"Hand the user the actual morph referred to"

	| aMorph surrogate |
	((aMorph _ actualObject costume) isMorph and:
		[aMorph isWorldMorph not])
			ifTrue:
				[surrogate _ CollapsedMorph collapsedMorphOrNilFor: aMorph.
				surrogate
					ifNotNil:
						[surrogate uncollapseToHand]
					ifNil:
						[ActiveHand attachMorph: aMorph]]