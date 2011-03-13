removeFlexShell
	"Remove the shell used to make a morph rotatable and scalable."

	| oldHalo unflexed pensDown player myWorld refPos |
	refPos _ self referencePosition.
	myWorld _ self world.
	oldHalo _ self halo.
	submorphs isEmpty ifTrue: [^ self delete].
	unflexed _ self firstSubmorph.
	pensDown _ OrderedCollection new.
	self allMorphsDo:  "Note any pens down -- must not be down during the move"
		[:m | ((player _ m player) notNil and: [player getPenDown]) ifTrue:
			[m == player costume ifTrue:
				[pensDown add: player.
				player setPenDown: false]]].
	self submorphs do: [:m |
		m position: self center - (m extent // 2).
		owner addMorph: m].
	unflexed absorbStateFromRenderer: self.
	pensDown do: [:p | p setPenDown: true].
	oldHalo ifNotNil: [oldHalo setTarget: unflexed].
	myWorld ifNotNil: [myWorld startSteppingSubmorphsOf: unflexed].
	self delete.
	unflexed referencePosition: refPos.
	^ unflexed