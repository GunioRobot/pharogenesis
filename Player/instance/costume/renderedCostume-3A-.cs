renderedCostume: aMorph
	"Make aMorph be the receiver's rendered costume; if flexing is currently in effect, make the new morph be flexed correspondingly"

	| renderedMorph known |
	renderedMorph _ costume renderedMorph.
	renderedMorph == aMorph ifTrue: [^ self].
	self rememberCostume: renderedMorph.
	costume isFlexMorph
		ifTrue:
			[costume adjustAfter:
				[costume replaceSubmorph: renderedMorph by: aMorph]]
		ifFalse:
			[costume owner replaceSubmorph: costume by: aMorph.
			aMorph player: self.
			aMorph actorState: costume actorState.
			(known _ costume knownName) ifNotNil:
				[aMorph setNameTo: known].
			costume _ aMorph]