getterTilesFor: getterSelector type: aType 
	"Answer classic getter for the given name/type"

	"aPhrase _ nil, assumed"

	| selfTile selector aPhrase |
	(#(#color:sees: #colorSees) includes: getterSelector) 
		ifTrue: [aPhrase := self colorSeesPhrase].
	(#(#seesColor: #isOverColor) includes: getterSelector) 
		ifTrue: [aPhrase := self seesColorPhrase].
	(#(#overlaps: #overlaps) includes: getterSelector) 
		ifTrue: [aPhrase := self overlapsPhrase].
	(#(#overlapsAny: #overlapsAny) includes: getterSelector) 
		ifTrue: [aPhrase := self overlapsAnyPhrase].
	(#(#touchesA: #touchesA) includes: getterSelector) 
		ifTrue: [aPhrase := self touchesAPhrase].
	aPhrase ifNil: 
			[aPhrase := PhraseTileMorph new setSlotRefOperator: getterSelector asSymbol
						type: aType].
	selfTile := self tileForSelf bePossessive.
	selfTile position: aPhrase firstSubmorph position.
	aPhrase firstSubmorph addMorph: selfTile.
	selector := aPhrase submorphs second.
	(Vocabulary vocabularyNamed: aType capitalized) 
		ifNotNilDo: [:aVocab | aVocab wantsSuffixArrow ifTrue: [selector addSuffixArrow]].
	selector updateLiteralLabel.
	aPhrase enforceTileColorPolicy.
	^aPhrase