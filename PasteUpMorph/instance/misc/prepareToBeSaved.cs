prepareToBeSaved
	"Prepare for export via the ReferenceStream mechanism"

	| exportDict soundKeyList players |
	super prepareToBeSaved.
	turtlePen _ nil.
	self isWorldMorph
		ifTrue: [soundKeyList _ Set new.
			(players _ self presenter allExtantPlayers)
				do: [:aPlayer | aPlayer slotInfo
						associationsDo: [:assoc | assoc value type == #Sound
								ifTrue: [soundKeyList
										add: (aPlayer instVarNamed: assoc key)]]].
			players
				do: [:p | p allScriptEditors
						do: [:e | (e allMorphs
								select: [:m | m isKindOf: SoundTile])
								do: [:aTile | soundKeyList add: aTile literal]]].
			(self allMorphs
				select: [:m | m isKindOf: SoundTile])
				do: [:aTile | soundKeyList add: aTile literal].
			soundKeyList removeAllFoundIn: SampledSound universalSoundKeys.
			soundKeyList
				removeAllSuchThat: [:aKey | (SampledSound soundLibrary includesKey: aKey) not].
			soundKeyList isEmpty
				ifFalse: [exportDict _ Dictionary new.
					soundKeyList
						do: [:aKey | exportDict
								add: (SampledSound soundLibrary associationAt: aKey)].
					self setProperty: #soundAdditions toValue: exportDict]]