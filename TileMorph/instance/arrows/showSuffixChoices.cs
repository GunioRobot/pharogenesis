showSuffixChoices
	| plus phrase pad outer num |
	(phrase _ self ownerThatIsA: PhraseTileMorph) ifNil: [^ self].

	(type == #literal) & (literal isNumber) ifTrue: ["Tile is a constant number"
		phrase lastSubmorph == owner "pad"
			ifTrue: ["we are adding the first time (at end of our phrase)"
				plus _ self presenter phraseForReceiver: literal 
						op: #+ arg: 1 resultType: #number.
				owner acceptDroppingMorph: plus event: self primaryHand lastEvent.
				num _ plus firstSubmorph firstSubmorph.
				num deleteSuffixArrow]].

	type == #operator ifTrue: ["Tile is accessor of an expression"
		phrase resultType == #number ifTrue:
			[outer _ phrase ownerThatIsA: PhraseTileMorph.
			pad _ self ownerThatIsA: TilePadMorph.
			outer ifNotNil:
				[outer lastSubmorph == pad ifTrue: [ "first time"
					plus _ self presenter phraseForReceiver: 1 
							op: #+ arg: 1 resultType: #number.
					pad acceptDroppingMorph: plus event: self primaryHand lastEvent.
					(plus firstSubmorph) removeAllMorphs.
					(plus firstSubmorph) addMorph: phrase.	"car's heading"
					self deleteSuffixArrow]]]].

	(phrase topEditor ifNil: [phrase]) enforceTileColorPolicy