newScriptorAround: aPhraseTileMorph
	"Sprout a scriptor around aPhraseTileMorph, thus making a new script"

	| aScriptEditor aUniclassScript ut tw blk |
	aUniclassScript _ self class permanentUserScriptFor: self unusedScriptName player: self.
	aScriptEditor _ aUniclassScript instantiatedScriptEditorForPlayer: self.

	ut _ costume world valueOfProperty: #universalTiles ifAbsent: [false].
	ut ifTrue: [aScriptEditor install.	"to get a default script there"
		aScriptEditor useNewTiles.
		aPhraseTileMorph ifNotNil:
			[tw _ aScriptEditor findA: TwoWayScrollPane.
			blk _ tw scroller firstSubmorph "MethodNode" lastSubmorph "BlockNode".
			blk addMorphFront: aPhraseTileMorph.
			"aPhraseTileMorph position: self topLeft + (7@14)"
			aPhraseTileMorph accept]]
		ifFalse:
			[aPhraseTileMorph 
				ifNotNil: [aScriptEditor phrase: aPhraseTileMorph]	"does an install"
				ifNil: [aScriptEditor install]].
	self class allSubInstancesDo: [:anInst | anInst scriptInstantiationForSelector: aUniclassScript selector].
		"The above assures the presence of a ScriptInstantiation for the new selector in all siblings"
	self updateAllViewersAndForceToShow: #scripts.
	^ aScriptEditor