hasAnyBorderedCostumes
	"Answer true if any costumes of the receiver are BorderedMorph descendents"

	self costumesDo:
		[:cost | (cost isKindOf: BorderedMorph) ifTrue: [^ true]].
	^ false