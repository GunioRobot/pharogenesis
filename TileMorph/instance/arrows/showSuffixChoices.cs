showSuffixChoices
	"The suffix arrow has been hit, so respond appropriately"

	| plusPhrase phrase pad outer num |
	(phrase _ self ownerThatIsA: PhraseTileMorph) ifNil: [^ self].

	(type == #literal) & (literal isNumber) ifTrue: ["Tile is a constant number"
		phrase lastSubmorph == owner "pad"
			ifTrue: ["we are adding the first time (at end of our phrase)"
				plusPhrase _ self phraseForOp: #+ arg: 1 resultType: #Number.
				plusPhrase submorphs second submorphs last setBalloonText: (ScriptingSystem helpStringForOperator: #+).
				owner acceptDroppingMorph: plusPhrase event: self primaryHand lastEvent.
				num _ plusPhrase firstSubmorph firstSubmorph.
				num deleteSuffixArrow]].

	type == #operator ifTrue: ["Tile is accessor of an expression"
		phrase resultType == #Number ifTrue:
			[outer _ phrase ownerThatIsA: PhraseTileMorph.
			pad _ self ownerThatIsA: TilePadMorph.
			outer ifNotNil:
				[outer lastSubmorph == pad ifTrue: [ "first time"
					plusPhrase _ self presenter phraseForReceiver: 1 
							op: #+ arg: 1 resultType: #Number.
					plusPhrase submorphs second submorphs last setBalloonText: (ScriptingSystem helpStringForOperator: #+).
					pad acceptDroppingMorph: plusPhrase event: self primaryHand lastEvent.
					plusPhrase firstSubmorph removeAllMorphs; addMorph: phrase.	"car's heading"
					self deleteSuffixArrow.
					pad topEditor install "recompile"]]]].

	(phrase topEditor ifNil: [phrase]) enforceTileColorPolicy